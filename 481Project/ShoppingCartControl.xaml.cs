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
	/// Interaction logic for ShoppingCartControl.xaml
	/// </summary>
	public partial class ShoppingCartControl : UserControl
	{
        Course myCourse;
        ListBox myContainer;

        public Course Course
        {
            get { return myCourse; }
        }

		public ShoppingCartControl(Course newCourse, ListBox newContainer)
		{
			this.InitializeComponent();
			Remove.Click += RemoveFromCart;

            myCourse = newCourse;
            myContainer = newContainer;

            this.ClassName.Text = myCourse.SubjectName + " " + myCourse.CourseNumber;
		}
		
		void RemoveFromCart(object sender, RoutedEventArgs e)
		{
            myContainer.Items.Remove(this);
		}
		
	}
}