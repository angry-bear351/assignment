using Microsoft.VisualStudio.TestTools.UnitTesting;
using assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Tests
{
    [TestClass()]
    public class BlackboxTests
    {
        [TestMethod()]
        public void bbCheckInputsTest()
        {
            Blackbox blackbox = new Blackbox();
			PrivateObject obj = new PrivateObject(blackbox);
			blackbox.txtId.Text = "Test1";
			blackbox.txtAddress.Text = "test2";
			blackbox.txtName.Text = "test3";



            Assert.AreEqual(true,obj.Invoke("checkInputs"));
        }
		[TestMethod()]
		public void abCheckInputTest_Empty()
		{
			Blackbox blackbox = new Blackbox();
			PrivateObject obj = new PrivateObject(blackbox);

			Assert.AreEqual(false, obj.Invoke("checkInputs"));
		}
	}
}