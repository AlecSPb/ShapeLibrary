using NUnit.Framework;
using ShapeLibrary.Shapes.Triangle;

namespace ShapeLibrary.Tests
{
	[TestFixture]
	public class TriangleTests
	{
		private const double AcceptableDelta = 1e-5;

		private static readonly object[] AcceptableTestData =
		{
			new object[]
			{
				new Triangle(0, 0, 0),
				0
			},
			new object[]
			{
				new Triangle(3, 4, 5),
				6
			},
			new object[]
			{
				new Triangle(6,4,5),
				9.921567416492215
			},
			new object[]
			{
				new Triangle(37, 21, 30.5),
				320.24950600078995
			},
			new object[]
			{
				new Triangle(102, 15, 91),
				490.5670188669434
			},
			new object[]
			{
				new Triangle(57, 22, 71),
				534.9766350038102
			}
		};

		private static readonly object[] NotAcceptableTestData =
		{
			new Triangle(12, 22, 99),
			new Triangle(11, 0, 56),
			new Triangle(8, -5, 14),
			new Triangle(1, 33, 502),
			new Triangle(64, 23, 32)
		};

		[TestCaseSource(nameof(AcceptableTestData))]
		public void ReturnAcceptableValues(Triangle triangle, double expectedAreaValue)
		{
			var actualValue = triangle.Area;
			Assert.AreEqual(expectedAreaValue, actualValue, AcceptableDelta);
		}

		[TestCaseSource(nameof(NotAcceptableTestData))]
		public void AreSpecifiedTriangleDoesNotExist(Triangle triangle)
		{
			var actualValue = triangle.Area;
			Assert.AreEqual(double.NaN, actualValue);
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