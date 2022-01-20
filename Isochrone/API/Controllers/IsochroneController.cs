using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("Isochrone")]
    [ApiController]
    public class IsochroneController : ControllerBase
    {

        public static DateTime heureArriveMax;
        public static DateTime dateHeureDepart;
        public static List<Point> pointsIsochrone = new List<Point>();
        // GET: api/<IsochroneController>
        [HttpGet]
      
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" }; //Utile à garder pour les test
        }

        // GET isochrone/1/?latitude=4.44992&longitude=2.3344
        [HttpGet("{id}")]
        public string Get(double latitude, double longitude, string arriveMax)
        {
            
           
            string p_Stop_Id = Point.GetStopID(latitude, longitude);
            dateHeureDepart = DateTime.Now;
            Controllers.IsochroneController.heureArriveMax = new DateTime(Convert.ToInt32(arriveMax.Substring(0, 4)),
                Convert.ToInt32(arriveMax.Substring(5, 2)),
                Convert.ToInt32(arriveMax.Substring(8, 2)),
                Convert.ToInt32(arriveMax.Substring(11, 2)),
                Convert.ToInt32(arriveMax.Substring(14, 2)),
                00);
            
            //on déclare notre point de base
            Point p = new Point("StopPoint:OCETGV INOUI-87113001", dateHeureDepart.TimeOfDay, 0.0, 0.0);


            return JsonConvert.SerializeObject(Controllers.IsochroneController.pointsIsochrone);

            
        }


    }
}
