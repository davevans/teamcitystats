using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CommSec.Services.TeamCityStats.Core;
using CommSec.Services.TeamCityStats.Models;

namespace CommSec.Services.TeamCityStats.Controllers
{
    [RoutePrefix("api/v1/statistic")]
    public class StatisticController : ApiController
    {
        private readonly StatisticRepository _repository;

        public StatisticController(StatisticRepository repository)
        {
            _repository = repository;
        }


        [HttpPost]
        [Route("")]
        public HttpResponseMessage AddStatistic([FromBody]Statistic statistic)
        {
            try
            {
                var id = _repository.AddStatistic(statistic);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}