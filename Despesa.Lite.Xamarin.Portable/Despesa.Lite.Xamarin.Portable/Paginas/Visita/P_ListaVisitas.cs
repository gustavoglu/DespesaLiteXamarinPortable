using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Visita
{
    public class P_ListaVisitas : ContentPage
    {
        protected StackLayout sl_principal;
        protected ListView listV_visitas;
        protected ToolbarItem ti_adicionar;
        protected ObservableCollection<Domain.Visita> Visitas;

        public P_ListaVisitas()
        {
            Title = "Visitas";

            Visitas = new ObservableCollection<Domain.Visita>();

            listV_visitas = new ListView()
            {
                ItemsSource = Visitas,
                HasUnevenRows = true,
            };

            listV_visitas.ItemTapped += ListV_visitas_ItemTapped;



            sl_principal = new StackLayout() { Children = { listV_visitas } };
            this.ToolbarItems.Add(ti_adicionar);
            this.Content = sl_principal;
        }

        private void ListV_visitas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
