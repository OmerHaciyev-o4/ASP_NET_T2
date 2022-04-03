using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Task2.Entities;
using Task2.Helpers;

namespace Task2.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IWebHostEnvironment _webHost;
        public static List<Player> _players = new List<Player>();

        public PlayerController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            return View(_players);
        }

        [HttpGet]
        public IActionResult AddNewPlayer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewPlayer(Player player)
        {
            if (player != null)
            {
                player.ID = _players.Count;

                var helper = new ImageHelper(_webHost);
                player.URL = helper.SaveFile(player.File);

                _players.Add(player);
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("AddNewPlayer");
        }
    }
}