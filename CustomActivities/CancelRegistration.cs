using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace CustomActivities
{
	public class CancelRegistration : CodeActivity
	{
        public InArgument<Contracts.CourseRegistration> Registration { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            //remove or mark canceled registration in DB
            
            using (CourseDAL.PluralsightCoursesWF4Entities ctx = new CourseDAL.PluralsightCoursesWF4Entities())
            {
                ctx.CourseRegistrations.DeleteObject(
                    new CourseDAL.CourseRegistration { CourseID = Registration.Get(context).CourseID });
                         
                //var reg = (from r in ctx.CourseRegistrations
                //          where r.StudentEmail == Registration.Get(context).Attendee.Email && 
                //          r.Course.Topic == Registration.Get(context).CourseName
                //          select r).FirstOrDefault();

                //ctx.CourseRegistrations.DeleteOnSubmit(reg);
                ctx.SaveChanges();
            }
            
           
        }
	}
}
