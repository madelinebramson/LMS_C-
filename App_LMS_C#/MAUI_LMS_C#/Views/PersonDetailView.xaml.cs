using Library_LMS_C_.Models;
using Library_LMS_C_.Services;
using MAUI_LMS_C_.ViewModels;

namespace MAUI_LMS_C_.Views;

public partial class PersonDetailView : ContentPage
{
	public PersonDetailView()
	{
		InitializeComponent();
	}
	private void OnLeaving(object sender, EventArgs e)
	{
		BindingContext = null;
	}

	private void OnArriving(object sender, EventArgs e)
	{
		BindingContext = new PersonDetailViewModel();
	}
    private void OkClick(object sender, EventArgs e)
    {

        (BindingContext as PersonDetailViewModel).AddPerson();
    }

	private void CancelClick(object sender, EventArgs e) 
	{
		Shell.Current.GoToAsync("//Instructor");
	}
}