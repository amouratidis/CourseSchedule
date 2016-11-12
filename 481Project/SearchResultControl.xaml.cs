using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _81Project
{
	/// <summary>
	/// Interaction logic for CoursesControl.xaml
	/// </summary>
	public partial class CoursesControl : UserControl
	{
        Course myCourse;

        public Course Course
        {
            get { return myCourse; }
        }

		public CoursesControl(Course newCourse)
		{
			this.InitializeComponent();

            myCourse = newCourse;

            this.ResultCourse.Text = myCourse.SubjectName + " " + myCourse.CourseNumber + " - " + myCourse.CourseName;
		}
	}
}