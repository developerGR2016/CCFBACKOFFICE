using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IntranetRosul.Models;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.Helpers;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using System.Net.Sockets;

namespace IntranetRosul.Controllers
{
    public class NotificacionPagoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public object Method { get; private set; }

        // GET: NotificacionPagoes
        public ActionResult Index()
        {
            return View(db.NotificacionPagoes.ToList());

        }

        // GET: NotificacionPagoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotificacionPago notificacionPago = db.NotificacionPagoes.Find(id);
            if (notificacionPago == null)
            {
                return HttpNotFound();
            }
            return View(notificacionPago);
        }

        // GET: NotificacionPagoes/Create
        public async Task<ActionResult> Create(string codigo)
        {

            ViewBag.CodeCard = Session["CodeCard"];
            ViewBag.CardName = Session["CardName"];
            ViewBag.Local = Session["Local"];
            string apiUrl = "http://192.168.16.13:8099/consultas/Lista_factura_cancelar/";
            string apiUrl2 = "http://192.168.16.13:8099/consultas/Lista_Cta_Bancos";
           

            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("?CodeCard="+codigo);
                if (response.IsSuccessStatusCode)
                {

                    string[] Month = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre" };

                    string data = response.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    factura[] facturas = js.Deserialize<factura[]>(data);

                    List<SelectListItem> items = new List<SelectListItem>();

                    for (int i = 0; i < facturas.Length; i++)
                    {
                        string NumAtCard = facturas[i].NumAtCard.ToString();
                        
                        string mes = facturas[i].NumAtCard.ToString() + "  (" + Month[Int32.Parse(facturas[i].mes)-1] +")" ;
                       
                        items.Add(new SelectListItem { Value = NumAtCard.ToString(), Text = mes, Selected = true });
                    }   

                    var ListItems = new SelectList(items);

                    ViewBag.facturasc = items;
                    ViewBag.CodeCard = codigo;

                    // return View();
                }

                using (HttpClient client2 = new HttpClient())
                {

                    client2.BaseAddress = new Uri(apiUrl2);
                    client2.DefaultRequestHeaders.Accept.Clear();
                    client2.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response2 = await client2.GetAsync("");
                    if (response2.IsSuccessStatusCode)
                    {

                        string data = response2.Content.ReadAsStringAsync().Result;
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        banco[] bancos = js.Deserialize<banco[]>(data);

                        List<SelectListItem> items = new List<SelectListItem>();

                        for (int i = 0; i < bancos.Length; i++)
                        {
                            string AcctCode = bancos[i].AcctCode.ToString();
                            string AcctName = bancos[i].AcctName.ToString() ;
                            items.Add(new SelectListItem { Value = AcctCode.ToString(), Text = AcctName, Selected = true });
                        }

                        var ListItems = new SelectList(items);

                        ViewBag.cuentasb = items;

                        return View();
                    }


                    return View();
                }

            }

            string apiUrl3 = "http://192.168.16.13:8099/consultas/Lista_Locales/";
            using (HttpClient client3= new HttpClient())
            {

                client3.BaseAddress = new Uri(apiUrl3);
                client3.DefaultRequestHeaders.Accept.Clear();
                client3.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response3 = await client3.GetAsync(apiUrl3 + "Lista_Locales?Codigo=" + codigo);
                if (response3.IsSuccessStatusCode)
                {

                    string data = response3.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Local[] locales = js.Deserialize<Local[]>(data);

                    List<SelectListItem> itemsL = new List<SelectListItem>();

                    for (int i = 0; i < locales.Length; i++)
                    {
                        string codig = locales[i].codigo.ToString();
                        string nombre = locales[i].Nombre.ToString();
                        string local = locales[i].local.ToString();
                        itemsL.Add(new SelectListItem { Value = codig.ToString(), Text = local, Selected = true });
                    }

                    var ListItems = new SelectList(itemsL);

                    ViewBag.locales = itemsL;


                }
            }

        }
        // POST: NotificacionPagoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(string CodeCard, string CardName, string Local,[Bind(Include = "id,factura,monedaF,montoSaldo,documento,tipoDeposito,cuentaBancaria,monedaR,montoD")] NotificacionPago notificacionPagos)
        {
            ViewBag.CodeCard = CodeCard;
            ViewBag.CardName = CardName;
            ViewBag.Local = Local;

            if (ModelState.IsValid)
            {
                db.NotificacionPagoes.Add(notificacionPagos);
                db.SaveChanges();
                string email;
                string asunto;
                string fecha;
                string documento;
                string tipo_transaccion;
                string monto;
                string cuenta;
                DateTime thisDay = DateTime.Today;
                email = "wrosales@ventasurbanica.com";
                asunto = "Notificación de Depósito de cliente";
                fecha = thisDay.ToString("d");
                documento = notificacionPagos.documento;
                tipo_transaccion = notificacionPagos.tipoDeposito;
                cuenta = notificacionPagos.cuentaBancaria;
                // cuerpo = "FECHA:" + thisDay.ToString("d") + "DOCUMENTO: " + notificacionPagos.documento + " TIPO TRANSACCION: " + notificacionPagos.tipoDeposito + " CUENTA MONETARIA: " + notificacionPagos.cuentaBancaria + "MONTO: " + notificacionPagos.montoD;
                monto = notificacionPagos.montoD;
                string uri = "http://192.168.16.13:8099/consultas/Enviar_Correo_notPago/?email="+email+"&subject=" + asunto
                            + "&fecha=" + fecha
                            + "&documento=" + documento
                            + "&tipo_transaccion=" + tipo_transaccion
                            + "&monto=" + cuenta
                            + "&cuenta=" + monto ;

                using (HttpClient httpClient = new HttpClient())
                {
                    Task<String> response = httpClient.GetStringAsync(uri);
                    string resultado = response.Result;
                    return RedirectToAction("Create", new { codigo = CodeCard, CardName = CardName, Local = Local });
                }




            }

            return View(notificacionPagos);
        }

        // GET: NotificacionPagoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotificacionPago notificacionPago = db.NotificacionPagoes.Find(id);
            if (notificacionPago == null)
            {
                return HttpNotFound();
            }


            return View(notificacionPago);
        }

        // POST: NotificacionPagoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,factura,monedaF,montoSaldo,documento,tipoDeposito,cuentaBancaria,monedaR,montoD")] NotificacionPago notificacionPago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notificacionPago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notificacionPago);
        }

        // GET: NotificacionPagoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotificacionPago notificacionPago = db.NotificacionPagoes.Find(id);
            if (notificacionPago == null)
            {
                return HttpNotFound();
            }
            return View(notificacionPago);
        }

        // POST: NotificacionPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
       // [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NotificacionPago notificacionPago = db.NotificacionPagoes.Find(id);
            db.NotificacionPagoes.Remove(notificacionPago);
            db.SaveChanges();
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
