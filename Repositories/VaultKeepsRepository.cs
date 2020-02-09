using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal VaultKeep GetById(int Id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @id";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { Id });
    }

    internal VaultKeep Create(VaultKeep vaultKeepData)
    {
      string sql = @"
        INSERT INTO vaultkeeps
        (vaultId, keepId) 
        VALUES 
        (@VaultId, @KeepId);
        SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, vaultKeepData);
      vaultKeepData.Id = id;
      return vaultKeepData;
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @Id";
      _db.Execute(sql, new { id });
    }

  }
}