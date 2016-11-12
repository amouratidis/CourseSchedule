using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81Project
{

    /*
     * Class Name:  Section 
     * Author:      Aaron Mouratidis
     * Use:         Holds the attributes for anything specific to a single Section
    */
    public class Section
    {
        string sBasicName;
        string sInstructor;
        string sSectionNum;
        int iStartTime;
        int iDuration;
        bool[] bDays;

        public string CourseName
        {
            get { return sBasicName; }
        }

        // Accessor method for sInstructor
        public string Instructor
        {
            get { return sInstructor; }
        }


        // Accessor method for sSectionNum
        public string SectionNumber
        {
            get { return sSectionNum; }
        }


        // Accessor method for iStartTime
        public int StartTime
        {
            get { return iStartTime; }
        }


        // Accessor method for iDuration
        public int Duration
        {
            get { return iDuration; }
        }


        // Accessor method for bDays
        public bool[] Days
        {
            get { return bDays; }
        }


        /*
         * Method Name: Section (Constructor)
         * Author: Aaron Mouratidis
         * Use: Sets the basic attributes of the Section class, and creates it.
        */
        public Section(string sName, string sInstruct, string sNum, int iStart, int iLength, bool[] bDaysOfWeek)
        {
            sBasicName = sName;
            sInstructor = sInstruct;
            sSectionNum = sNum;
            iStartTime = iStart;
            iDuration = iLength;
            bDays = bDaysOfWeek;
        }
    }
}
