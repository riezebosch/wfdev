using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Activities.Statements;
using Microsoft.CSharp.Activities;
using System.Diagnostics;
using System.Threading;
using System.Dynamic;

namespace WorkflowDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            WorkflowInvoker invoker = new WorkflowInvoker(new CodeActivity1());
            var input = new Dictionary<string, object>
            {
                { "Text", "Goedemorgen" }
            };

            var result = invoker.Invoke(input);

            Assert.AreEqual("Goedemorgen workflow", result["Output"]);
        }

        [TestMethod]
        public void WerktDeDelayActivityInEenWorkflowInvoker()
        {
            var sw = Stopwatch.StartNew();
            var invoker = new WorkflowInvoker(new Delay
            {
                    Duration = new InArgument<TimeSpan>(TimeSpan.FromSeconds(5))
            });
            invoker.Invoke();

            Assert.IsTrue(sw.Elapsed.TotalSeconds >= 5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidWorkflowException))]
        public void VullenVanInArgumentsVanuitCode1()
        {
            var activity = new Activity3
            {
                Input = new Course
                {
                    Id = 1
                }
            };

            var invoker = new WorkflowInvoker(activity);

            var output = invoker.Invoke();
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void VullenVanInArgumentsVanuitCode2()
        {
            var activity = new Activity3
            {
                Input = new CSharpValue<Course>(@"new Course
                {
                    Id = 1
                }")
            };

            var invoker = new WorkflowInvoker(activity);
            
            var output = invoker.Invoke();
        }

        [TestMethod]
        public void VullenVanInArgumentsVanuitCode3 ()
        {
            var activity = new Activity3();
            var invoker = new WorkflowInvoker(activity);
            var arguments = new Dictionary<string, object>
            {
                { "Input", new Course { Id = 1 } }
            };

            var output = invoker.Invoke(arguments);
        }

        [TestMethod]
        public void DemoVanTracking()
        {
            var tracker = new TestTrackingParticipant();
            var application = new WorkflowApplication(new WriteLine { Text = "Hoi" });
            application.Extensions.Add(tracker);

            var ready = new AutoResetEvent(false);

            application.Run();
            application.Completed += (e) => ready.Set();

            ready.WaitOne();

            Assert.IsTrue(tracker.IsInvoked);
            Assert.IsTrue(tracker.Records.Any());
        }

        [TestMethod]
        public void DemoVanTracing()
        {
            var tracer = new TestTraceListener();
            System.Diagnostics.Trace.Listeners.Add(tracer);

            var application = new WorkflowApplication(new WriteLine { Text = "Hoi" });

            var ready = new AutoResetEvent(false);

            application.Run();
            application.Completed += (e) => ready.Set();

            ready.WaitOne();
            tracer.Dispose();

            // Deze werkt nog niet.
            Assert.IsTrue(tracer.Messages.Any());
        }
    }
}
