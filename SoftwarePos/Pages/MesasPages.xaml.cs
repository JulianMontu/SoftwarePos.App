using SoftwarePos.ViewModels;

namespace SoftwarePos.Pages;

public partial class MesasPages : ContentPage
{
	public MesasPages()
	{
		InitializeComponent();
        BindingContext = new MesaViewModel();
    }
}