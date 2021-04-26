using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Game;

namespace Game.Tests
{
    [TestClass()]
    public class UnitTests
    {
        [TestMethod()]
        public void CollisionTest()
        {
            // arrange
            Unit unit = new Unit("", 5);
            Unit expected = new Unit("", 4);

            // act

            unit.Collision(1);

            // assert
            Assert.AreEqual(unit.Health, expected.Health);
        }


        [TestMethod()]
        public void CollisionHealTest()
        {
            // arrange
            Unit unit = new Unit("", 5);
            Unit expected = new Unit("", 6);

            // act
            unit.Collision(-1);
            // assert

            Assert.AreEqual(unit.Health, expected.Health);
        }

        [TestMethod()]
        public void EmptyfyByZeroTest()
        {
            // arrange
            Unit unit = new Unit("Enemy", 1);
            Unit expected = new Unit("Empty", 0);

            // act

            unit.Collision(1);
            // assert

            Assert.AreEqual(unit.Type, expected.Type);
        }


        [TestMethod()]
        public void EmptyfyLessThenZeroTest()
        {
            // arrange
            Unit unit = new Unit("Enemy", 1);
            Unit expected = new Unit("Empty", 0);

            // act

            unit.Collision(2);
            // assert

            Assert.AreEqual(unit.Type, expected.Type);
        }


        [TestMethod()]
        public void EmptyfyMoreThenZeroTest()
        {
            // arrange
            Unit unit = new Unit("Enemy", 3);
            Unit expected = new Unit("Enemy", 1);

            // act

            unit.Collision(2);
            // assert

            Assert.AreEqual(unit.Type, expected.Type);
        }

        [TestMethod()]
        public void CollisionNotRevive()
        {
            // arrange
            Unit unit = new Unit("Empty", 0);
            Unit expected = new Unit("Empty", 0);

            // act

            unit.Collision(-2);
            // assert

            Assert.AreEqual(unit.Type, expected.Type);
            Assert.AreEqual(unit.Health, expected.Health);
        }
    }
}