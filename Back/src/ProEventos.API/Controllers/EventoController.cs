using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{

    public EventoController(ILogger<EventoController> logger)
    {

    }

    public IEnumerable<Evento> _eventos = new Evento[]
        {
            new Evento()
              {
                 EventoId = 1,
                 Tema = "Angular 11 e .NET 7",
                 Local = "São Paulo",
                 Lote = "1º lote",
                 QtdPessoas = 250,
                 DataEvento = DateTime.Now.AddDays(2).ToString(),
                 ImagemURL = "foto.png"
              },
              new Evento()
              {
                 EventoId = 2,
                 Tema = "Angular e suas novidades",
                 Local = "Belo Horizonte",
                 Lote = "2º lote",
                 QtdPessoas = 350,
                 DataEvento = DateTime.Now.AddDays(2).ToString(),
                 ImagemURL = "foto.png"
              }
        };

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _eventos;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> Get(int id)
    {
        return _eventos.Where(a => a.EventoId == id);
    }

    [HttpPost]
    public string Post()
    {
        return "value";
    }

    [HttpPut("{id}")]
    public string Put(int id)
    {
        return $"exemplo de put com o id = {id}";
    }

    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        return $"exemplo de delete com o id = {id}";
    }
}
