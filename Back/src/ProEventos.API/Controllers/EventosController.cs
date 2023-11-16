using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private readonly DataContext _context;

    public EventosController(ILogger<EventosController> logger, DataContext context)
    {
        _context = context;
    }


    [EnableCors]
    [HttpGet]
    public List<Evento> Get()
    {
        return _context.Eventos.ToList();
    }

    [EnableCors]
    [HttpGet("{id}")]
    public Evento Get(int id)
    {
        return _context.Eventos.FirstOrDefault(a => a.EventoId == id);
    }

    [EnableCors]
    [HttpPost]
    public string Post()
    {
        return "value";
    }

    [EnableCors]
    [HttpPut("{id}")]
    public string Put(int id)
    {
        return $"exemplo de put com o id = {id}";
    }

    [EnableCors]
    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        return $"exemplo de delete com o id = {id}";
    }
}
