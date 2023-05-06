using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaVotos_FinalSoftware.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace SistemaVotos_FinalSoftware.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static readonly HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CrearCandidato(CandidatoInfo candidato)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> nuevoCandidatoAsync(CandidatoInfo candidato)
        {
            string jsonCandidato = JsonSerializer.Serialize(candidato);
            var content = new StringContent(jsonCandidato, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://localhost:44347/api/Candidato/crear", content);


            return View("Index");
        }
    }
}
