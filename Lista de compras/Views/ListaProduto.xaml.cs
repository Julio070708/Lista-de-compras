namespace Lista_de_compras.Views;

public partial class ListaProduto : ContentPage
{
	public ListaProduto()
	{
		InitializeComponent();
	}
	
	private void TollbarItem_Clicked(object sender, EventArgs e)
	{
		try
		{
			Navigation.PushAsync(new Views.NovoProduto());

        }
        catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "OK");
		}
	}
}