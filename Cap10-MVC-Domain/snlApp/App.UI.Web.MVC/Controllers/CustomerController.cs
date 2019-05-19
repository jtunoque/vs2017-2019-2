using App.Domain;
using App.Domain.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerDomain customerDomain;

        public CustomerController()
        {
            customerDomain = new CustomerDomain();
        }


        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ObtenerClientes(string artistaNombre)
        {
            artistaNombre = artistaNombre ?? "";
            var listado = customerDomain.Get(artistaNombre);

            //System.Threading.Thread.Sleep(2000);

            return PartialView(listado);
        }

        [HttpPost]
        public ActionResult Save(Customer model)
        {
            var result = customerDomain.Save(model);

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult Edit(int id)
        {
            var artista = customerDomain.GetById(id);

            return View(artista);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}