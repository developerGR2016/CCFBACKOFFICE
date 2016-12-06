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
    public class MarcajeController : Controller
    {
        // GET: Marcaje
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {

            var codigoColaborador = Session["CodUsuario"];
            string apiUrl = "http://192.168.16.13:8093/api-gps/";

            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Query/get_lista_colaboradores_responsable/?colaboradorId=" + codigoColaborador);
                if (response.IsSuccessStatusCode)
                {
               
                  string data =  response.Content.ReadAsStringAsync().Result;
                  JavaScriptSerializer js = new JavaScriptSerializer();
                  Colaborador[] Colaboradores = js.Deserialize<Colaborador[]>(data);

                    List<SelectListItem> items = new List<SelectListItem>();

                    for (int i = 0; i < Colaboradores.Length; i++) {
                        string codigocolaborador = Colaboradores[i].COD_FICHA.ToString();
                        string nombres = Colaboradores[i].NOMBRES + ' ' + Colaboradores[i].APELLIDOS;
                        items.Add(new SelectListItem { Value = codigocolaborador.ToString(), Text = nombres, Selected = true });
                    }

                    var ListItems = new SelectList(items);

                    ViewBag.Colaborador = items;
                    
                    
                    return View();

                }

               
            }

        
            /*   var items = // Your List of data
             model.ListName = items.Select(x => new SelectListItem()
              {
                  Text = x.prop,
                  Value = x.prop2
              });*/
            return View();
        }

        // GET: Marcaje/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Marcaje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marcaje/Create
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

        // GET: Marcaje/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Marcaje/Edit/5
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

        // GET: Marcaje/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Marcaje/Delete/5
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
