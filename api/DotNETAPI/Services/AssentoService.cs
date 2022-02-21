using DotNETAPI.Contexts;
using DotNETAPI.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DotNETAPI.Services;

public class AssentoService
{
    public SqlContext _context;
    public AssentoService(SqlContext context)
    {
        _context = context;
    }

    public void ComprarAssento(int usuárioId,string nomeViajante,int voo,int seção, int fileira)
    {
        var assento = _context.Assentos
            .FirstOrDefault(a => a.VooFk == voo && a.Seção == seção && a.Fileira == fileira);
        if (assento == null)
        {
            Console.WriteLine("Tentativa de comprar um assento inexistente");
            return;
        }

        assento.NomeViajante = nomeViajante;
        assento.Reservado = true;
        assento.UsuárioFk = usuárioId;
        _context.SaveChanges();
    }
}