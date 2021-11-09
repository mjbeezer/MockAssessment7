using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockAssessment7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockAssessment7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamingController : ControllerBase
    {
        GameDB DB = new GameDB();

        [HttpGet ("getAll")]
        public List<Player> allPlayers()
        {
            List<Player> Players = DB.Players.ToList();
            return Players;
            //return GameDB
        }

        [HttpGet("getClasses")]
        public List<PlayerClass> allClasses()
        {
            List<PlayerClass> Classes = DB.PlayerClasses.ToList();
            return Classes;
        }

        [HttpGet("minLevel/{level}")]
        public List<Player> minLevels(int level)
        {
            List<Player> minLevel = DB.Players.Where(p => p.Level <= level).ToList();
            return minLevel;
        }

        [HttpGet("sortLevel")]
        public List<Player> sortLevel()
        {
            List<Player> sortLevel = DB.Players.OrderByDescending(p => p.Level).ToList();
            return sortLevel;
        }

        [HttpGet("playersOfClass/{pclass}")]
        public List<Player> playersOfClass(int pclass)
        {
            List<Player> classPlayer = DB.Players.FindAll(p => p.CurrentClass.ID == pclass).ToList();
            return classPlayer;
        }

        [HttpGet("playersOfType/{ptype}")]
        public List<Player> playersOfType(string ptype)
        {
            List<Player> typePlayer = DB.Players.FindAll(p => p.CurrentClass.Type == ptype).ToList();
            return typePlayer;
        }

        [HttpGet("allPlayedClasses")]
        public List<PlayerClass> allPlayedClasses()
        {
            List<PlayerClass> allPlayedClasses = DB.Players.Select(p => p.CurrentClass).Distinct().ToList();
            return allPlayedClasses;
        }
    }
}
