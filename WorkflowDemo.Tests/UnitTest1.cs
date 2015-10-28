using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Activities.Statements;
using Microsoft.VisualBasic.Activities;
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
    }
}
