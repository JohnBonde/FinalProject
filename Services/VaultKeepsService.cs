using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }
    
    internal VaultKeep GetById(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }
    internal VaultKeep GetByVaultId(int id, int vaultId)
    {
      var exists = _repo.GetByVaultId(id, vaultId);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }
    internal VaultKeep Create(VaultKeep newVaultKeep)
    {
      return _repo.Create(newVaultKeep);
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