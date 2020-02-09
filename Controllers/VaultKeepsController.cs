using System;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }
    [HttpGet("{id}")]
    public ActionResult<VaultKeep> Get(int id)
    {
      try
      {
        return Ok(_vks.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }
    [HttpPost]
    [Authorize]
    public ActionResult<VaultKeep> Post([FromBody] VaultKeep newVaultKeep)
    {
      try
      {
        return Ok(_vks.Create(newVaultKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        return Ok(_vks.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}