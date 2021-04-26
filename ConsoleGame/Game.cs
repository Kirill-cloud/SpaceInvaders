using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace ConsoleGame
{
    class Game
    {
        bool k = false;
        Unit[,] field = new Unit[30, 10];
        Player player = new Player();
        List<Player> projectiles=  new List<Player>();
        IVisualizer Visualizer;
        IInteractor interactor;
        int moder = 12;
        static int[] score = { 0 };
        static Timer timer;
        TimerCallback tm;


        public Game(IVisualizer visualizer, IInteractor interactor) 
        {
            this.interactor = interactor; 
            Visualizer = visualizer;
        }
        public void Start() 
        {
            
            tm = new TimerCallback(ProjectilePhx);
            tm += new TimerCallback(Visualizer.Drawer);

            timer = new Timer(tm,new GameParams(moder, score,field,projectiles),0,200);
            field[player.Y, player.X] = player;
            field[0, 0] = new Unit("Enemy1", 9);

            while (!k)
            {
                Comand(interactor.GetAction());
            }

        }
        void ProjectilePhx(object param)
        {
            List<Player> projectiles = (param as GameParams).projectiles;
            for (int i = 0; i < projectiles.Count; i++)
            {

                if (projectiles[i].Y == 0)
                {
                    field[projectiles[i].Y, projectiles[i].X] = null;
                    projectiles.Remove(projectiles[i]);
                }
                else
                {
                    field[projectiles[i].Y, projectiles[i].X] = null;
                    projectiles[i].Y--;
                    if (field[projectiles[i].Y, projectiles[i].X] != null && field[projectiles[i].Y, projectiles[i].X].Type=="Enemy1")
                    {
                        field[projectiles[i].Y, projectiles[i].X].Collision(1);
                        if (field[projectiles[i].Y, projectiles[i].X].Type=="Empty")
                        {
                            score[0]++;
                            field[projectiles[i].Y, projectiles[i].X] = null;
                        }
                        projectiles.Remove(projectiles[i]);
                    }
                    else
                    {
                        field[projectiles[i].Y, projectiles[i].X] = projectiles[i];
                    }
                }
            }
            
            EnemyGen(moder,ref k);
        }
        void Comand(string action) 
        {
            switch (action)
            {
                case "MoveLeft": field[player.Y, player.X] = null; player.Move(-1); field[player.Y, player.X] = player; break;
                case "MoveRight": field[player.Y, player.X] = null; player.Move(1); field[player.Y, player.X] = player; break;
                case "Shoot": Player temp = new Player(player.Y - 1, player.X);
                    if (!projectiles.Contains((Player)field[player.Y - 1, player.X]))
                    {
                        field[player.Y - 1, player.X] = temp;
                        projectiles.Add((Player)field[player.Y - 1, player.X]);
                    }
                    break;

            }
        }
        void EnemyGen(int x, ref bool k)
        {

            if (x % 10 == 0)
            {
                for (int i = field.GetLength(0) - 1; i > 0; i--)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        if (field[i - 1, j]!=null && field[i - 1, j].Type == "Enemy1")
                        {
                            var temp = field[i - 1, j];
                            field[i - 1, j] = null; ;
                            field[i, j] = temp;
                        }
                    }
                }
                Random r = new Random();

                for (int i = 0; i < field.GetLength(1); i++)
                {
                    field[0, i] = r.Next(2) == 1 ? new Unit("Enemy1", moder>199? 9:moder/20):null;
                }
            }

            for (int i = 0; i < field.GetLength(1); i++)
            {
                if (field[field.GetLength(0) - 1, i] != null && field[field.GetLength(0) - 1, i].Type == "Enemy1")
                {
                    k = true;
                }
            }
            moder++;
            if (k)
            {
                GameOver(interactor);
            }
        }
        static void GameOver(IInteractor interactor)
        {
            timer.Dispose();
            interactor.SaveRecord(score[0]);
        }

    }
}
