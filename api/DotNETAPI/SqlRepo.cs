using DotNETAPI.Contexts;
using DotNETAPI.Models.DbModels;

namespace DefaultNamespace;

public class SqlRepo : ISqlRepo
{
    private readonly SqlContext _context;
    public SqlRepo(SqlContext context)
    {
        _context = context;
    }

    public void AddUser(string Nome)
    {
        Usuário novoUsuário = new()
        {
            Nome = Nome
        };
        _context.Usuários.Add(novoUsuário);
        _context.SaveChanges();
    }
}