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
        public ActionResult Create([Bind(Exclude="ContactID")]Contact contact)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(contact);
                _repository.Save();
                return View("Success", contact);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ett okänt fel inträffade, försök gärna igen.");
            }
            return View("Create");
        }

        public ActionResult Edit(int id = 0)
        {
            var contact = _repository.GetContactByID(id);
            if (contact == null)
            {
                return View("NotFound", string.Empty, "Kontakten du försökte redigera existerar inte.");
            }
            else if (contact.ContactID <= 19977)
            {
                ModelState.AddModelError(string.Empty, "Varning: Det går inte att redigera kontakten för att den är tillagd av Mats!");
                return View("Edit");
            }

            return View("Edit", contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(contact);
                _repository.Save();
                return View("Success", contact);
            }
            return View("NotFound", string.Empty, "Okänt fel inträffade."); 
        }

        public ActionResult Delete(int id = 0)
        {
            var contact = _repository.GetContactByID(id);
            if (contact == null)
            {
                return View("NotFound", string.Empty, "Kontakten du försökte ta bort existerar inte.");
            }
            else if (contact.ContactID <= 19977)
            {
                return View("NotFound", string.Empty, "Varning: Det går inte att ta bort kontakten för att den är tillagd av Mats!");
            }
            return View("Delete", contact);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                var contact = _repository.GetContactByID(id);
                if (contact == null)
                {
                    return View("NotFound", string.Empty, "Kontakten du försökte ta bort existerar inte.");
                }
                else if (contact.ContactID <= 19977)
                {
                    return View("NotFound", string.Empty, "Varning: Det går inte att ta bort kontakten för att den är tillagd av Mats!");
                }
                else
                {
                    _repository.Delete(contact);
                    _repository.Save();
                    return View("DeleteSuccess", contact);
                }
            }
            return View("NotFound", string.Empty, "Okänt fel inträffade.");
        }



        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
