using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Vault> GetByUserId(string userId)
    {
      var exists = _repo.GetByUserId(userId);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }
    internal Vault GetById(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }
    internal Vault Create(Vault newVault)
    {
      return _repo.Create(newVault);
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