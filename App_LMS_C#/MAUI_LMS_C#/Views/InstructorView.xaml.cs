using Library_LMS_C_.Models;
using Library_LMS_C_.Services;
using MAUI_LMS_C_.ViewModels;
using System.Xml.Serialization;

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

	private void AddEnrollmentClick(object sender, EventArgs e)
	{
		(BindingContext as InstructorViewViewModel).AddEnrollmentClick(Shell.Current);
	}

	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		(BindingContext as InstructorViewViewModel).RefreshView();
	}

	private void RemoveEnrollmentClick(object sender, EventArgs e)
	{
		(BindingContext as InstructorViewViewModel).RemoveEnrollmentClick();
	}

	private void EditEnrollmentClick(object sender, EventArgs e)
	{
		(BindingContext as InstructorViewViewModel).AddEnrollmentClick(Shell.Current);		
	}

	private void AddCourseClick (object sender, EventArgs e) 
	{
		(BindingContext as InstructorViewViewModel).AddCourseClick(Shell.Current);
	}

	private void EditCourseClick(object sender, EventArgs e)
	{
		(BindingContext as InstructorViewViewModel).AddCourseClick(Shell.Current);
	}

	private void RemoveCourseClick(object sender, EventArgs e)
	{
		(BindingContext as InstructorViewViewModel).RemoveCourseClick();
	}
	private void Toolbar_EnrollmentsClicked(object sender, EventArgs e)
	{
		(BindingContext as InstructorViewViewModel).ShowEnrollments();
	}

	private void Toolbar_CoursesClicked(object sender, EventArgs e)
	{
		(BindingContext as InstructorViewViewModel).ShowCourses();
	}

	private void CourseCancelClick(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync("//MainPage");
    }

}