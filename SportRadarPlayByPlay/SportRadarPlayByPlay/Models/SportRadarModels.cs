using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRadarPlayByPlay.Models
{

    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public string market { get; set; }
        public int capacity { get; set; }
        public string surface { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
    }

    public class Broadcast
    {
        public string network { get; set; }
    }

    public class Home
    {
        public string name { get; set; }
        public string market { get; set; }
        public string abbr { get; set; }
        public string id { get; set; }
        public int runs { get; set; }
        public int hits { get; set; }
        public int errors { get; set; }
    }

    public class Away
    {
        public string name { get; set; }
        public string market { get; set; }
        public string abbr { get; set; }
        public string id { get; set; }
        public int runs { get; set; }
        public int hits { get; set; }
        public int errors { get; set; }
    }

    public class Scoring
    {
        public Home home { get; set; }
        public Away away { get; set; }
    }

    public class Half
    {
        public string half { get; set; }
        public List<object> events { get; set; }
    }

    public class Home2
    {
        public string name { get; set; }
        public string market { get; set; }
        public string id { get; set; }
        public object runs { get; set; }
    }

    public class Away2
    {
        public string name { get; set; }
        public string market { get; set; }
        public string id { get; set; }
        public int runs { get; set; }
    }

    public class Scoring2
    {
        public Home2 home { get; set; }
        public Away2 away { get; set; }
    }

    public class Innings
    {
        public int number { get; set; }
        public int sequence { get; set; }
        public List<Half> halfs { get; set; }
        public Scoring2 scoring { get; set; }
    }

    public class Game
    {
        public string id { get; set; }
        public string status { get; set; }
        public string coverage { get; set; }
        public int attendance { get; set; }
        public int game_number { get; set; }
        public string day_night { get; set; }
        public string scheduled { get; set; }
        public string home_team { get; set; }
        public string away_team { get; set; }
        public Venue venue { get; set; }
        public Broadcast broadcast { get; set; }
        public Scoring scoring { get; set; }
        public List<Innings> innings { get; set; }
    }

    public class RootObject
    {
        public Game game { get; set; }
    }

}