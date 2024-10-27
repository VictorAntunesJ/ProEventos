﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain;
using ProEventos.Application.Contratos;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Controllers
{
    /// <summary>
    /// Controller para gerenciar operações relacionadas a eventos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="EventosController"/> com o serviço de eventos especificado.
        /// </summary>
        /// <param name="eventoService">Instância de <see cref="IEventoService"/> utilizada para manipular os dados dos eventos.</param>
        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        /// <summary>
        /// Obtém todos os eventos.
        /// </summary>
        /// <returns>Retorna a lista de eventos ou uma mensagem de erro, caso nenhum evento seja encontrado.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var evento = await _eventoService.GetAllEventosAsync(true);
                if (evento == null) return NotFound("Nenhum evento encontrado.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtém um evento pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único do evento.</param>
        /// <returns>Retorna o evento correspondente ao ID ou uma mensagem de erro, caso não seja encontrado.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id, true);
                if (evento == null) return NotFound("Evento por Id não encontrado.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtém eventos com base no tema especificado.
        /// </summary>
        /// <param name="tema">Tema do evento.</param>
        /// <returns>Retorna a lista de eventos correspondentes ao tema ou uma mensagem de erro, caso nenhum evento seja encontrado.</returns>
        [HttpGet("tema: /{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
                if (evento == null) return NotFound("Eventos por tema não encontrados.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar temas. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Adiciona um novo evento.
        /// </summary>
        /// <param name="model">Dados do evento a ser adicionado.</param>
        /// <returns>Retorna o evento criado ou uma mensagem de erro caso ocorra algum problema.</returns>
        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var evento = await _eventoService.AddEvento(model);
                if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar temas. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza um evento existente.
        /// </summary>
        /// <param name="id">Identificador único do evento a ser atualizado.</param>
        /// <param name="model">Dados atualizados do evento.</param>
        /// <returns>Retorna o evento atualizado ou uma mensagem de erro caso ocorra algum problema.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = await _eventoService.UpDateEvento(id, model);
                if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar temas. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Deleta um evento pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único do evento a ser deletado.</param>
        /// <returns>Retorna uma mensagem de sucesso caso o evento seja deletado ou uma mensagem de erro caso não seja possível deletá-lo.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return (await _eventoService.DeleteEvento(id)) ?
                        Ok("Deletado") :
                        BadRequest("Evento não Deletado.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar temas. Erro: {ex.Message}");
            }
        }
    }

}