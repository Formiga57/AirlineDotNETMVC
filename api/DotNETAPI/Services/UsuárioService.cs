using DotNETAPI.Contexts;
using DotNETAPI.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DotNETAPI.Services;

public class UsuárioService : IUsuárioService
{
    public SqlContext _context;
    public UsuárioService(SqlContext context)
    {
        _context = context;
    }
    public int AdicionarUsuário(string nome, int idade, string hashSenha,string email)
    {
        Usuário usuário = new Usuário {Idade = idade, Milhas = 0, Nome = nome,HashSenha = hashSenha,Email = email};
        _context.Usuários.Add(usuário);
        _context.SaveChanges();
        return usuário.Id;
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

    public Usuário? EncontrarUsuário(string email)
    {
        return _context.Usuários.FirstOrDefault(u=>u.Email == email);
    }
}