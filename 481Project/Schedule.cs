using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81Project
{

    /*
     * Class Name:  Schedule
     * Author:      Aaron Mouratidis
     * Use:         Structure for the representation of a Schedule, is constructed by supplying a list of Sections (If the sections have a conflict, the Schedule's attribute bUseable will be false)
    */
    public class Schedule
    {
        const int TIME_OFFSET = 8;

        bool bUseable = true;
        public Section[,] mSchedule = new Section[5, 12];
        Section[] mSections;


        // Accessor method for bUseable
        public bool Useable
        {
            get { return bUseable; }
        }

        public Schedule()
        {
        }

        /*
         * Method Name: Schedule (Constructor)
         * Author: Aaron Mouratidis
         * Use: Builds a schedule class given a specific set of sections. If the sections have a time conflict, the schedule will have bUseable set to false.
        */
        public Schedule(Section[] mSections)
        {
            this.mSections = mSections;

            // Loop for each section in the list
            for (int iIndex = 0; iIndex < mSections.Length; iIndex++)
            {
                if (mSections[iIndex] == null)
                    continue;

                int iStartTime = mSections[iIndex].StartTime;

                // Loop for each school day in the week
                for (int iDayIndex = 0; iDayIndex < 5; iDayIndex++)
                {
                    if (mSections[iIndex].Days[iDayIndex] == false)
                        continue;

                    // Loop for each hour in the classes duration
                    for (int iTimeIndex = 0; iTimeIndex < mSections[iIndex].Duration; iTimeIndex++)
                    {
                        int iCurrTime = (iTimeIndex + mSections[iIndex].StartTime) - TIME_OFFSET;
                        if (mSchedule[iDayIndex, iCurrTime] == null)
                        {
                            mSchedule[iDayIndex, iCurrTime] = mSections[iIndex];
                        }
                        else
                        {
                            bUseable = false;
                            return;
                        }

                    }

                }

            }

        }

    }
}
