using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using testHepsiBurada;

namespace testHepsiBurada.UnitTest
{
    [TestClass]
    public class roverMoveTest
    {
        [TestMethod]
        public void roverMove_12N_To_13N()
        {
            var roverPosition = "1 2 N";
            var roverRoute = "LMLMLMLMM";

            Rover _testRover = new Rover(roverPosition);
            _testRover.Move(roverRoute);

            var expected = "1 3 N";

            Assert.AreEqual(expected, _testRover.Position.ToString(), false);
        }

        [TestMethod]
        public void roverMove_33E_To_51E()
        {
            var roverPosition = "3 3 E";
            var roverRoute = "MMRMMRMRRM";

            Rover _testRover = new Rover(roverPosition);
            _testRover.Move(roverRoute);

            var expected = "5 1 E";

            Assert.AreEqual(expected, _testRover.Position.ToString(), false);
        }
    }
}