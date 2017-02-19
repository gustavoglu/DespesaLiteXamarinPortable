using Despesa.Lite.Xamarin.Domain;
using Despesa.Lite.Xamarin.Portable.Aplicacao;
using Despesa.Lite.Xamarin.Portable.Aplicacao.WebService;
using Despesa.Lite.Xamarin.Portable.Paginas.Despesa;
using Despesa.Lite.Xamarin.Portable.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Visita
{
    public class P_NovaVisita : ContentPage
    {
        StackLayout sl_principal;
        StackLayout sl_chegada_hori;
        StackLayout sl_saida_hori;

        ScrollView scr_principal;

        Button b_chegada;
        Button b_saida;

        Label l_data;
        Label l_horaChegada;
        Label l_horaSaida;
        Label l_tempoImprodutivo;
        Label l_observacoes;
        Label l_cliente;

        DatePicker dp_data;
        TimePicker tp_horaChegada;
        TimePicker tp_horaSaida;
        Picker p_tempoImprodutivo;
        Editor ed_observacoes;
        Picker p_cliente;

        ToolbarItem ti_despesas;
        ToolbarItem ti_confirmar;

        P_NovaDespesa Page_NovaDespesa;

        List<Domain.Despesa> list_despesas;

        public P_NovaVisita()
        {
            Title = "Nova Visita";

            Page_NovaDespesa = new P_NovaDespesa();
            Page_NovaDespesa.Envia += Page_NovaDespesa_Envia;

            l_data = new Label() { Text = "Data" };
            l_horaChegada = new Label() { Text = "Hora Chegada" }; ;
            l_horaSaida = new Label() { Text = "Hora Saída" };
            l_tempoImprodutivo = new Label() { Text = "Tempo Improdutivo" }; ;
            l_observacoes = new Label() { Text = "Observações" };
            l_cliente = new Label() { Text = "Cliente" };

            dp_data = new DatePicker();
            tp_horaChegada = new TimePicker();
            tp_horaSaida = new TimePicker();
            p_tempoImprodutivo = new Picker();
            ed_observacoes = new Editor();
            p_cliente = new Picker();

            b_chegada = new Button() { Text = "Agora" };
            b_saida = new Button() { Text = "Agora" };

            scr_principal = new ScrollView();

            list_despesas = new List<Domain.Despesa>();

            ti_despesas = new ToolbarItem("Despesas", "", Despesas);
            ti_confirmar = new ToolbarItem("Confirmar", "", Confirmar);

            this.ToolbarItems.Add(ti_despesas);
            this.ToolbarItems.Add(ti_confirmar);

            sl_chegada_hori = new StackLayout() { Orientation = StackOrientation.Horizontal, Children = { tp_horaChegada, b_chegada } };
            sl_saida_hori = new StackLayout() { Orientation = StackOrientation.Horizontal, Children = { tp_horaSaida, b_saida } };

            sl_principal = new StackLayout() { Padding = 30, Children = { l_cliente, p_cliente, l_data, dp_data, l_horaChegada, sl_chegada_hori, l_horaSaida, sl_saida_hori, l_tempoImprodutivo, p_tempoImprodutivo, l_observacoes, ed_observacoes } };
            scr_principal.Content = sl_principal;

            this.Content = scr_principal;

            PopulaPickers();


        }

        private void Page_NovaDespesa_Envia(Domain.Despesa Despesa)
        {
            list_despesas.Add(Despesa);
        }

        private async void Despesas()
        {
            await Navigation.PushModalAsync(Page_NovaDespesa,true);
        }

        private async void Confirmar()
        {
            string link = Constantes.Server + Constantes.Server_Visitas;

            var post = await WSOpen.Post(link, NovaVisita());
        }

        private Domain.Visita NovaVisita()
        {
            string clienteSelecionado = Utilidades.RetornaStringSelecionadoPicker(p_cliente);

            string tempoImprodutivoSelecionado = Utilidades.RetornaStringSelecionadoPicker(p_tempoImprodutivo);

            Guid? id_cliente = Constantes.Clientes.SingleOrDefault(c => c.Nome == clienteSelecionado).Id;

            Domain.Visita Visita = new Domain.Visita()
            {
                Data = dp_data.Date,
                id_cliente = id_cliente,
                HoraChegada = tp_horaChegada.Time,
                HoraSaida = tp_horaSaida.Time,
                Observações = ed_observacoes.Text,
                TempoImprodutivo = TimeSpan.Parse(tempoImprodutivoSelecionado)

            };

            if (list_despesas != null && list_despesas.Count > 0)
            {
                foreach (var despesa in list_despesas)
                {
                    Visita.Despesas.Add(despesa);
                }
            }

            return Visita;
        }

        private async void PopulaPickers()
        {
            try
            {
                var retorno = await WSOpen.GetClientes();

                if (Constantes.Clientes != null && Constantes.Clientes.Count > 0)
                {
                    List<string> listaClientesNomeStrings = new List<string>();

                    foreach (var cliente in Constantes.Clientes)
                    {
                        listaClientesNomeStrings.Add(cliente.Nome);
                    }

                    foreach (var nome in listaClientesNomeStrings)
                    {
                        p_cliente.Items.Add(nome);

                    }
                }
            }
            catch
            {

            }

            foreach (var item in Constantes.Tempo)
            {
                p_tempoImprodutivo.Items.Add(item);
            }


        }
            

    }
}
