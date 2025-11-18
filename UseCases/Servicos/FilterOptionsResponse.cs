using System.Collections.Generic;

namespace ProjetoCompAplicada.CSharp.UseCases.Servicos
{
    public class FilterOptionsResponse
    {
        public List<string> Categories { get; set; } = new();
        public List<string> Cities { get; set; } = new();
        public List<string> States { get; set; } = new();
    }
}
