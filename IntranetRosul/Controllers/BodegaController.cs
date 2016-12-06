using IntranetRosul.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
namespace IntranetRosul.Controllers
{

    public class BodegaController : Controller
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
        // GET: Bodega
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            string apiUrl = "http://192.168.16.13:8093/api-gps/";

            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Query/obtiene_vista_detalle_bodega");
                if (response.IsSuccessStatusCode)
                {

                    string data = response.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    js.MaxJsonLength = Int32.MaxValue;
                    Models.Material[] Materiales = js.Deserialize<Models.Material[]>(data);



                    ViewBag.materiales = Materiales;

                    return View();

                }
            

            }

            return View();
        }

       

        // GET: Bodega/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bodega/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bodega/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bodega/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bodega/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bodega/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bodega/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
