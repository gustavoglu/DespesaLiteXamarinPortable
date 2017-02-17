using Despesa.Lite.Xamarin.Domain;
using Despesa.Lite.Xamarin.Portable.Aplicacao.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Util
{
    public class Utilidades
    {
       public static string RetornaStringSelecionadoPicker(Picker picker)
        {
            return picker.Items[picker.SelectedIndex];
        }

        public static async void CarregarClientes()
        {
             await WSOpen.GetClientes();
        }
    }
}
