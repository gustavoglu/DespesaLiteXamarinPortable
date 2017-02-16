using System;

namespace Despesa.Lite.Xamarin.Domain
{
    public class Despesa_Imagem : EntityBase
    {
        public Guid? id_despesa{ get; set; }

        public string Descricao { get; set; } = "";

        public string imagem_link { get; set; } = "";

    }
}
