﻿using SenaiRH_G2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Interfaces
{
    public interface IBairroRepository
    {

        List<Bairro> ListarTodos();
        void ExcluirBairro(int id);
        Bairro BuscarPorId(int id);
        void CadastrarBairro(Bairro novoBairro);

    }
}
