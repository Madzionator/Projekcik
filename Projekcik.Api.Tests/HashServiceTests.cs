using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Projekcik.Api.Services;

namespace Projekcik.Api.Tests
{
    [TestFixture]
    public class HashServiceTests
    {
        [Test]
        public void ShouldHashAndCheckCorrectly()
        {
            //Arrange
            var hashService = new HashService();
            var password = "witam";

            //Act
            var hashed = hashService.Hash(password);
            var isCorrect = hashService.Check(hashed, password);

            //Assert
            Assert.IsTrue(isCorrect);
        }
    }
}
