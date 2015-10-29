using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;

using System.Activities;


namespace CustomActivities
{
	public class ChangeCourseStatus : CodeActivity
	{
        public InArgument<Contracts.Course> Course { get; set; }
        public InArgument<Contracts.CourseStatus> Status { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            Contracts.Course argCourse = Course.Get(context);
            Contracts.CourseStatus argStatus = Status.Get(context);

            using (CourseDAL.PluralsightCoursesWF4Entities ctx = new CourseDAL.PluralsightCoursesWF4Entities())
            {
                var course = (from c in ctx.Courses
                              where c.CourseID == argCourse.CourseID
                              select c).FirstOrDefault();
                course.State = (byte)argStatus;

                ctx.SaveChanges();
            }
        }
	}
}
