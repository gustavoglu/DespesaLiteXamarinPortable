namespace Despesa.Lite.Xamarin.Domain
{
    public class Despesa_Imagem : EntityBase
    {
        public string Descricao { get; set; } = "";

        public string imagem_link { get; set; } = "";

        public virtual Despesa Despesa { get; set; }
    }
}
