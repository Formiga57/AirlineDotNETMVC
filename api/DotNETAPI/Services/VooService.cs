using DotNETAPI.Contexts;
using DotNETAPI.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DotNETAPI.Services;

public class VooService
{
    private char[] FileiraLetras = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O'};
    public SqlContext _context;
    public VooService(SqlContext context)
    {
        _context = context;
    }

    public void AdicionarVoo(int origemId,int destinoId,int aviãoId,string código,DateTime embarque)
    {
        Voo voo = new Voo {OrigemId = origemId, DestinoId = destinoId, AviãoFk = aviãoId, CódVoo = código, Embarque = embarque};
        _context.Voos.Add(voo);
        _context.SaveChanges();
        Avião avião = _context.Aviões.FirstOrDefault(a => a.Id == aviãoId);
        if (avião == null)
        {
            Console.WriteLine("Tentativa de adicionar um voo em avião não existente");
            return;
        }
        for (int i = 1; i <= avião.Seções; i++)
        {
            for (int j = 0; j <= avião.Fileiras; j++)
            {
                Assento assento = new Assento{Fileira = FileiraLetras[j],Seção = i,VooFk = voo.Id};
                _context.Assentos.Add(assento);
            }
        }
        _context.SaveChanges();
    }
}