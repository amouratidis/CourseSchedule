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
	/// Interaction logic for ClassListControl.xaml
	/// </summary>
	public partial class ScheduleControl : UserControl
	{
        Schedule CurrentSchedule;

        public Schedule CurrSchedule
        {
            get { return CurrentSchedule; }
        }

        public ScheduleControl()
        {
            this.InitializeComponent();
        }

		public ScheduleControl(Schedule newSchedule)
		{
			this.InitializeComponent();

            ShowSchedule(newSchedule);
		}

        public void ShowSchedule(Schedule newSchedule)
        {
            this.ClassBlocks.Children.Clear();

            for (int iHourIndex = 0; iHourIndex < 12; iHourIndex++)
            {
                for (int iDayIndex = 0; iDayIndex < 5; iDayIndex++)
                {
                    ScheduleTimeslotControl newTimeBlock = new ScheduleTimeslotControl();

                    if (newSchedule.mSchedule[iDayIndex, iHourIndex] != null)
                    {
                        newTimeBlock.Background = SystemColors.GradientActiveCaptionBrush;
                        newTimeBlock.CourseName.Text = newSchedule.mSchedule[iDayIndex, iHourIndex].CourseName;
                    }
                    this.ClassBlocks.Children.Add(newTimeBlock);
                }

            }

            CurrentSchedule = newSchedule;
        }

	}
}