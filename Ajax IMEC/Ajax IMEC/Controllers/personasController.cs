using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ajax_IMEC.Models;

namespace Ajax_IMEC.Controllers
{
    public class personasController : Controller
    {
        private Entities db = new Entities();

        /*Método para la vista AJAX que cuenta con todo el IMEC de Persona*/
        public ActionResult AJAX()
        {
            ModeloIntermedio modelo = new ModeloIntermedio();
            modelo.listaPersonas = db.persona.ToList();
            return View(modelo);
        }

        /*Método llamado por AJAX para cargar una nueva tupla en la tabla (revisar la vista que lleva el mismo nombre en la carpeta Views)*/
        public ActionResult insertarPersona(string nombre, string apellido1, string cedula, string carne, bool sexo, DateTime fechaNac)
        {
            persona nueva = new persona();

            nueva.apellido1 = apellido1;
            nueva.nombre = nombre;
            nueva.cedula = cedula;
            nueva.carne = carne;
            nueva.sexo = sexo;
            nueva.fechaNac = fechaNac;

            ModeloIntermedio mod = new ModeloIntermedio(nueva);

            db.persona.Add(nueva);
            db.SaveChanges();
            mod.listaPersonas.Add(mod.modeloPersona);
            return View(mod);
        }


        /*Método llamado por AJAX para cargar un nuevo div con los datos de la persona a modificar (revisar la vista que lleva el mismo nombre en la carpeta Views)*/
        public ActionResult modificarPersona(string cedula)
        {
            if (cedula == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(cedula);
            if (persona == null)
            {
                return HttpNotFound();
            }

            ModeloIntermedio mod = new ModeloIntermedio(persona);

            return View(mod);
        }

        /*Método llamado por AJAX para guardar los cambios de la persona modificada y cargarlos nuevamente en la tabla (revisar la vista que lleva el mismo nombre en la carpeta Views)*/
        public ActionResult guardarCambiosPersona(string nombre, string apellido1, string cedula, string carne, bool sexo, DateTime fechaNac)
        {
            persona nueva = new persona();

            nueva.apellido1 = apellido1;
            nueva.nombre = nombre;
            nueva.cedula = cedula;
            nueva.carne = carne;
            nueva.sexo = sexo;
            nueva.fechaNac = fechaNac;

            if (ModelState.IsValid)
            {
                db.Entry(nueva).State = EntityState.Modified;
                db.SaveChanges();
            }

            ModeloIntermedio mod = new ModeloIntermedio(nueva);
            mod.listaPersonas.Add(mod.modeloPersona);
            return View(mod);
        }

        /*Método llamado por AJAX para eliminar una persona y actualizar la tabla (revisar la vista que lleva el mismo nombre en la carpeta Views)*/
        public ActionResult eliminarPersona(string cedula)
        {
            persona persona = db.persona.Find(cedula);
            db.persona.Remove(persona);
            db.SaveChanges();
            return Json(new { success = true });
        }

        //---------------------------------------------------------MÉTODOS AUTOGENERADOS
        // GET: personas
        public ActionResult Index()
        {
            return View(db.persona.ToList());
        }

        // GET: personas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre,apellido1,apellido2,cedula,carne,sexo,fechaNac,email,id")] persona persona)
        {
            if (ModelState.IsValid)
            {
                db.persona.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(persona);
        }

        // GET: personas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nombre,apellido1,apellido2,cedula,carne,sexo,fechaNac,email,id")] persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(persona);
        }

        // GET: personas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            persona persona = db.persona.Find(id);
            db.persona.Remove(persona);
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
