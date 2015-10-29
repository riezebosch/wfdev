using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace CustomActivities
{
	public class SaveStudentSignIn : CodeActivity
    {
        public InArgument<Contracts.Course> Course { get; set; }
        public InArgument<string> StudentName { get; set; }


        protected override void Execute(CodeActivityContext context)
        {

            string sName = StudentName.Get(context);
            Contracts.Course crse = Course.Get(context);

            //save sign-in tick in database
            using (CourseDAL.PluralsightCoursesWF4Entities ctx = new CourseDAL.PluralsightCoursesWF4Entities())
            {

                var registration = (from r in ctx.CourseRegistrations
                                   where r.CourseID == crse.CourseID
                                    && r.StudentName == sName
                                   select r).FirstOrDefault();

                if (registration != null)
                {
                    registration.SignedIn = true;
                    ctx.SaveChanges();
                }
                else
                {
                    //TODO: throw exception when registration not found
                }        
            }
        }
    }
}
