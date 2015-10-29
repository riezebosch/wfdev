using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace CustomActivities
{
	public class SaveRegistration : CodeActivity
	{
        public InArgument<Contracts.CourseRegistration> Registration { get; set; }
        public InArgument<Contracts.Course> Course { get; set; }


        
        protected override void Execute(CodeActivityContext context)
        {
            Contracts.CourseRegistration argReg = Registration.Get(context);
            Contracts.Course argCourse = Course.Get(context);

            using (CourseDAL.PluralsightCoursesWF4Entities ctx = new CourseDAL.PluralsightCoursesWF4Entities())
            {
                ctx.CourseRegistrations.AddObject(
                    new CourseDAL.CourseRegistration
                    {
                        StudentName = argReg.Attendee.Name,
                        StudentEmail = argReg.Attendee.Email,
                        CourseID = argCourse == null ? argReg.CourseID : argCourse.CourseID,
                        PaymentReceived = argReg.PaymentReceived
                    }
                    );

                ctx.SaveChanges();
            }
            
        }
	}
}
