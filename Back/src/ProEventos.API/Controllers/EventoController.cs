using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    private readonly DataContext _context;

    public EventoController(ILogger<EventoController> logger, DataContext context)
    {
        _context = context;
    }

    

    [HttpGet]
    public List<Evento> Get()
    {
        return _context.Eventos.ToList();
    }

    [HttpGet("{id}")]
    public Evento Get(int id)
    {
        return _context.Eventos.FirstOrDefault(a => a.EventoId == id);
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
