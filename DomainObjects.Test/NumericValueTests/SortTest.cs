using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DomainDrivenDesign.DomainObjects.Test.NumericValueTests
{
    [TestClass]
    public class SortTest
    {
        [TestMethod]
        public void WhenValues_ShouldSortDescending()
        {
            // arrange
            var n1 = Number.Create(1);
            var n2 = Number.Create(2);
            var n3 = Number.Create(3);
            var values = new[] { n2, n1, n3 };

            // act
            var numbers = values
                .OrderBy(x => x)
                .ToArray();

            // assert
            numbers[0].Should().Be(n1);
        }
    }
}
