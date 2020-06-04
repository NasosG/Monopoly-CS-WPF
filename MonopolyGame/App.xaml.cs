using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MonopolyGame
{
    public class Program 
    {
        /// <summary>
        /// Application Entry Point.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            MonopolyGame.App app = new MonopolyGame.App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
