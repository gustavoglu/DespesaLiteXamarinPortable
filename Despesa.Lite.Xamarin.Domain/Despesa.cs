using System;
using System.Collections.Generic;

namespace Despesa.Lite.Xamarin.Domain
{
    public class Despesa : EntityBase
    {
        public Guid? id_visita { get; set; }

        public int Quilometragem { get; set; }

        public double Pedagio { get; set; }

        public double Refeicao { get; set; }

        public double Outros { get; set; }

        public string Detalhes { get; set; }

        public virtual ICollection<Despesa_Imagem> Despesa_Imagens { get; set; }

        public virtual Visita Visita{ get; set; }
    }
}
