using RestSharp;
using SportRadarPlayByPlay.Models;
using SportRadarPlayByPlay.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportRadarPlayByPlay.Controllers
{
    public class HomeController : Controller
    {
        public static List<string> AlertablePhoneNumbers = new List<string>();

        //1:05 game
        GameModel metsNationals = new GameModel 
        {
            Id = "ecf9878b-0a3e-4dca-8b06-d98c1a5cb7cd",
            MLBId = "2016_03_19_nynmlb_wasmlb_1",
            GameDescription = "NYM@WSH"
        };

        GameModel rockiesPadres = new GameModel 
        {
            Id = "fa605eb7-ede8-4dab-bdd4-c4c2977833d3",
            MLBId = "2016_03_19_colmlb_sdnmlb_1",
            GameDescription = "COL@SD"
        };
        string mlbGameDayUrlTemplate = "http://www.mlb.com/r/game?gid={0}&sport_code=mlb";

        public ActionResult Index()
        {
            var activeGameModel = rockiesPadres;
            var updateService = new UpdateService();
            updateService.Start(activeGameModel);

            return View(activeGameModel);
        }

        [HttpPost]
        public ActionResult Register(string from, String body)
        {
            var phoneNumber = from;
            var message = body;

            System.Diagnostics.Debug.WriteLine("Adding phone number: " + phoneNumber);

            AlertablePhoneNumbers.Add(phoneNumber);

            System.Diagnostics.Debug.WriteLine("Number of alertable phone numbers: " + AlertablePhoneNumbers.Count);

            return View();
#if false
            var response = new TwilioResponse();
            response.Message(outputMessage);

            return TwiML(response);
#endif
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}