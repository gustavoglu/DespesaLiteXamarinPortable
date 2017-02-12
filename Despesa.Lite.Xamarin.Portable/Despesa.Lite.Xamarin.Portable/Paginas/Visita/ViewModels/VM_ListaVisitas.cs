using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Visita.ViewModels
{
    public class VM_ListaVisitas
    {
        public ObservableCollection<Domain.Visita> Visitas { get; set; }

        public VM_ListaVisitas()
        {
                
        }
    }
}
