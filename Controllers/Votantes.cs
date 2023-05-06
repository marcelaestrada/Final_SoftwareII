using FinalSoftware.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSoftware.Controllers
{
    public class Votantes : Controller
    {
        const string connectionString = "mongodb+srv://root:hola@finalsoftware.gqfaijh.mongodb.net/?retryWrites=true&w=majority";
        static MongoClient mongoClient = new MongoClient(connectionString);
        static IMongoDatabase database = mongoClient.GetDatabase("FinalSoftware");
        IMongoCollection<VotanteInfo> votantes = database.GetCollection<VotanteInfo>("Votantes");

        [HttpPost("nuevoVoto")]
        public void nuevoVoto(VotanteInfo Votante)
        {
            var candidatoNuevo = new BsonDocument {
                {"DPI", Votante.DPI},
                {"Nombre", Votante.Nombre},
                {"Direccion", Votante.Direccion},
                {"Hora", Votante.Hora},
                {"Fecha", Votante.Fecha},
                {"IP", Votante.IP}
            };

            votantes.InsertOne(Votante);
        }
    }
}
}
