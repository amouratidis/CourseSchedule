using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {

        Library MainLibrary;
        Schedule MainSchedule;
        Schedule PreviousMainSchedule;
        Schedule[] mySchedList;
        ScheduleControl mySchedControl;
        ScheduleControl myDragSchedule;

        int iBuildPageIndex;

        public MainWindow()
        {
            InitializeComponent();

            DragOpenButton.Click += Drag_Open;
            DragCloseButton.Click += Drag_Close;

			CriteriaSearch.Click += Add_Open;

			ResultsBackButton.Click += ResultsBackButton_Click;
            ResultsAddButton.Click += ResultsAddButton_Click;

            BuildBackButton.Click += BuildBackButon_Click;
			BuildButton.Click += Build_Open;
			BuildConfirmButton.Click += Enroll;

            MainLibrary = new Library();
            MainSchedule = new Schedule();

            mySchedControl = new ScheduleControl();
            BuildSchedule.Children.Add(mySchedControl);

            myDragSchedule = new ScheduleControl();
            DragSchedule.Children.Add(myDragSchedule);

            iBuildPageIndex = 0;
        }

        void ResultsAddButton_Click(object sender, RoutedEventArgs e)
        {
            ResultsPage.Visibility = System.Windows.Visibility.Hidden;
            SearchPage.Visibility = System.Windows.Visibility.Visible;

            for (int iCourseItem = 0; iCourseItem < ResultBox.Items.Count; iCourseItem++)
            {
                CoursesControl currItem = (CoursesControl)ResultBox.Items[iCourseItem];

                if (currItem.SelectCheckBox.IsChecked == true && ShoppingCartBox.Items.Count <= 4)
                {
                    ShoppingCartControl newControl = new ShoppingCartControl(currItem.Course, ShoppingCartBox);
                    ShoppingCartBox.Items.Add(newControl);
                }
            }

            ResultBox.Items.Clear();
        }

        //Opens Schedule
        void Drag_Open(object sender, RoutedEventArgs e)
        {
            DragOpenButton.Visibility = System.Windows.Visibility.Hidden;

            DragCloseButton.Visibility = System.Windows.Visibility.Visible;
            DragOutSchedule.Visibility = System.Windows.Visibility.Visible;
        }

        //Closes Schedule
        void Drag_Close(object sender, RoutedEventArgs e)
        {
            DragOpenButton.Visibility = System.Windows.Visibility.Visible;

            DragCloseButton.Visibility = System.Windows.Visibility.Hidden;
            DragOutSchedule.Visibility = System.Windows.Visibility.Hidden;
        }
		
        //Back to Search from Add screen
		void ResultsBackButton_Click(object sender, RoutedEventArgs e)
		{
			ResultsPage.Visibility = System.Windows.Visibility.Hidden;
            SearchPage.Visibility = System.Windows.Visibility.Visible;

            ResultBox.Items.Clear();
		}
		
        //Back to Search from Build screen
		void BuildBackButon_Click(object sender, RoutedEventArgs e)
		{
			BuildPage.Visibility = System.Windows.Visibility.Hidden;
            SearchPage.Visibility = System.Windows.Visibility.Visible;

            iBuildPageIndex = 0;
            MainSchedule = PreviousMainSchedule;
		}
		
        //Go to Add Screen
		void Add_Open(object sender, RoutedEventArgs e)
		{
            SearchPage.Visibility = System.Windows.Visibility.Hidden;
			ResultsPage.Visibility = System.Windows.Visibility.Visible;

            Course[] mCourseResults = MainLibrary.Search(CourseComboBox.Text);
            for (int iIndex = 0; iIndex < mCourseResults.Length; iIndex++)
            {
                CoursesControl newControl = new CoursesControl(mCourseResults[iIndex]);

                ResultBox.Items.Add(newControl);
            }
		}
		
        //Go to Build Screen
		void Build_Open(object sender, RoutedEventArgs e)
        {
            if (ShoppingCartBox.Items.Count == 0)
                return;

            SearchPage.Visibility = System.Windows.Visibility.Hidden;
            ResultsPage.Visibility = System.Windows.Visibility.Hidden;

            ResultBox.Items.Clear();

            Schedule[] mySchedules = BuildSchedules();
            mySchedList = mySchedules;
            mySchedControl.ShowSchedule(mySchedList[0]);

            MainSchedule = mySchedules[0];

            if (mySchedules.Length > 1)
                BuildRightButton.Visibility = System.Windows.Visibility.Visible;

            BuildPage.Visibility = System.Windows.Visibility.Visible;
        }
		
        //Enroll in slected schedule
		void Enroll(object sender, RoutedEventArgs e)
		{
            BuildPage.Visibility = System.Windows.Visibility.Hidden;
            SearchPage.Visibility = System.Windows.Visibility.Visible;

            iBuildPageIndex = 0;

            myDragSchedule.ShowSchedule(MainSchedule);

            PreviousMainSchedule = MainSchedule;
        }

        private Schedule[] BuildSchedules()
        {
            List<Schedule> mScheduleGroup = new List<Schedule>();
            List<Course> mCourses = new List<Course>();

            for (int iCartItemIndex = 0; iCartItemIndex < ShoppingCartBox.Items.Count; iCartItemIndex++)
            {
                ShoppingCartControl myItem = (ShoppingCartControl)ShoppingCartBox.Items[iCartItemIndex];
                mCourses.Add(myItem.Course);
            }


            Section[] mSectionGroup = new Section[5];
            int[] iSectionCounter = { 0, 0, 0, 0, 0 };

            Schedule mNewSched;
            bool notFinished = true;

            // Loop through every possible combination of lectures
            while (notFinished)
            {
                for (int iCourseNum = 0; iCourseNum < mCourses.Count; iCourseNum++)
                    mSectionGroup[iCourseNum] = mCourses[iCourseNum].Sections[iSectionCounter[iCourseNum]];

                // Increment the right-most counter, carrying over any overflow to the next (to the left) counter.
                for (int iSectionIndex = (mCourses.Count - 1); iSectionIndex >= 0; iSectionIndex--)
                {
                    if (iSectionCounter[iSectionIndex] < (mCourses[iSectionIndex].Sections.Length - 1))
                    {
                        iSectionCounter[iSectionIndex]++;
                        break;
                    }
                    else if (iSectionIndex != 0)
                    {
                        iSectionCounter[iSectionIndex] = 0;
                    }
                }

                for (int iCourseNum = 0; iCourseNum < mCourses.Count; iCourseNum++)
                {
                    if (iSectionCounter[iCourseNum] == (mCourses[iCourseNum].Sections.Length - 1))
                    {
                        notFinished = false;
                    }
                    else
                    {
                        notFinished = true;
                        break;
                    }

                }

                mNewSched = new Schedule(mSectionGroup);
                if (mNewSched.Useable)
                    mScheduleGroup.Add(mNewSched);

            }

            return mScheduleGroup.ToArray();
        }

        private void BuildLeftButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            iBuildPageIndex--;
            MainSchedule = mySchedList[iBuildPageIndex];
            mySchedControl.ShowSchedule(mySchedList[iBuildPageIndex]);

            if (iBuildPageIndex == 0)
                BuildLeftButton.Visibility = System.Windows.Visibility.Hidden;
            if (iBuildPageIndex < mySchedList.Length - 1)
                BuildRightButton.Visibility = System.Windows.Visibility.Visible;
        }

        private void BuildRightButon_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            iBuildPageIndex++;
            MainSchedule = mySchedList[iBuildPageIndex];
            mySchedControl.ShowSchedule(mySchedList[iBuildPageIndex]);

            if (iBuildPageIndex == mySchedList.Length - 1)
                BuildRightButton.Visibility = System.Windows.Visibility.Hidden;
            if (iBuildPageIndex > 0)
                BuildLeftButton.Visibility = System.Windows.Visibility.Visible;

        }

        private void ArrowClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Drag_Open(sender, e);
        }

    }

    
	
	
}
