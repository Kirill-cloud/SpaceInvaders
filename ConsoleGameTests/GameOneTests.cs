using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Tests
{
    [TestClass()]
    public class GameOneTests
    {
        [TestMethod()]
        public void ProjectileExitTest()
        {

            List<Player> projectiles = new List<Player>
            {
                new Player(0, 5)
            };
            Unit[,] field = new Unit[10, 10];

            GameOne GameOne = new GameOne(new List<Player>(),new Unit[10,30]);


            GameOne.ProjectilePhx(new GameParams(0, new int[] { 0 }, field, projectiles));


            Assert.AreEqual(0, projectiles.Count);
        }

        [TestMethod()]
        public void ProjectileCollideExitTest()
        {

            List<Player> projectiles = new List<Player>
            {
                new Player(1, 5)
            };
            Unit[,] field = new Unit[10, 10];
            field[0, 5] = new Unit("Enemy1", 5);

            GameOne GameOne = new GameOne(projectiles, field);


            GameOne.ProjectilePhx(new GameParams(10, new int[] { 0 }, field, projectiles));


            Assert.AreEqual(0, projectiles.Count);
        }

        [TestMethod()]
        public void ProjectileCollideDestoyTest()
        {

            List<Player> projectiles = new List<Player>
            {
                new Player(1, 5)
            };
            Unit[,] field = new Unit[10, 10];
            field[0, 5] = new Unit("Enemy1", 1);

            GameOne GameOne = new GameOne(projectiles, field);




            GameOne.ProjectilePhx(new GameParams(10, new int[] { 0 }, field, projectiles));


            Assert.AreEqual(null, field[0, 5]);
            Assert.AreEqual(0, projectiles.Count);
        }

        [TestMethod()]
        public void EnemyNeedToGenTest()
        {
            Unit[,] field = new Unit[30, 10];
            Unit x = new Unit("Enemy1", 5);
            field[0, 5] = x;
            List<Player> projectiles = new List<Player>();

            GameOne game = new GameOne(projectiles, field);
            for (int i = 0; i < 20; i++)
            {
                game.EnemyGen();
            }

            game.EnemyGen();


            Assert.AreNotEqual(x, field[0, 5]);

            Assert.AreEqual(x, field[1, 5]);
        }

        [TestMethod()]
        public void EnemyNotNeedToGenTest()
        {
            Unit[,] field = new Unit[30, 10];
            Unit x = new Unit("Enemy1", 5);
            field[0, 5] = x;
            List<Player> projectiles = new List<Player>();

            GameOne game = new GameOne(projectiles, field);
            game.EnemyGen();

            Assert.AreNotEqual(x, field[1, 5]);

            Assert.AreEqual(x, field[0, 5]);
        }


    }
}