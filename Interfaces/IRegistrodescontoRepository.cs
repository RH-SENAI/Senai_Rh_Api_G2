using SenaiRH_G2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Interfaces
{
    public interface IRegistrodescontoRepository
    {

        List<Registrodesconto> ListarTodos();
        void ExcluirRegistrodesconto(int id);
        Registrodesconto BuscarPorId(int id);
        void CadastrarRegistrodesconto(Registrodesconto novoRegistrodesconto);
        Registrodesconto BuscarSaldoPorId(int id);
        Registrodesconto BuscarValorPorId(int id);
        void AlterarSaldoUsuario(int id, Registrodesconto saldoAtualizar);



    }
}
