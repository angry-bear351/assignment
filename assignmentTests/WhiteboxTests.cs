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
	public class WhiteboxTests
	{
		[TestMethod()]
		public void wbCheckInputsTest()
		{
			Whitebox whitebox = new Whitebox();
			PrivateObject obj = new PrivateObject(whitebox);

			whitebox.classBox.Text = "test1";
			whitebox.methodBox.Text = "test2";
			whitebox.codeBox.Text = "test3";
			whitebox.lineBox.Text = "test4";
			whitebox.authorName.Text = "test5";

			Assert.AreEqual(true, obj.Invoke("checkInputs"));
		}
		[TestMethod()]
		public void wbCheckInputTest_Empty()
		{
			Whitebox whitebox = new Whitebox();
			PrivateObject obj = new PrivateObject(whitebox);

			Assert.AreEqual(false, obj.Invoke("checkInputs"));
		}
	}
}