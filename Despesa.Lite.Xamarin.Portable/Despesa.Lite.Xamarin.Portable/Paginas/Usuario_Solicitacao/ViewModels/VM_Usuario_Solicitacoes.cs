using System.ComponentModel;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Usuario_Solicitacao.ViewModels
{
    public class VM_Usuario_Solicitacoes : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Domain.Usuario_Solicitacao _usuarioSolicitacao;

        private string companhiaNome;

        public string CompanhiaNome
        {
            get { return _usuarioSolicitacao.Companhia.Nome; }
            set { companhiaNome = value; }
        }

        private string usuarioNome;

        public string UsuarioNome
        {
            get { return _usuarioSolicitacao.Usuario.Nome; }
            set { usuarioNome = value; }
        }

        private string status;

        public string Status
        {
            get
            {
                if (_usuarioSolicitacao.Status == 0)
                {
                    return "Aguardando";
                }
                else if (_usuarioSolicitacao.Status == 1)
                {
                    return "Solicitação Aceita";
                }
                else
                {
                    return "Solicitação Recusada";
                }
            }
            set
            {
                status = value;
                Notify(nameof(this.Status));
                Notify(nameof(this.CorStatus));
            }
        }

        private Color corStatus;

        public Color CorStatus
        {
            get
            {
                if (_usuarioSolicitacao.Status == 0)
                {
                    return Color.Blue;
                }
                else if (_usuarioSolicitacao.Status == 1)
                {
                    return Color.Green;
                }
                else
                {
                    return Color.Red;
                }
            }
            set { corStatus = value; }
        }

        public VM_Usuario_Solicitacoes(Domain.Usuario_Solicitacao usuario_Solicitacao)
        {
            this._usuarioSolicitacao = usuario_Solicitacao;
        }

        void Notify(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }


    }

}
