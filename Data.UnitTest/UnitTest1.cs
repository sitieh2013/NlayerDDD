using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Persistence;
using Data.Repository;
using System.Linq;

namespace Data.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var project = new RepositoryProject().GetListAll().ToList();
            var impart = new RepositoryImpart().GetListAll().ToList();
            var probability = new RepositoryProbability().GetListAll().ToList();
            var risk = new RepositoryRisk().GetListAll().ToList();
        }
    }
}
