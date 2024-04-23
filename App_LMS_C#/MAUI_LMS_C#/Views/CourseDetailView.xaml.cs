using Library_LMS_C_.Models;
using MAUI_LMS_C_.ViewModels;

namespace MAUI_LMS_C_.Views;

[QueryProperty(nameof(CourseId), "courseId")]
public partial class CourseDetailView : ContentPage
{
	public CourseDetailView()
	{
		InitializeComponent();
    }
	public int CourseId { get; set; }

	private void OnLeaving(object sender, EventArgs e)
	{
		BindingContext = null;
	}

	private void OnArriving(object sender, EventArgs e)
	{
		BindingContext = new CourseDetailViewModel(CourseId);
	}
	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Instructor");
	}
	private void Done(object sender, EventArgs e)
	{
		(BindingContext as CourseDetailViewModel).AddCourse();
	}

	private void AddStudentToCourse(object sender, EventArgs e)
	{
		(BindingContext as CourseDetailViewModel).AddStudentToCourse();
	}
	
	private void RemoveStudentFromCourse(object sender, EventArgs e)
	{
		(BindingContext as CourseDetailViewModel).RemoveStudentFromCourse();
	}
}
