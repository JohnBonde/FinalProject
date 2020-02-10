using System.Data;
using Keepr.Models;
using Dapper;
using System.Collections.Generic;
using System;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Keep> GetByVaultId(int vaultId, string userId)
    {
      string sql = @"SELECT k.* FROM vaultkeeps vk
        INNER JOIN keeps k ON k.id = vk.keepId 
        WHERE (vaultId = @VaultId AND vk.userId = @UserId)";
      return _db.Query<Keep>(sql, new { vaultId, userId });
    }
    internal VaultKeep Create(VaultKeep vaultKeepData)
    {
      string sql = @"
        INSERT INTO vaultkeeps
        (vaultId, keepId, userId) 
        VALUES 
        (@VaultId, @KeepId, @UserId);
        SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, vaultKeepData);
      vaultKeepData.Id = id;
      return vaultKeepData;
    }
    internal void Delete(int vaultId, int keepId, string userId)
    {
      string sql = "DELETE FROM vaultkeeps WHERE (vaultId = @VaultId AND keepId = @KeepId AND userId = @UserId)";
      int failed = _db.Execute(sql, new { vaultId, keepId, userId });
      if (failed == 0) { throw new Exception("Relationship does not exist."); }
    }

  }
}