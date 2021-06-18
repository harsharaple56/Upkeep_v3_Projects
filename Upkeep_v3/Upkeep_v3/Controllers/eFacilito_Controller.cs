using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Http;
//using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using Upkeep_v3.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Upkeep_v3.Controllers
{
    //public class eFacilito_Controller : ApiController
    //{

    //    //[Route("api/Dashboard/Fetch_Ticket_Dashboard_Count")]
    //    //[HttpGet]
    //    //public HttpResponseMessage Fetch_Sessions(int SessionCount)
    //    //{
    //    //    List<Fetch_Sessions> objsessions = new List<Fetch_Sessions>();

    //    //    try
    //    //    {
    //    //        objsessions = (from p in DsDataSet.Tables[0].AsEnumerable()
    //    //                        select new Fetch_Sessions
    //    //                        {
    //    //                            AvailableDeptChk = Convert.ToString(Application["SessionCount"]);
    //    //                        }).ToList();

    //    //        return Request.CreateResponse(HttpStatusCode.OK, objsessions);
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        throw new Exception(ex.Message);
    //    //    }
    //    //}

    //    // GET api/<controller>
    //    public IEnumerable<string> Get()
    //    {
    //        return new string[] { "value1", "value2" };
    //    }

    //    // GET api/<controller>/5
    //    public string Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST api/<controller>
    //    public void Post([FromBody]string value)
    //    {
    //    }

    //    // PUT api/<controller>/5
    //    public void Put(int id, [FromBody]string value)
    //    {
    //    }

    //    // DELETE api/<controller>/5
    //    public void Delete(int id)
    //    {
    //    }

        



   // }
}