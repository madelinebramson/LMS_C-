
using MAUI_LMS_C_.ViewModels;
namespace MAUI_LMS_C_.Views;

public partial class InstructorView : ContentPage
{
	public InstructorView()
	{
        InitializeComponent();
		BindingContext = new InstructorViewViewModel();
	}
	
	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}
}