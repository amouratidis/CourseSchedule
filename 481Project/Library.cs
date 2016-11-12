using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81Project
{

    /*
     * Class Name:  Library
     * Author:      Aaron Mouratidis
     * Use:         Contains all the current courses and their sections, allows searching for specific courses.
    */
    public class Library
    {
        Course[] mAllCourses;

        /*
         * Method Name: Search
         * Author:      Aaron Mouratidis
         * Use:         Creates a list of Course results based on the search criteria
        */
        public Course[] Search(string sCourseSubject)
        {
            List<Course> mCoursesFound = new List<Course>();

            // Iterate through every course, applying the search critera to each.
            for (int iCourseIndex = 0; iCourseIndex < mAllCourses.Length; iCourseIndex++)
            {
                if (mAllCourses[iCourseIndex].SubjectName == sCourseSubject)
                    mCoursesFound.Add(mAllCourses[iCourseIndex]);
            }

            return mCoursesFound.ToArray();
        }


        /*
         * Method Name: Library (Constructor)
         * Author:      Aaron Mouratidis
         * Use:         Creates a set of courses and sections to be used for testing and display purposes.
        */
        public Library()
        {
            Section S1Math421 = new Section("Math 421", "A.Smith", "L01", 11, 1, new bool[] { true, false, true, false, true });
            Section S2Math421 = new Section("Math 421", "A.Smith", "L02", 15, 2, new bool[] { false, true, false, true, false });
            Course CMath421 = new Course("MATH", "Statistics", 421, new Section[] { S1Math421, S2Math421 });

            Section S1Phil351 = new Section("Phil 351", "B.Wong", "L01", 8, 1, new bool[] { true, false, true, false, true });
            Section S2Phil351 = new Section("Phil 351", "C.Douglas", "L02", 9, 2, new bool[] { false, true, false, true, false });
            Course CPhil351 = new Course("PHIL", "Life and Death", 351, new Section[] { S1Phil351, S2Phil351 });

            Section S1Psyc201 = new Section("Psyc 201", "F.Hendrick", "L01", 9, 1, new bool[] { true, false, true, false, true });
            Section S2Psyc201 = new Section("Psyc 201", "I.Smith", "L02", 10, 2, new bool[] { false, true, false, true, false });
            Course CPsyc201 = new Course("PSYC", "The Mind", 201, new Section[] { S1Psyc201, S2Psyc201 });

            Section S1Math213 = new Section("Math 213", "C.Johnson", "L01", 12, 1, new bool[] { true, false, true, false, true });
            Section S2Math213 = new Section("Math 213", "A.Smith", "L02", 14, 2, new bool[] { false, true, false, true, false });
            Course CMath213 = new Course("MATH", "Discrete 1", 213, new Section[] { S1Math213, S2Math213 });

            Section S1Psyc203 = new Section("Psyc 203", "I.Smith", "L01", 10, 1, new bool[] { true, false, true, false, true });
            Section S2Psyc203 = new Section("Psyc 203", "F.Hendrick", "L02", 11, 2, new bool[] { false, true, false, true, false });
            Course CPysc203 = new Course("PSYC", "Statistics", 203, new Section[] { S1Psyc203, S2Psyc203 });

            Section S1Math217 = new Section("Math 217", "C.Johnson", "L01", 13, 1, new bool[] { true, false, true, false, true });
            Section S2Math217 = new Section("Math 217", "C.Smith", "L02", 9, 2, new bool[] { false, true, false, true, false });
            Course CMath217 = new Course("MATH", "Discrete 2", 217, new Section[] { S1Math217, S2Math217 });

            mAllCourses = new Course[] { CMath421, CPhil351, CPsyc201, CMath213, CPysc203, CMath217 };
        }

    }
}
