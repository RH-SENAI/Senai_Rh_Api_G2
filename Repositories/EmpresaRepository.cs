using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {

        senaiRhContext ctx = new senaiRhContext();

        public List<Empresa> ListarTodos()
        {
            return ctx.Empresas
                    .Select(p => new Empresa
                    {
                        IdEmpresa = p.IdEmpresa,
                        IdLocalizacao = p.IdLocalizacao,
                        NomeEmpresa = p.NomeEmpresa,
                        EmailEmpresa = p.EmailEmpresa,
                        TelefoneEmpresa = p.TelefoneEmpresa,
                        CaminhoImagemEmpresa =p.CaminhoImagemEmpresa,
                        IdLocalizacaoNavigation = new Localizacao()
                        {
                            Numero = p.IdLocalizacaoNavigation.Numero,
                            IdLogradouroNavigation = new Logradouro()
                            {
                                NomeLogradouro = p.IdLocalizacaoNavigation.IdLogradouroNavigation.NomeLogradouro
                            },
                            IdEstadoNavigation = new Estado()
                            {
                                NomeEstado = p.IdLocalizacaoNavigation.IdEstadoNavigation.NomeEstado
                            }

                        }

                    })
                .ToList();
        }
    }
}
