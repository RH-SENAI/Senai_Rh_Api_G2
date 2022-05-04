using SenaiRH_G2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Interfaces
{
    public interface IComentarioDescontoRepository
    {
        List<Comentariodesconto> ListarComenatarioDesconto();
        void CadastrarComentarioDesconto(Comentariodesconto NovoComentario);
        Comentariodesconto ListarComentarioPorIdDesconto(int Id);
        void ExcluirComentarioDesconto(int Id);

    }
}
