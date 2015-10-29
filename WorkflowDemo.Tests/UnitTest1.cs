﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Activities.Statements;
using Microsoft.CSharp.Activities;
using System.Diagnostics;

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
    }
}
