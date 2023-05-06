using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using FinalSoftware.Models;

namespace FinalSoftware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Candidato : ControllerBase
    {
        const string connectionString = "mongodb+srv://root:hola@finalsoftware.gqfaijh.mongodb.net/?retryWrites=true&w=majority";
        static MongoClient mongoClient = new MongoClient(connectionString);
        static IMongoDatabase database = mongoClient.GetDatabase("FinalSoftware");
        IMongoCollection<CandidatoInfo> candidatos = database.GetCollection<CandidatoInfo>("Candidatos");

        [HttpPost("crear")]
        public async Task<ActionResult<Candidato>> CrearCandidato(CandidatoInfo candidato)
        {
            var candidatoNuevo = new BsonDocument {
                {"DPI", candidato.DPI},
                {"Nombre", candidato.Nombre},
                {"Edad", candidato.Edad},
                {"Profesion", candidato.Profesion},
                {"Cargo", candidato.Cargo},
                {"Descripcion",candidato.Descripcion}
            };

            candidatos.InsertOne(candidato);
            return CreatedAtAction(nameof(CrearCandidato), new { id = candidato.DPI }, candidato);
        }
    }
}
