using ProjetoCompAplicada.CSharp.Models;
using System.Collections.Generic;

namespace ProjetoCompAplicada.CSharp.Repositories
{
    public interface IServiceRepository
    {
        IEnumerable<Servico> GetAll();
        IEnumerable<Servico> GetByNome(string nome);
    }
}
