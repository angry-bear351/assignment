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
	public class AdvancedboxTests
	{
		[TestMethod()]
		public void abCheckInputsTest()
		{
			Advancedbox advancedbox = new Advancedbox();
			PrivateObject obj = new PrivateObject(advancedbox);
			advancedbox.commentBox.Text = "Test1";
			advancedbox.fixedBox.Text = "test2";
			advancedbox.fixedByBox.Text = "test3";



			Assert.AreEqual(true, obj.Invoke("checkInputs"));

		}
		[TestMethod()]
		public void abCheckInputTest_Empty()
		{
			Advancedbox advancedbox = new Advancedbox();
			PrivateObject obj = new PrivateObject(advancedbox);

			Assert.AreEqual(false, obj.Invoke("checkInputs"));
		}
	}
}