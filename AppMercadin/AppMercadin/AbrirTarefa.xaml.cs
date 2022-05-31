using AppMercadin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMercadin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AbrirTarefa : ContentPage
    {
        public AbrirTarefa()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Tarefa t = new Tarefa
            {
                Id = Convert.ToInt16(lbl_id.Text),
                Produto = txt_produto.Text,
                Preco = txt_preco.Text,
                Data_Criacao = dtpck_data_criacao.Date,
                Data_Conclusao = dtpck_data_conclusao.Date
            };

            await App.Database.Update(t);

            await DisplayAlert("Funfou!", "Atualizando no SQLite", "OK");

            await Navigation.PushAsync(new Listagem());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            Tarefa t = new Tarefa
            {
                Id = Convert.ToInt16(lbl_id.Text),
                Produto = txt_produto.Text,
                Preco = txt_preco.Text,
                Data_Criacao = dtpck_data_criacao.Date,
                Data_Conclusao = dtpck_data_conclusao.Date
            };

            await App.Database.Delete(t);

            await DisplayAlert("Funfou!", "Tarefa Excluida do SQLite", "OK");

            await Navigation.PushAsync(new Listagem());
        }
    }
}