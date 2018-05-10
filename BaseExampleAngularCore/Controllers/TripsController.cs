using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BaseExampleAngularCore.Models;
using RepositoryCommon;
using DataAccess.Data;
using AutoMapper;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;

namespace BaseExampleAngularCore.Controllers
{
    [Produces("application/json")]  
    [Route("api/[controller]/[action]")]
    //[EnableCors("AllowAnyOrigin")]
    [AllowAnonymous]
    public class TripsController : Controller
    {
        private IRepository repository;
        private readonly IMapper mapper;

        public TripsController(IRepository repo, IMapper mapper)
        {
            repository = repo;
            this.mapper = mapper;
        }

        // GET: api/Trips
        [HttpGet]
        public JsonResult GetTrips()
        {
            var model = mapper.Map<List<Trip>, List<TripModel>>(repository.GetAllTrips());

            return Json(model);
        }

        [HttpPost]
        public void AddTrip([FromBody]TripModel value)
        {
            var tripModel = mapper.Map<TripModel, Trip>(value);

            List<Asset> assets = new List<Asset>();

            value.Assets.ToList().ForEach(x => assets.Add(new Asset() {AssetValue = x}));

            tripModel.Assets = assets;

            repository.AddTrip(tripModel);
        }
    }
}
