using SoftwarePos.ViewModels;

namespace SoftwarePos.Pages;

public partial class ProductosPage : ContentPage
{
	public ProductosPage()
	{
		InitializeComponent();
        BindingContext = new ProductoViewModel();
    }
}