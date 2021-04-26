using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace Game
{
    public class GameOne
    {
        bool k = false;
        Unit[,] field = new Unit[30, 10];
        Player player = new Player(29, 5, 10);
        List<Player> projectiles = new List<Player>();
        IVisualizer Visualizer;
        IInteractor interactor;
        int moder = 12;
        static int[] score = { 0 };
        static Timer timer;
        TimerCallback tm;
        int difficultyLvl = 20;

        public GameOne(List<Player> proj, Unit[,] field)
        {
            projectiles = proj;
            this.field = field;
        }

        public GameOne(IVisualizer visualizer, IInteractor interactor)
        {
            this.interactor = interactor;
            Visualizer = visualizer;

            field[player.Y, player.X] = player;
        }
        public void Start()
        {
            tm = new TimerCallback(CallBacker);
            timer = new Timer(tm, new GameParams(moder, score, field, projectiles), 0, 50);

            while (!k && interactor.GetType().ToString() == "ConsoleGame.ConsoleInteraction")
            {
                Execute(interactor.GetAction());
            }

        }
        // сюда класть функции вызываемые по таймеру, будут срабатывть на каждый кадр
        void CallBacker(object param)
        {
            EnemyGen();
            ProjectilePhx(param);
            Visualizer.Drawer(param);
            CheckGameOver();
        }

        public void ProjectilePhx(object param)
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
                    if (field[projectiles[i].Y, projectiles[i].X] != null && field[projectiles[i].Y, projectiles[i].X].Type == "Enemy1")
                    {
                        field[projectiles[i].Y, projectiles[i].X].Collision(1);
                        if (field[projectiles[i].Y, projectiles[i].X].Type == "Empty")
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
        }
        public void Execute(string action)
        {
            switch (action)
            {
                case "MoveLeft": Move(-1); break;
                case "MoveRight": Move(1); break;
                case "Shoot": Shoot(); break;
            }
        }
        void Move(int direction)
        {
            field[player.Y, player.X] = null; player.Move(direction); field[player.Y, player.X] = player;
        }
        void Shoot()
        {
            Player projectile = new Player(player.Y - 1, player.X, 0);
            if (!projectiles.Contains((Player)field[player.Y - 1, player.X]))
            {
                field[player.Y - 1, player.X] = projectile;
                projectiles.Add((Player)field[player.Y - 1, player.X]);
            }
        }
        //генерация противников срабатывает каждый кратный difficultyLvl кадр
        public void EnemyGen()
        {
            moder++;
            if (moder % difficultyLvl == 0)
            {
                for (int i = field.GetLength(0) - 1; i > 0; i--)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        if (field[i - 1, j] != null && field[i - 1, j].Type == "Enemy1")
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
                    field[0, i] = r.Next(2) == 1 ? new Unit("Enemy1", moder > 199 ? 9 : moder / 20) : null;
                }
            }


        }
        void CheckGameOver()
        {
            for (int i = 0; i < field.GetLength(1); i++)
            {
                if (field[field.GetLength(0) - 1, i] != null && field[field.GetLength(0) - 1, i].Type == "Enemy1")
                {
                    k = true;
                }
            }
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
