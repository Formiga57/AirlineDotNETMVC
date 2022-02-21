using DefaultNamespace;
using DotNETAPI.Contexts;
using DotNETAPI.Models.DbModels;

namespace DotNETAPI.Services;

public class SqlRepo : ISqlRepo
{
    private SqlContext _context;
    public SqlRepo(SqlContext context)
    {
        _context = context;
    }

    public void AddUser(string Nome)
    {
        throw new NotImplementedException();
    }
}