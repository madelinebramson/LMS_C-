using Library_LMS_C_.Models;
using Library_LMS_C_.Services;
using MAUI_LMS_C_.ViewModels;

namespace MAUI_LMS_C_.Views;

[QueryProperty(nameof(PersonId),"personId")]
public partial class PersonDetailView : ContentPage
{
	public PersonDetailView()
	{
		InitializeComponent();
	}
	public int PersonId
	{ 
		set; get; 
	}
	private void OnLeaving(object sender, EventArgs e)
	{
		BindingContext = null;
	}

	private void OnArriving(object sender, EventArgs e)
	{
		BindingContext = new PersonDetailViewModel(PersonId);
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