using DotNETAPI.Contexts;
using DotNETAPI.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DotNETAPI.Services;

public class UsuárioService
{
    public SqlContext _context;
    public UsuárioService(SqlContext context)
    {
        _context = context;
    }

    public void AdicionarUsuário(string nome, int idade, float milhas)
    {
        Usuário usuário = new Usuário {Idade = idade, Milhas = milhas, Nome = nome};
        _context.Usuários.Add(usuário);
        _context.SaveChanges();
    }
    public List<Assento> ObterVoosAgendados(int idUsuário)
    {
        return _context.Assentos.Where(a => a.UsuárioFk == idUsuário)
            .Include(a => a.Voo)
            .Include(a => a.Voo.Avião)
            .Include(a => a.Voo.Origem)
            .Include(a => a.Voo.Destino)
            .Include(a => a.Usuário)
            .ToList();
    }
}