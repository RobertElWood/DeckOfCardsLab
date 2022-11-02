using DeckofCardsAPILab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace DeckofCardsAPILab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        DOCAPIDAL api = new DOCAPIDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            NewDeck n = api.CreateDeck();
            return View(n);
        }

        public IActionResult ShuffleDeckView(string deckId)
        {
            ShuffledDeck s = api.ShuffleDeck(deckId);
            return View(s);
        }

        public IActionResult ReShuffleView(string deckId)
        {
            ShuffledDeck n = api.ReShuffleDeck(deckId);
            return View(n);
        }

        public IActionResult Index2 (string deckId)
        {
            ShuffledDeck d = api.ReShuffleDeck(deckId);
            return View(d);
        }

        public IActionResult DrawCardsView(string deckId, int count)
        {
            DrawACard d = api.DrawCards(deckId, count);
            return View(d);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}