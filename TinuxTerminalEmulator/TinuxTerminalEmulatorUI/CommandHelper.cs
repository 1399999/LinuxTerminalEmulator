using TinuxTerminalEmulatorUI;

namespace LinuxTerminalEmulatorUI;

public static class CommandHelper
{
    public static void DirectoryCommand(this MainWindow mainwindow)
    {
        var parentDir = LineModel.LastLineDirectory;
        var folderDirs = Directory.GetDirectories(parentDir);
        var fileDirs = Directory.GetFiles(parentDir);

        foreach (var dir in folderDirs)
        {
            mainwindow.MainTextBox.Text += "\n";
            mainwindow.MainTextBox.Text += dir;
            mainwindow.MainTextBox.Text += "           <DIR>";
        }

        foreach (var file in fileDirs)
        {
            mainwindow.MainTextBox.Text += "\n";
            mainwindow.MainTextBox.Text += file;
        }

        mainwindow.MainTextBox.Text += "\n\n";
        mainwindow.MainTextBox.Text += LineModel.LastLineDirectory;
        mainwindow.MainTextBox.Text += "> ";
    }
    public static void ShowFileContents(this MainWindow mainwindow)
    {
        var parentDir = LineModel.LastLineDirectory;
        var command = LineModel.LastLineCommand;

        var cutCommand = command.Substring(4);

        var fullPath = parentDir + cutCommand;

        if (File.Exists(fullPath))
        {
            try
            {
                var lines = File.ReadAllLines(fullPath);

                foreach (var line in lines)
                {
                    mainwindow.MainTextBox.Text += "\n";
                    mainwindow.MainTextBox.Text += line;
                }

                mainwindow.MainTextBox.Text += "\n\n";
                mainwindow.MainTextBox.Text += LineModel.LastLineDirectory;
                mainwindow.MainTextBox.Text += "> ";
            }
            catch
            {
                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += "An error occured while trying to display the contents of ";
                mainwindow.MainTextBox.Text += cutCommand;
                mainwindow.MainTextBox.Text += "\n\n";
                mainwindow.MainTextBox.Text += LineModel.LastLineDirectory;
                mainwindow.MainTextBox.Text += "> ";
            }
        }
        else
        {
            mainwindow.MainTextBox.Text += "\n";
            mainwindow.MainTextBox.Text += "The path ";
            mainwindow.MainTextBox.Text += fullPath;
            mainwindow.MainTextBox.Text += " does not exist";
            mainwindow.MainTextBox.Text += "\n\n";
            mainwindow.MainTextBox.Text += LineModel.LastLineDirectory;
            mainwindow.MainTextBox.Text += "> ";
        }
    }
}
