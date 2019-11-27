using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TogglConnect;

namespace TogglConnectTest
{
    [TestClass]
    public class UnitTest
    {
        private static string apiKey = "";
        private static int wid = 0;
        private static int pid = 0;
        private TogglBase tb;

        private void Init()
        {
            tb = TogglBase.GetInstance();
            tb.Init(apiKey, wid);
        }

        [TestMethod]
        public void TestAuthorization()
        {
            Init();
            var me = tb.GetMe();
            Assert.IsTrue(me.data.id > 0);
        }

        [TestMethod]
        public void TestGetProjects()
        {
            Init();
            var projects = tb.GetProjects();
            Assert.IsTrue(projects.Count > 0);
        }

        [TestMethod]
        public void TestGetProject()
        {
            Init();
            var project = tb.GetProject(pid);
            Assert.IsTrue(!string.IsNullOrEmpty(project.name));
        }
    }
}
