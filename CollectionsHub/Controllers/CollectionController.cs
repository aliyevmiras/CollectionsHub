using AutoMapper;
using CollectionsHub.Models;
using CollectionsHub.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CollectionsHub.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ApplicationContext _db;
        private readonly IMapper _mapper;

        public CollectionController(ApplicationContext db, IMapper autoMapper)
        {
            _db = db;
            _mapper = autoMapper;
        }

        public ActionResult Details(Guid collectionId)
        {
            return View(_db.Collections.Where(c => c.CollectionId == collectionId).FirstOrDefault());
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

        public IActionResult Items(Guid collectionId)
        {
            var collection = _db.Collections.Where(c => c.CollectionId == collectionId).FirstOrDefault();
            CollectionDetailsViewModel viewModel = _mapper.Map<CollectionDetailsViewModel>(collection);
            return View(viewModel);
        }
    }
}
