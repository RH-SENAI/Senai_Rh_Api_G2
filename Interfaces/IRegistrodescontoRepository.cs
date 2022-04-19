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
        int BuscarSaldo(int id);
        int BuscarValor(int id);
        void AlterarSaldoUsuario(int id, Usuario novoSaldoAtualizar);



    }
}
