using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
using System.Activities;

namespace CustomActivities
{
	public abstract class WaitActivity<T> : NativeActivity<T>
	{
        public WaitActivity() :base()
        {}

        public InArgument<string> BookmarkName { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(BookmarkName.Get(context), new BookmarkCallback(OnDataArrived));
        }

        private void OnDataArrived(NativeActivityContext context, Bookmark bk, object data)
        {
            if (typeof(T).IsAssignableFrom(data.GetType()))
            {
                Result.Set(context, data);
            }
            else
            {
                throw new ArgumentException(
                    String.Format(
                        "Invalid data type for this bookmark. Expected type of {0} but received object of type {1}", typeof(T).FullName, data.GetType().FullName));
            }
        }
       
    }
}
