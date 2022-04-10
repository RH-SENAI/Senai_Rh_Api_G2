using SenaiRH_G2.Contexts;
using SenaiRH_G2.Domains;
using SenaiRH_G2.Interfaces;
using SenaiRH_G2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G2.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {

        senaiRhContext ctx = new senaiRhContext();

        public Empresa BuscarPorId(int id)
        {
            return ctx.Empresas.FirstOrDefault(c => c.IdEmpresa == id);
        }

        public void CadastrarEmpresa(EmpresaCadastroViewModel novoEmpresa)
        {
            Empresa empresa = new Empresa()
            {

                IdLocalizacao = novoEmpresa.IdLocalizacao,
                NomeEmpresa = novoEmpresa.NomeEmpresa,
                EmailEmpresa = novoEmpresa.EmailEmpresa,
                TelefoneEmpresa = novoEmpresa.TelefoneEmpresa,
                CaminhoImagemEmpresa = novoEmpresa.CaminhoImagemEmpresa,

            };

            ctx.Empresas.Add(empresa);
            ctx.SaveChanges();
        }

        public void ExcluirEmpresa(int id)
        {
            Empresa buscarPorId = ctx.Empresas.FirstOrDefault(c => c.IdEmpresa == id);
            ctx.Empresas.Remove(buscarPorId);
            ctx.SaveChanges();
        }


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
                        CaminhoImagemEmpresa = p.CaminhoImagemEmpresa,
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
