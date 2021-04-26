using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Game;

namespace Game.Tests
{
    [TestClass()]
    public class PlayerTests
    {
        [TestMethod()]
        public void MoveZeroTest()
        {
            Player player = new Player(0,5);
            int expectedX = player.X;


            player.Move(0);


            Assert.AreEqual(player.X, expectedX);
        }

        [TestMethod()]
        public void MoveNegativeOKTest()
        {
            Player player = new Player(0, 5);
            int expectedX = (player.X - 1+10)%10;


            player.Move(-1);


            Assert.AreEqual(player.X, expectedX);
        }

        [TestMethod()]
        public void MovePositiveOKTest()
        {
            Player player = new Player(0, 5);
            int expectedX = (player.X + 1)%10;


            player.Move(1);


            Assert.AreEqual(player.X, expectedX);
        }


        [TestMethod()]
        public void MoveBiggerThenTest()
        {
            Player player = new Player(0, 5);
            int expectedX = player.X;


            player.Move(2);


            Assert.AreEqual(player.X, expectedX);
        }


        [TestMethod()]
        public void MoveBiggerThenNTest()
        {
            Player player = new Player(0, 5);
            int expectedX = player.X;


            player.Move(-2);


            Assert.AreEqual(player.X, expectedX);
        }

    }
}