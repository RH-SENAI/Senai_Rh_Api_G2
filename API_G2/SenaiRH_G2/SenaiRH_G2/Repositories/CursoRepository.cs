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
    public class CursoRepository : ICursoRepository
    {

        senaiRhContext ctx = new senaiRhContext();

        public Curso BuscarPorId(int id)
        {
            return ctx.Cursos.FirstOrDefault(c => c.IdCurso == id);
        }

        public void CadastrarCurso(CursoCadastroViewModel novoCurso)
        {

            Curso curso = new Curso()
            {
                IdEmpresa = novoCurso.IdEmpresa,
                NomeCurso = novoCurso.NomeCurso,
                DescricaoCurso = novoCurso.DescricaoCurso,
                SiteCurso = novoCurso.SiteCurso,
                ModalidadeCurso = novoCurso.ModalidadeCurso,
                CaminhoImagemCurso = novoCurso.CaminhoImagemCurso,
                CargaHoraria = novoCurso.CargaHoraria,
                DataFinalizacao = novoCurso.DataFinalizacao,
                MediaAvaliacaoCurso = novoCurso.MediaAvaliacaoCurso
            };

            ctx.Cursos.Add(curso);
            ctx.SaveChanges();
            
        }

        public void ExcluirCurso(int id)
        {
            Curso buscarPorId = ctx.Cursos.FirstOrDefault(c => c.IdCurso == id);
            ctx.Cursos.Remove(buscarPorId);
            ctx.SaveChanges();
        }


        public List<Curso> ListarTodos()
        {
            return ctx.Cursos
                    .Select(p => new Curso
                {
                    IdCurso = p.IdCurso,
                    IdEmpresa = p.IdEmpresa,
                    NomeCurso = p.NomeCurso,
                    DescricaoCurso = p.DescricaoCurso,
                    SiteCurso = p.SiteCurso,
                    ModalidadeCurso = p.ModalidadeCurso,
                    CaminhoImagemCurso = p.CaminhoImagemCurso,
                    CargaHoraria = p.CargaHoraria,
                    DataFinalizacao = p.DataFinalizacao,
                    MediaAvaliacaoCurso = p.MediaAvaliacaoCurso,
                    IdEmpresaNavigation = new Empresa()
                    {

                        NomeEmpresa = p.IdEmpresaNavigation.NomeEmpresa,
                        EmailEmpresa = p.IdEmpresaNavigation.EmailEmpresa,
                        TelefoneEmpresa = p.IdEmpresaNavigation.TelefoneEmpresa,
                        IdLocalizacaoNavigation = new Localizacao()
                        {
                            Numero = p.IdEmpresaNavigation.IdLocalizacaoNavigation.Numero,
                            IdLogradouroNavigation = new Logradouro()
                            {
                                NomeLogradouro = p.IdEmpresaNavigation.IdLocalizacaoNavigation.IdLogradouroNavigation.NomeLogradouro
                            },
                            IdEstadoNavigation = new Estado()
                            {
                                NomeEstado = p.IdEmpresaNavigation.IdLocalizacaoNavigation.IdEstadoNavigation.NomeEstado
                            }

                        }


                    }

                    
                })
                .ToList();
        }
    }
}
