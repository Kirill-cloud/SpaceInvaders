using System;
using System.Collections.Generic;
using System.Text;
using Game;

namespace WpfApp1
{
    class WpfInteraction : IInteractor
    {
        MainWindow mainWindow;
        public WpfInteraction(MainWindow main) 
        {
            mainWindow = main;
        }
        public string GetAction()
        {
            throw new NotImplementedException();
        }

        public void SaveRecord(int score)
        {
            mainWindow.Dispatcher.Invoke(() =>
            {
                mainWindow.Frame1.Navigate(new UserNamer(mainWindow));
            });
        }

        public void ShowRecords()
        {
            mainWindow.Dispatcher.Invoke(() =>
            {
                mainWindow.Frame1.Navigate(new RecordsTable());
            });
        }
    }
}
