using SenaiRH_G2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Interfaces
{
    public interface ILocalizacaoRepository
    {

        List<Localizacao> ListarTodos();
        void ExcluirLocalizacao(int id);
        Localizacao BuscarPorId(int id);
        void CadastrarLocalizacao(Localizacao novoLocalizacao);

    }
}
