﻿using RestSharp;
using SportRadarPlayByPlay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace SportRadarPlayByPlay.Services
{
    public class UpdateService
    {
        private string resourceUrl = "http://api.sportradar.us/mlb-t5";
        private string apiKey = "arhq4rqppwe4jwa6kyzg2mzc";
        private TimeSpan alertFrequency = TimeSpan.FromMinutes(1);
        Timer timer;

        public void Start(GameModel game) 
        {
            timer = new System.Threading.Timer(
                e => GetRealTimeGameData(game),
                null,
                TimeSpan.Zero,
                alertFrequency);
        }

        public void Stop()
        {
            timer.Dispose();
        }

        public void GetRealTimeGameData(GameModel game)
        {
            var client = new RestClient(resourceUrl);
            var request = new RestRequest("games/{id}/pbp.json?api_key=" + apiKey, Method.GET);
            request.AddUrlSegment("id", game.Id); // replaces matching token in request.Resource
            IRestResponse<RootObject> gameData = client.Execute<RootObject>(request);

            var text = String.Format("{0} {1} {2} {3}", 
                DateTime.Now.ToShortTimeString(), 
                game.GameDescription, 
                gameData.Data.game.status, 
                "0 on 0 outs Matt Kemp due up" // figure this out from data
            );
            var link = String.Format("http://www.mlb.com/r/game?gid={0}&sport_code=mlb", game.MLBId);
            SendTwilioUpdate(text, link);
        }

        private void SendTwilioUpdate(string text, string link)
        {
            // plug in call to Bill's thing here
            var response = Alerter.AlertUsers(link, text);
            System.Diagnostics.Debug.WriteLine(response);
        }
    }
}