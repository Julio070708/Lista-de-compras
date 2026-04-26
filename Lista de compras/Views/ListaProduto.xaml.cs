using Lista_de_compras.Models;
using System.Collections.ObjectModel;

namespace Lista_de_compras.Views;

public partial class ListaProduto : ContentPage
{
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();

    public ListaProduto()
    {
        InitializeComponent();
        lst_produtos.ItemsSource = lista;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        lista.Clear();

        List<Produto> tmp = await App.Db.GetAll();

        foreach (Produto p in tmp)
        {
            lista.Add(p);
        }
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            string busca = e.NewTextValue ?? "";

            lista.Clear();

            List<Produto> produtos = await App.Db.Search(busca);

            foreach (Produto p in produtos)
            {
                lista.Add(p);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    private async void TollbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new NovoProduto());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    // 🔥 RELATÓRIO POR CATEGORIA (AQUI FOI ALTERADO)
    private async void Somar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var relatorio = lista
                .GroupBy(p => p.Categoria)
                .Select(g => $"{g.Key}: R$ {g.Sum(p => p.Total):F2}")
                .ToList();

            await DisplayAlert("Relatório por Categoria",
                string.Join("\n", relatorio),
                "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            MenuItem item = sender as MenuItem;

            if (item?.BindingContext is not Produto produto)
                return;

            bool confirmar = await DisplayAlert(
                "Remover",
                "Deseja remover este produto?",
                "Sim",
                "Não");

            if (confirmar)
            {
                await App.Db.Delete(produto.Id);
                lista.Remove(produto);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    private async void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            if (e.SelectedItem is Produto p)
            {
                await Navigation.PushAsync(new Views.EditarProduto
                {
                    BindingContext = p,
                });
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}