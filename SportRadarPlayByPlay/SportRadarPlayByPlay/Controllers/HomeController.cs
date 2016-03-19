﻿using RestSharp;
using SportRadarPlayByPlay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportRadarPlayByPlay.Controllers
{
    public class HomeController : Controller
    {
        //1:05 game
        GameModel metsNationals = new GameModel 
        {
            Id = "ecf9878b-0a3e-4dca-8b06-d98c1a5cb7cd",
            MLBId = "2016_03_19_nynmlb_wasmlb_1",
            GameDescription = "Mets at Nationals"
        };
        GameModel rockiesPadres = new GameModel 
        {
            Id = "fa605eb7-ede8-4dab-bdd4-c4c2977833d3",
            MLBId = "2016_03_19_colmlb_sdnmlb_1",
            GameDescription = "Rockies at Nationals"
        };
        string apiKey = "arhq4rqppwe4jwa6kyzg2mzc";
        string mlbGameDayUrlTemplate = "http://www.mlb.com/r/game?gid={0}&sport_code=mlb";

        string resourceUrl = "http://api.sportradar.us/mlb-t5";
        public ActionResult Index()
        {
            var activeGameModel = metsNationals;

            var client = new RestClient(resourceUrl);
            var request = new RestRequest("games/{id}/pbp.json?api_key=" + apiKey, Method.GET);
            //request.AddUrlSegment("id", activeGameModel.Id); // replaces matching token in request.Resource
            //IRestResponse<RootObject> gameData = client.Execute<RootObject>(request);

            return View(activeGameModel);
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