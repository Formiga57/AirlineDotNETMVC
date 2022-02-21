using DotNETAPI.Models.DbModels;

namespace DotNETAPI.Services;

public interface IUsuárioService
{
    public int AdicionarUsuário(string nome, int idade,string hashSenha,string email);
    public List<Assento> ObterVoosAgendados(int idUsuário);
    public Usuário? EncontrarUsuário(string email);
}