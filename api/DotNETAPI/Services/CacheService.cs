using DotNETAPI.Contexts;
using DotNETAPI.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DotNETAPI.Services;

public interface ICacheService
{
    public Dictionary<int, string> ObterAeroportos(bool refresh);
}

public class CacheService : ICacheService
{
    private Dictionary<int, string> Aeroportos = new();
    private bool PrimeiraExecução = false;
    public SqlContext _context;
    public CacheService(SqlContext context)
    {
        _context = context;
    }
    public Dictionary<int, string> ObterAeroportos(bool refresh)
    {
        if (refresh || !PrimeiraExecução)
        {
            PrimeiraExecução = false;
            Aeroportos.Clear();
            foreach (Aeroporto aeroporto in _context.Aeroportos.ToList())
            {
                Aeroportos.Add(aeroporto.Id,$"{aeroporto.Cód} - {aeroporto.Nome}");
            }
        }
        return Aeroportos;
    }
}