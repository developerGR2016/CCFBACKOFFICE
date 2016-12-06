using IntranetRosul.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.Owin.Security;
using Microsoft.Owin;

namespace IntranetRosul.Controllers
{
    [EnableCors(origins: "192.168.16.13", headers: "*", methods: "*")]
    public class EstadoDeCuentaController : Controller
    {

        
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }
        // GET: EstadoDeCuenta

        public async Task<ActionResult> Index(string CodeCard, string CardName, string Local)
        {


            ViewBag.CodeCard = CodeCard;
            ViewBag.CardName = CardName;
            ViewBag.Local = Local;
            string apiUrl2 = "http://192.168.16.13:8099/consultas/Lista_Locales/";
            using (HttpClient client2 = new HttpClient())
            {

                client2.BaseAddress = new Uri(apiUrl2);
                client2.DefaultRequestHeaders.Accept.Clear();
                client2.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response3 = await client2.GetAsync(apiUrl2 + "Lista_Locales?Codigo=" + CodeCard);
                if (response3.IsSuccessStatusCode)
                {

                    string data = response3.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Local[] locales = js.Deserialize<Local[]>(data);

                    List<SelectListItem> itemsL = new List<SelectListItem>();

                    for (int i = 0; i < locales.Length; i++)
                    {
                        string codigo = locales[i].codigo.ToString();
                        string nombre = locales[i].Nombre.ToString();
                        string local = locales[i].local.ToString();
                        itemsL.Add(new SelectListItem { Value = codigo.ToString(), Text = local, Selected = true });
                    }

                    var ListItems = new SelectList(itemsL);

                    ViewBag.locales = itemsL;


                }



                return View();
            }
        }
        // GET: ResultadosEC
        public async System.Threading.Tasks.Task<ActionResult> ResultadosEC(string CodeCard, string FechaIni, string FechaFin, string CardName,string Local)
        {

            ViewBag.CodeCard = Session["CodeCard"];
            ViewBag.CardName = Session["CardName"];
            ViewBag.Local = Session["Local"];
            string apiUrl = "http://192.168.16.13:8099/consultas/";

            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(apiUrl + "estadoCuenta/?CodeCard=" + CodeCard + "&FechaIni= " + FechaIni + "&FechaFin=" + FechaFin);
                if (response.IsSuccessStatusCode)
                {

                    string data = response.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    js.MaxJsonLength = Int32.MaxValue;
                   EstadoC[] Estados = js.Deserialize<EstadoC[]>(data);

                    ViewBag.Estados = Estados;
                    decimal totalC = 0;
                    decimal totalP = 0;
                    decimal totalS = 0;
                    string money = "";

                    foreach (var item in Estados) {
                    
                            totalP += item.ABONO2;
                    
                            totalC += item.Cargo;

                            totalS = totalC - totalP;
                    


                    }
                    ViewBag.TotalC = totalC;
                    ViewBag.TotalP =totalP;
                    ViewBag.TotalS = totalS;
                    ViewBag.moneda = money;
                    return View();
                  

                }
                HttpResponseMessage response2 = await client.GetAsync(apiUrl + "DiasVencidos/?CodeCard=" + CodeCard );
                if (response2.IsSuccessStatusCode)
                {

                    string data = response2.Content.ReadAsStringAsync().Result;
                  

                    ViewBag.Dias = data;
         

                   
                    return View();


                }


            }




            return View();
        }

        // GET: FacturaSinCancelar
        public async System.Threading.Tasks.Task<ActionResult> ResultadosFSC(string CodeCard, string CardName, string Local)
        {


            ViewBag.CodeCard = Session["CodeCard"] = CodeCard;
            ViewBag.CardName = Session["CardName"] = CardName;
            ViewBag.Local = Session["Local"] = Local;

            string apiUrl = "http://192.168.16.13:8099/consultas/";
            string apiUrl2 = "http://192.168.16.13:8099/consultas/Lista_Locales/";

            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(apiUrl + "facturaSinCancelar/?CodeCard=" + CodeCard);
                if (response.IsSuccessStatusCode)
                {

                    string data = response.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    js.MaxJsonLength = Int32.MaxValue;
                    facturas_sin_cancelar[] Estados = js.Deserialize<facturas_sin_cancelar[]>(data);

                    ViewBag.Estados = Estados;

                    decimal totalP = 0;
                    string money = "";


                    foreach (var item in Estados)
                    {

                        totalP += item.DocTotal;
                        money = item.DocCur;
                    }

                    ViewBag.TotalP = totalP;
                    ViewBag.moneda = money;
                   


                }
                HttpResponseMessage response2 = await client.GetAsync(apiUrl + "DiasVencidos/?CodeCard=" +CodeCard);
                if (response2.IsSuccessStatusCode)
                {

                    string data = response2.Content.ReadAsStringAsync().Result;


                    ViewBag.Dias = data;



                   


                }


        

            using (HttpClient client2 = new HttpClient())
            {

                client2.BaseAddress = new Uri(apiUrl2);
                client2.DefaultRequestHeaders.Accept.Clear();
                client2.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response3 = await client2.GetAsync(apiUrl2 + "Lista_Locales?Codigo=" + CodeCard);
                if (response3.IsSuccessStatusCode)
                {

                    string data = response3.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Local[] locales = js.Deserialize<Local[]>(data);

                    List<SelectListItem> itemsL = new List<SelectListItem>();

                    for (int i = 0; i < locales.Length; i++)
                    {
                        string codigo = locales[i].codigo.ToString();
                        string nombre= locales[i].Nombre.ToString();
                        string local = locales[i].local.ToString();
                        itemsL.Add(new SelectListItem { Value = codigo.ToString(), Text = local, Selected = true });
                    }

                    var ListItems = new SelectList(itemsL);

                    ViewBag.locales = itemsL;

                  
                }




                return View();
        }

            }
            return View();
        }
        // GET: Upload
        public ActionResult UploadDocument()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Upload"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("UploadDocument");
        }

        // GET: notificacionPagos

        public ActionResult notificacionPagos() {

            return View();
        }

        // PUT estadoDeCuenta/c0000
        public void Put(int id, [FromBody]string value)
        {

        }
       
    }
   
}