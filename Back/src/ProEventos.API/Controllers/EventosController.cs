﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        
        private readonly DataContext _context;

        public EventosController(DataContext context)
        {
            _context = context; 

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo de Postc";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete com id = {id}";
        }
    }
}





// public IEnumerable<Evento> _evento = new Evento[]
        // {
        //     new Evento()
        //     {
        //         EventoId = 1,
        //         Tema = "Angular 11 e .Net 5",
        //         Local = "Belo Horizonte",
        //         Lote = "1° Lote",
        //         QtdPessoas = 250,
        //         DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
        //         ImagemUrl = "Foto.png",
        //     },
        //     new Evento()
        //     {
        //         EventoId = 2,
        //         Tema = "Angular e suas novidades",
        //         Local = "São paulo",
        //         Lote = "2° Lote",
        //         QtdPessoas = 150,
        //         DataEvento = DateTime.Now.AddDays(0).ToString("dd/MM/yyyy"),
        //         ImagemUrl = "Foto444.png",
        //     },
        // };