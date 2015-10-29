using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace CustomActivities
{
   
	public class SaveCourse : CodeActivity
	{
        public InArgument<Contracts.Course> Course { get; set; }

 
        protected override void Execute(CodeActivityContext context)
        {
            Contracts.Course argCourse = Course.Get(context);

            var newCourse = new CourseDAL.Course
                    {
                        StartDate = argCourse.StartDate,
                        EndDate = argCourse.EndDate,
                        Topic = argCourse.Topic,
                        Location = argCourse.Location,
                        Instructors = String.Join(";", argCourse.Instructors.Select(p => p.Name).ToArray()),
                        WorkflowID = context.WorkflowInstanceId,
                        State = (byte)Contracts.CourseStatus.Registration
                    };

            using (CourseDAL.PluralsightCoursesWF4Entities ctx = new CourseDAL.PluralsightCoursesWF4Entities())
            {
                ctx.Courses.AddObject(
                    newCourse);

                ctx.SaveChanges();

                argCourse.CourseID = newCourse.CourseID;
                Course.Set(context, argCourse);
            }
        }
	}
}
