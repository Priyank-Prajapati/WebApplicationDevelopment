using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Priyank_P_301112923.Models;

namespace Priyank_P_301112923.Controllers
{
    public class ClubController : Controller
    {
        private IClubRepository repository;

        public ClubController(IClubRepository repo)
        {
            repository = repo;
        }
        public ViewResult Club() => View(repository.Clubs);
        public ViewResult EditClub(int ID) => View(repository.Clubs
            .FirstOrDefault(c => c.ID == ID));

        [HttpPost]
        public IActionResult EditClub(Club club)
        {
            if(ModelState.IsValid)
            {
                repository.AddClub(club);
                return RedirectToAction("ClubDetails");
            }
            else
            {
                return View(club);
            }
        }

        [HttpPost]
        public IActionResult Delete(int ID)
        {
            Club deletedclub = repository.DeleteClub(ID);
            if(deletedclub != null)
            {
                TempData["msg"] = $"{deletedclub.Name} was deleted";
            }
            return RedirectToAction("ClubDetails");
        }
        public ViewResult ClubDetails() => View(repository.Clubs);
        [HttpGet]
        [Route("/Club/ClubDetails/{id}")]
        public ViewResult ClubList(string ID)
        {
            return View("ClubDetails", repository.Clubs.Where(c => c.Name == ID));
        }

        //public ViewResult Club() => View(repository.Clubs);

        [HttpGet]
        public ViewResult AddClub()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddClub(Club club)
        {
            repository.AddClub(club);
            ModelState.Clear();
            return View("Club", repository.Clubs);
        }

        public ViewResult Cancel()
        {
            return View("Index");
        }
    }
}