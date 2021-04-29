using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            Classes = new HashSet<Class>();
        }

        public int IdHabilidade { get; set; }
        public int? IdTipoDeHabilidade { get; set; }
        public string Habilidade1 { get; set; }

        public virtual TipoDeHabilidade IdTipoDeHabilidadeNavigation { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
