using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IntranetRosul.Models;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.IO;

namespace IntranetRosul.Controllers
{
    public class notificacionRetencionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: notificacionRetencions
        public async Task<ActionResult> Index(string codigo)
        {
            foreach (string upload in Request.Files)
            {
                if (Request.Files[upload].FileName != "")
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "/Content/Upload/";
                    string filename = Path.GetFileName(Request.Files[upload].FileName);
                    Request.Files[upload].SaveAs(Path.Combine(path, filename));
                    return View("Create",new { codigo = codigo});
                }
            }
            return View(await db.notificacionRetencions.ToListAsync());
        }

        // GET: notificacionRetencions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notificacionRetencion notificacionRetencion = await db.notificacionRetencions.FindAsync(id);
            if (notificacionRetencion == null)
            {
                return HttpNotFound();
            }
           
                return View(notificacionRetencion);
        }

        // GET: notificacionRetencions/Create
        public async Task<ActionResult> Create(string codigo,string CardName, string Local)
        {



            ViewBag.CodeCard = codigo;
            ViewBag.CardName = CardName;
            ViewBag.Local = Local;

            string apiUrl = "http://192.168.16.13:8099/consultas/Lista_factura_cancelar/";
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("?CodeCard=" + codigo);
                if (response.IsSuccessStatusCode)
                {

                    string[] Month = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

                    string data = response.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    factura[] facturas = js.Deserialize<factura[]>(data);

                    List<SelectListItem> items = new List<SelectListItem>();

                    for (int i = 0; i < facturas.Length; i++)
                    {
                        string NumAtCard = facturas[i].NumAtCard.ToString();

                        string mes = facturas[i].NumAtCard.ToString() + "  (" + Month[Int32.Parse(facturas[i].mes) - 1] + ")";

                        items.Add(new SelectListItem { Value = NumAtCard.ToString(), Text = mes, Selected = true });
                    }

                    var ListItems = new SelectList(items);

                    ViewBag.facturasc = items;
                    ViewBag.codigo = codigo;


                    
                }
                return View();
            }
        }
        // POST: notificacionRetencions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string CodeCard, string CardName, string Local, [Bind(Include = "id,factura,montoF,tipo,noDoc,montoR,path")] notificacionRetencion notificacionRetencion,string codigo)
        {

            ViewBag.CodeCard = CodeCard;
            ViewBag.CardName = CardName;
            ViewBag.Local = Local;
            if (ModelState.IsValid)
            {
                db.notificacionRetencions.Add(notificacionRetencion);
                await db.SaveChangesAsync();
                string email;
                string asunto;
                string fecha;
                string Nofactura;
                string Noretencion;
                string Path;
                string Monto;
                DateTime thisDay = DateTime.Today;
                asunto = "Notificación de Retención de cliente";
                //cuerpo = "<h3>DETALLE DE DEPOSITO</h3> <table><thead><th><td>Fecha</td><td>No. Documento<td></td>Tipo Pago<td>Cuenta</td><td>Monto</td></th>"+
                //         "</thead>"+
                //         "<tr>"+
                //         "<td></td><td></td><td></td><td></td><td></td><td></td><td></td>" +
                //         "<tr>" +
                //         "</table>";
                // string path = AppDomain.CurrentDomain.BaseDirectory + "/Content/Upload/";
                // cuerpo = "FECHA:" + thisDay.ToString("d") + " No. Factura: " + notificacionRetencion.factura + " No. Retencion: "+ notificacionRetencion.path + " " + notificacionRetencion.noDoc + " MONTO: " + notificacionRetencion.montoR;
                email = "wrosales@ventasurbanica.com";
                fecha = thisDay.ToString("d");
                Nofactura = notificacionRetencion.factura;
                Noretencion = notificacionRetencion.noDoc;
                Path = notificacionRetencion.path;
                Monto = notificacionRetencion.montoR;
                string uri = "http://192.168.16.13:8099/consultas/Enviar_Correo_notRetencion/?email="+email+"&subject=" + asunto
                            + "&fecha=" + fecha
                            + "&factura=" + Nofactura
                            + "&retencion=" + Noretencion
                            + "&file=" + Path
                            + "&monto=" + Monto
                            ;
                            
              
                using (HttpClient httpClient = new HttpClient())
                {
                    Task<String> response = httpClient.GetStringAsync(uri);
                    string resultado = response.Result;
                    return Redirect("Create?codigo="+codigo);
                }
                return RedirectToAction("Create", new { codigo = CodeCard, CardName = CardName, Local = Local });
            }

            return View();
        }

        // GET: notificacionRetencions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notificacionRetencion notificacionRetencion = await db.notificacionRetencions.FindAsync(id);
            if (notificacionRetencion == null)
            {
                return HttpNotFound();
            }
            return View(notificacionRetencion);
        }

        // POST: notificacionRetencions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,factura,montoF,tipo,noDoc,montoR,path")] notificacionRetencion notificacionRetencion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notificacionRetencion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(notificacionRetencion);
        }

        // GET: notificacionRetencions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notificacionRetencion notificacionRetencion = await db.notificacionRetencions.FindAsync(id);
            if (notificacionRetencion == null)
            {
                return HttpNotFound();
            }
            return View(notificacionRetencion);
        }

        // POST: notificacionRetencions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            notificacionRetencion notificacionRetencion = await db.notificacionRetencions.FindAsync(id);
            db.notificacionRetencions.Remove(notificacionRetencion);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
