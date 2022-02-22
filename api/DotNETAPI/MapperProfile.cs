using AutoMapper;
using DotNETAPI.Models.DbModels;
using DotNETAPI.Models.PostModels;

namespace DotNETAPI;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Usuário,UsuárioInfos>();
    }
}