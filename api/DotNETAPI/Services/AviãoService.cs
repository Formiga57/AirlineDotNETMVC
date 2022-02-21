using DotNETAPI.Contexts;
using DotNETAPI.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DotNETAPI.Services;

public class AviãoService
{
    public SqlContext _context;
    public AviãoService(SqlContext context)
    {
        _context = context;
    }

    public void AdicionarAvião(string código,int Seções, int fileiras)
    {
        Avião avião = new Avião {Cód = código, Seções = Seções, Fileiras = fileiras};
        _context.Aviões.Add(avião);
        _context.SaveChanges();
    }
}