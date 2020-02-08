using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }
    internal Keep GetById(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }
    internal Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }
    internal Keep Edit(Keep update)
    {
      Keep exists = _repo.GetById(update.Id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Edit(update);
      return update;
    }
    internal string Delete(string userId, int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      if (exists.UserId != userId)
      {
        throw new Exception("I can't let you do that");
      }
      _repo.Delete(id);
      return "Successfully Deleted";
    }

  }
}