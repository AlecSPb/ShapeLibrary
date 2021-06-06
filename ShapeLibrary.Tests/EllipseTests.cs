using System;
using NUnit.Framework;
using ShapeLibrary.Shapes.Ellipse;

namespace ShapeLibrary.Tests
{
	[TestFixture]
	public class EllipseTests
	{
		private const double AcceptableDelta = 1e-5;

		private static readonly object[] AcceptableTestData =
		{
			new object[]
			{
				new Ellipse(0),
				0
			},
			new object[]
			{
				new Ellipse(1),
				Math.PI
			},
			new object[]
			{
				new Ellipse(19),
				1134.114948
			},
			new object[]
			{
				new Ellipse(49),
				7542.963961
			},
			new object[]
			{
				new Ellipse(3.9),
				47.783624
			},
			new object[]
			{
				new Ellipse(17.8),
				995.382216
			}
		};

		[TestCaseSource(nameof(AcceptableTestData))]
		public void ReturnAcceptableValues(Ellipse ellipse, double expectedAreaValue)
		{
			var actualValue = ellipse.Area;
			Assert.AreEqual(expectedAreaValue, actualValue, AcceptableDelta);
		}
	}
}