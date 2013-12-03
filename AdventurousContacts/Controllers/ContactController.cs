using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventurousContacts.Models;
using AdventurousContacts.Models.Repository;

namespace AdventurousContacts.Controllers
{
    public class ContactController : Controller
    {
        private IRepository _repository;

        public ContactController()
            : this(new Repository())
        {
            // Default constructor
        }
        public ContactController(IRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Contact/

        public ActionResult Index()
        {
            var model = _repository.GetLastContacts();
            return View("Index", model);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            return View();
        }

        public ActionResult Edit(int id = 0)
        {
            return View(); // Send form with contact for id
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
            return View(); // edit stuff, return successmessage view!!!
        }

        public ActionResult Delete(int id = 0)
        {
            return View(); // ARE U SURE U WANT TO DELETE CONTACT???
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            return View(); // Actually delete contact, return sucessmessage view!!!!!
        }



        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
