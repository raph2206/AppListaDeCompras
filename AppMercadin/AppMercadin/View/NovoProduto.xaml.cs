using AppMercadin.Model;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMercadin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoProduto : ContentPage
    {
        public NovoProduto()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Produtos p = new Produtos
                {
                    Descricao = txt_desc.Text,
                    Quantidade = Convert.ToDouble(txt_qnt.Text),
                    Preco = Convert.ToDouble(txt_preco.Text),
                };

                await Main.Database.Insert(p);

                await DisplayAlert("Sucesso!", "Produto Cadastrado", "OK");

                await Navigation.PushAsync(new Listagem());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}