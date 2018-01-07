using System;
using assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bugtracker_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBlackBoxinsertRecord()
        {
            //arrange
            String Id = "test1";
            String App = "test2";
            String Bug = "test3";
            String Cause = "test4";
            String commandString = "INSERT INTO bugList([Id], [App], [Bug], [Cause]) VALUES (@ID, @App, @Bug, @Cause)";
            Blackbox bb = new Blackbox();

            //Act
            bb.insertRecord(Id, App, Bug, Cause, commandString);

        }
    }
}
