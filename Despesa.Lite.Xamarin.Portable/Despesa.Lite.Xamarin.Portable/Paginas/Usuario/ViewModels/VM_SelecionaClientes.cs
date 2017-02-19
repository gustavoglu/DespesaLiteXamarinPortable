using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Usuario.ViewModels
{
    public class VM_SelecionaClientes : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Domain.Cliente _cliente;

        private Color corClienteNome;

        public Color CorClienteNome
        {
            get { return corClienteNome; }
            set { corClienteNome = value; }
        }


        private Color corSelecionado;

        public Color CorSelecionado
        {
            get { return corSelecionado; }
            set
            {
                corSelecionado = value;

            }
        }


        private string clienteNome;

        public string ClienteNome
        {
            get { return this._cliente.Nome; }
            //set { clienteNome = value; }
        }

        private bool selecionado;

        public bool Selecionado
        {
            get { return selecionado; }
            set
            {
                selecionado = value;

                if (value)
                {
                    this.CorSelecionado = Color.Lime;
                    this.CorClienteNome = Color.White;
                }
                else
                {
                    this.CorSelecionado = Color.Default;
                    this.CorClienteNome = Color.Default;
                }

                Notify(nameof(CorSelecionado));
                Notify(nameof(CorClienteNome));
            }
        }

        public VM_SelecionaClientes(Domain.Cliente cliente)
        {
            _cliente = cliente;
        }

        public void Notify(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }


    }
}
