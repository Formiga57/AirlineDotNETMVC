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
    public List<UsuárioVoo> ObterVoosAgendados(int idUsuário)
    {
        return _context.UsuáriosVoos.Where(u=>u.UsuárioFk == idUsuário)
            .Include(m=>m.Usuário)
            .Include(m=>m.Voo).ThenInclude(voo=>voo.Avião)
            .Include(m=>m.Voo).ThenInclude(voo=>voo.Origem)
            .Include(m=>m.Voo).ThenInclude(voo=>voo.Destino)
            .ToList();
    }
}