using System;
using NUnit.Framework;
using ShapeLibrary.Shapes.Ellipse;
using ShapeLibrary.Shapes.Triangle;

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
		public void ReturnAcceptableValues(Ellipse triangle, double expectedAreaValue)
		{
			var actualValue = triangle.Area;
			Assert.AreEqual(expectedAreaValue, actualValue, AcceptableDelta);
		}

		[Test]
		public void DetermineWhetherTriangleIsRectangular_ReturnTrue()
		{
			var triangle = new Triangle(3, 4, 5);
			Assert.AreEqual(true, triangle.IsRectangular);
		}

		[Test]
		public void DetermineWhetherTriangleIsRectangular_ReturnFalse()
		{
			var triangle = new Triangle(3, 6, 5);
			Assert.AreEqual(false, triangle.IsRectangular);
		}
	}
}