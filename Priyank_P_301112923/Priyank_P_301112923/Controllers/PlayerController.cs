using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Priyank_P_301112923.Models;

namespace Priyank_P_301112923.Controllers
{
    public class PlayerController : Controller
    {
        private IPlayerRepository repository;
        private IClubRepository clubRepository;

        public PlayerController(IPlayerRepository repo, IClubRepository clubRepo)
        {
            repository = repo;
            clubRepository = clubRepo;
        }
        [HttpGet]
        [Authorize]
        public ViewResult ManagePlayers()
        {
            ViewBag.club = clubRepository.Clubs;
            return View();
        }
        [HttpPost]
        [Authorize]
        public ViewResult ManagePlayers(Player player)
        {
            repository.AddPlayer(player);
            ModelState.Clear();
            ViewBag.club = clubRepository.Clubs;
            TempData["message"] = $"{player.FirstName + " " + player.LastName} has been Added to {player.Club}";
            return View();
        }
        public ViewResult Player(string ID)
        {
            return View("Player", repository.Players.Where(player => player.Club == ID));
        }
        [Authorize]
        public ViewResult EditPlayer(int ID)
        {
            ViewBag.club = clubRepository.Clubs;
            return View(repository.Players.FirstOrDefault(p => p.ID == ID));
        }
        [HttpPost]
        [Authorize]
        public IActionResult EditPlayer(Player player)
        {
            if (ModelState.IsValid)
            {
                ViewBag.club = clubRepository.Clubs;
                repository.AddPlayer(player);
                return RedirectToAction("Player");
            }
            else
            {
                return View(player);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(int ID)
        {
            Player deletedplayer = repository.DeletePlayer(ID);
            if (deletedplayer != null)
            {
                TempData["pmsg"] = $"{deletedplayer.FirstName} was deleted";
            }
            return RedirectToAction("/Player/" + deletedplayer.Club);
        }
    }
}