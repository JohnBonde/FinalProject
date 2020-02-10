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
    internal IEnumerable<Keep> GetByVaultId(int vaultId, string userId)
    {
      var exists = _repo.GetByVaultId(vaultId, userId);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }
    internal VaultKeep Create(VaultKeep newVaultKeep)
    {
      return _repo.Create(newVaultKeep);
    }
    internal string Delete(string userId, int vaultId, int keepId)
    {
      _repo.Delete(vaultId, keepId, userId);
      return "Successfully Deleted";
    }

  }
}