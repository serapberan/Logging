using LoggingProject.DAL;
using LoggingProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {

            _logger.LogInformation("Home/Index sayfasına erişim sağlandı");
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i==5)
                    {
                         throw new Exception("Eşitlik Sağlandı" );
                    }
                    else
                    {
                        _logger.LogInformation("Sayı Değeri: {iValue}",i);
                    }
                }
               
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, " Hatayı yakaladık! ");
            }
            return View();
        }

      
            public IActionResult Privacy()
        {
            var user = new User   
            {
                UserId=1,
                Name= " Marty",
                Surname= "McFly",
                Age="30",
                Description= "Geleceğe Dönüş"
            };

           
            _logger.LogError( "Kullanıcı hatası: {@user}", user);//Serilog sayesinde User nesnesini loglaya bildik
        
            _logger.LogInformation("Home/Privacy sayfasındasın!");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
    }
}
