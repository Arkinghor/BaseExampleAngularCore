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
using System.IO;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;

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
        private IHostingEnvironment _hostingEnvironment;

        public TripsController(IRepository repo, IMapper mapper, 
            IHostingEnvironment hostingEnvironment)
        {
            repository = repo;
            this.mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
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

        [HttpPost, DisableRequestSizeLimit]
        public ActionResult UploadFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                string folderName = "Upload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                return Json("Upload Successful.");
            }
            catch (System.Exception ex)
            {
                return Json("Upload Failed: " + ex.Message);
            }

        }
    }
}
