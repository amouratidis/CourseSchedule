using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81Project
{

    /*
     * Class Name:  Course 
     * Author:      Aaron Mouratidis
     * Use:         Holds the attributes for anything specific to a single Course
    */
    public class Course
    {
        string sSubjectName;
        string sCourseName;
        int iCourseNumber;
        Section[] mSections;


        // Accessor method for sSubjectName
        public string SubjectName
        {
            get { return sSubjectName; }
        }


        // Accessor method for sCourseName
        public string CourseName
        {
            get { return sCourseName; }
        }


        // Accessor method for iCourseNumber
        public int CourseNumber
        {
            get { return iCourseNumber; }
        }


        // Accessor method for mSections
        public Section[] Sections
        {
            get { return mSections; }
        }


        // Accessor method for a specific member of mSections
        public Section this[int iIndex]
        {
            get { return this.mSections[iIndex]; }
        }

        /*
         * Method Name: Course (Constructor)
         * Author: Aaron Mouratidis
         * Use: Sets the basic attributes of a Course class, and creates it.
        */
        public Course(string sSubject, string sName, int iNum, Section[] mSect)
        {
            sSubjectName = sSubject;
            sCourseName = sName;
            iCourseNumber = iNum;
            mSections = mSect;
        }

    }
}
