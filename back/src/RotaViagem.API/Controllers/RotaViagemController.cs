using Microsoft.AspNetCore.Mvc;
using RotaViagem.Application.DTOs;
using RotaViagem.Application.Services.Interfaces;

namespace RotaViagem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RotaViagemController :  ControllerBase
{
    private readonly IRotaService _service;
   
    public RotaViagemController(IRotaService service)
    {
        _service = service;          
    }


    [HttpPost]
    [Route("criar-rota")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateRota([FromBody] RotaDto rota)
    {
        try
        {
            await _service.CreateAsync(rota);
            return Created();
        }
        catch (Exception ex)
        {

            return BadRequest(ex);
            throw;
        }
    }

    [HttpGet]
    [Route("pesquisar-rota/{origem}/{destino}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetRotaByOriginDestiny(string origem, string destino)
    {
        try
        {               
            return Ok(await _service.GetByOrginDestiny(origem, destino));
        }
        catch (Exception ex)
        {

            return BadRequest(ex);
            throw;
        }
    }

    [HttpPut]
    [Route("atualizar-rota")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateRota([FromBody] RotaDto rota)
    {
        try
        {
            return Ok(await _service.UpdateAsync(rota));
        }
        catch (Exception ex)
        {

            return BadRequest(ex);
            throw;
        }
    }

    [HttpDelete]
    [Route("deletar-rota/{id}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoveRota(int id)
    {
        try
        {
            await _service.RemoveAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {

            return BadRequest(ex);
            throw;
        }
    }
}
