using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81Project
{
    /*
     * Class Name:  User
     * Author:      Aaron Mouratidis
     * Use:         Holds the users current Courses and Schedule. Also allows for adding/removing courses and building a Schedule based off currently selected Courses.
    */
    public class User
    {
        private List<Course> mCourses;
        private Schedule mSchedule;

        bool bFullSchedule = false;

        public List<Course> Courses
        {
            get { return mCourses; }
        }

        public Schedule Schedule
        {
            get { return mSchedule; }
        }

        /*
         * Method Name: AddCourse
         * Author:      Aaron Mouratidis
         * Use:         Adds a course to the cart without building a schedule on it
        */
        public bool AddCourse(Course newCourse)
        {
            if (newCourse == null || bFullSchedule)
                return false;

            mCourses.Add(newCourse);

            if (mCourses.Count == 5)
                bFullSchedule = true;

            return true;
        }


        /*
         * Method Name: RemoveCourse
         * Author:      Aaron Mouratidis
         * Use:         Removes a course from the current schedule and cart
        */
        public bool RemoveCourse(Course currCourse)
        {
            if (currCourse == null || mCourses.Count == 0)
                return false;

            mCourses.Remove(currCourse);
            bFullSchedule = false;

            return true;
        }


        /*
         * Method Name: BuildSchedules
         * Author:      Aaron Mouratidis 
         * Use:         Uses the users currently selected courses, and builds all possible schedules that do not have time conflicts, returned in a list.
        */



    }
}
