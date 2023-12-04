using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Persistence.Contexts;
using ProEventos.Domain.Models;
using ProEventos.Application.Interfaces;
using System.Collections;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{

    private readonly IEventoService _eventoService;

    public EventosController(ILogger<EventosController> logger, IEventoService eventoService)
    {
        _eventoService = eventoService;
    }


    // [EnableCors]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var eventos = _eventoService.GetAllEventosAsync();
            if (eventos is null) return NotFound();

            return Ok(eventos);
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro : {ex.Message}");
        }
    }

    // [EnableCors]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var evento = _eventoService.GetEventoByIdAsync(id);
            if (evento is null) return NotFound("Nenhum evento encontrado.");

            return Ok(evento);
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar evento por ID. Erro : {ex.Message}");
        }
    }

    // [EnableCors]
    [HttpGet("{tema}/tema")]
    public async Task<IActionResult> GetByTema(string tema)
    {
        try
        {
            var eventos = _eventoService.GetAllEventosByTemaAsync(tema);
            if (eventos is null) return NotFound("Nenhum evento encontrado.");

            return Ok(eventos);
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar evento por tema. Erro : {ex.Message}");
        }
    }

    // [EnableCors]
    [HttpPost]
    public async Task<IActionResult> AddEvento(Evento model)
    {
        try
        {
            var eventos = _eventoService.AddEventos(model);
            if (eventos is null) return BadRequest("Erro ao tentar adicionar evento.");

            return Ok(eventos);
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar evento. Erro : {ex.Message}");
        }
    }

    // [EnableCors]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvento(int id, Evento model)
    {
        try
        {
            var eventos = _eventoService.UpdateEvento(id, model);
            if (eventos is null) return BadRequest("Erro ao tentar atualizar evento.");

            return Ok(eventos);
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar evento. Erro : {ex.Message}");
        }
    }

    // [EnableCors]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvento(int id)
    {
        try
        {
            return await _eventoService.DeleteEvento(id) ? Ok("Deletado") : BadRequest("Evento não deletado");
        }
        catch (System.Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar evento. Erro : {ex.Message}");
        }
    }
}
