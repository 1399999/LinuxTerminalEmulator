using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxTerminalEmulatorUI
{
    public static class Command
    {
        public static void CheckCommand(this MainWindow mainwindow)
        {
            if (LineModel.LastLineCommand == "")
            {
                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += LineModel.LastLineDirectory;
                mainwindow.MainTextBox.Text += "> ";
            }
        }
    }
}
