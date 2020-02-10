using System;
using System.Collections.Generic;
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
    internal Keep GetById(int id, string userId)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      if (exists.IsPrivate == true && exists.UserId != userId) { throw new Exception("This post is private and cannot be viewed"); }
      return exists;
    }
    internal Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }
    internal Keep Edit(Keep update)
    {
      Keep exists = _repo.GetById(update.Id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      if (exists.UserId != update.UserId)
      {
        throw new Exception("You don't have the required permissions to perform this task");
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
        throw new Exception("You don't have the required permissions to perform this task");
      }
      _repo.Delete(id);
      return "Successfully Deleted";
    }

  }
}