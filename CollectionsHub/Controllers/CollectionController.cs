using CollectionsHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollectionsHub.Controllers
{
    public class CollectionController : Controller
    {
        public ActionResult Details(Guid collectionId)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Collection collection)
        {
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Guid id, Collection collection)
        {
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Guid id, Collection collection)
        {
            return View();
        }
    }
}
