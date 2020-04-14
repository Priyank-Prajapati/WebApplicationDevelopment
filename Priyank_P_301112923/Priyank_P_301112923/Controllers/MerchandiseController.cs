using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Priyank_P_301112923.Models;

namespace Priyank_P_301112923.Controllers
{
    public class MerchandiseController : Controller
    {
        private IMerchandiseRepository repository;
        private IClubRepository clubRepository;

        public MerchandiseController(IMerchandiseRepository repo, IClubRepository clubRepo)
        {
            repository = repo;
            clubRepository = clubRepo;
        }
        public ViewResult MerchandiseDetails(int ID)
        {
            return View("MerchandiseDetails", repository.Merchandises.Where(m => m.ID == ID));
        }
        public ViewResult Merchandise() => View(repository.Merchandises);


        [Authorize]
        public ViewResult AddMerchandise()
        {
            ViewBag.club = clubRepository.Clubs;
            return View();
        }
        [HttpPost]
        [Authorize]
        public ViewResult AddMerchandise(Merchandise merchandise)
        {
            repository.AddMerchandise(merchandise);
            ModelState.Clear();
            ViewBag.club = clubRepository.Clubs;
            TempData["Mmsg"] = $"{merchandise.ProductName} for {merchandise.ProductClub} has been Added";
            return View("Merchandise");
        }


        [Authorize]
        public ViewResult EditMerchandise(int ID)
        {
            ViewBag.club = clubRepository.Clubs;
            return View(repository.Merchandises.FirstOrDefault(m => m.ID == ID));
        }
        [HttpPost]
        [Authorize]
        public IActionResult EditMerchandise(Merchandise merchandise)
        {
            if (ModelState.IsValid)
            {
                ViewBag.club = clubRepository.Clubs;
                repository.AddMerchandise(merchandise);
                return RedirectToAction("Merchandise");
            }
            else
            {
                return View(merchandise);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(int ID)
        {
            Merchandise deletedmerchandise = repository.DeleteMerchandise(ID);
            if (deletedmerchandise != null)
            {
                TempData["Mmsg"] = $"{deletedmerchandise.ProductName} was deleted";
            }
            return RedirectToAction("Merchandise");
        }
    }
}