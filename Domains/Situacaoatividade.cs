using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G2.Domains
{
    public partial class Situacaoatividade
    {
        public Situacaoatividade()
        {
            Minhasatividades = new HashSet<Minhasatividade>();
        }

        public byte IdSituacaoAtividade { get; set; }
        public string NomeSituacaoAtividade { get; set; }

        public virtual ICollection<Minhasatividade> Minhasatividades { get; set; }
    }
}
