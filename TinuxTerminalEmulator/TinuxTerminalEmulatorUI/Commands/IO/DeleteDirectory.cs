﻿namespace LinuxTerminalEmulatorUI;

public static class DeleteDirectory
{
    public static void DeleteDirectoryCommand(this MainWindow mainwindow)
    {
        var path = LineModel.LastLineDirectory;
        var command = LineModel.LastLineCommand;

        var cutCommand = command.Substring(3);

        var fullPath = path + cutCommand;
        
        try
        {
            if (Directory.Exists(fullPath))
            {
                DirectoryInfo dir = new DirectoryInfo(fullPath);

                dir.Delete();

                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += "The directory ";
                mainwindow.MainTextBox.Text += fullPath;
                mainwindow.MainTextBox.Text += " was succesfully deleted.";
                mainwindow.GetEndingText();
            }
            else if (File.Exists(fullPath))
            {
                FileInfo file = new FileInfo(fullPath);

                file.Delete();

                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += "The file ";
                mainwindow.MainTextBox.Text += fullPath;
                mainwindow.MainTextBox.Text += " was succesfully deleted.";
                mainwindow.GetEndingText();
            }
            else
            {
                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += "The path ";
                mainwindow.MainTextBox.Text += fullPath;
                mainwindow.MainTextBox.Text += " does not exist";
                mainwindow.GetEndingText();
            }

        }
        catch
        {
            mainwindow.MainTextBox.Text += "\n";
            mainwindow.MainTextBox.Text += "An error occured while deleting the directory.";
            mainwindow.GetEndingText();
        }
    }

    public static void DeleteEmptyDirectory(this MainWindow mainwindow)
    {
        try
        {
            var path = LineModel.LastLineDirectory;

            DirectoryInfo dir = new DirectoryInfo(path);

            var files = dir.GetFiles();

            var dirs = dir.GetDirectories();

            if (files.Length == 0 && dirs.Length == 0)
            {
                dir.Delete();

                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += "The directory ";
                mainwindow.MainTextBox.Text += path;
                mainwindow.MainTextBox.Text += " was succesfully deleted.";
                mainwindow.GetEndingText();
            }
            else
            {
                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += "The directory ";
                mainwindow.MainTextBox.Text += path;
                mainwindow.MainTextBox.Text += " contans other directories/files so it can olny be deleted by using the rm command.";
                mainwindow.GetEndingText();
            }
        }
        catch
        {
            mainwindow.MainTextBox.Text += "\n";
            mainwindow.MainTextBox.Text += "An error occured while deleting the directory.";
            mainwindow.GetEndingText();
        }
    }
}
