using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Activities;
using System.Collections.Generic;
using System.Linq;

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
    }
}
