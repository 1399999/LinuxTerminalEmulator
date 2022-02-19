namespace LinuxTerminalEmulatorUI;

public static class DirectoryCommandClass
{
    public static void DirectoryCommand(this MainWindow mainwindow)
    {
        var path = LineModel.LastLineDirectory;
        var folderDirs = Directory.GetDirectories(path);
        var fileDirs = Directory.GetFiles(path);
        var pathLength = path.Length;

        foreach (var dir in folderDirs)
        {
            var cutDir = dir.Substring(pathLength);

            mainwindow.MainTextBox.Text += "\n";
            mainwindow.MainTextBox.Text += cutDir;
            mainwindow.MainTextBox.Text += "           <DIR>";
        }

        foreach (var file in fileDirs)
        {
            var cutFile = file.Substring(pathLength);

            mainwindow.MainTextBox.Text += "\n";
            mainwindow.MainTextBox.Text += cutFile;
        }

        mainwindow.MainTextBox.Text += "\n\n";
        mainwindow.MainTextBox.Text += LineModel.LastLineDirectory;
        mainwindow.MainTextBox.Text += "> ";
    }

    public static void DirectoryPropertyCommand(this MainWindow mainwindow)
    {
        var path = LineModel.LastLineDirectory;
        var command = LineModel.LastLineCommand;

        DirectoryInfo dir = new DirectoryInfo(path);

        List<FileInfo> fileDirs = dir.GetFiles().ToList();
        List<DirectoryInfo> dirDirs = dir.GetDirectories().ToList();

        var cutCommand = command.Substring(6);

        if (cutCommand.ToLower() == " size")
        {
            foreach (FileInfo file in fileDirs)
            {
                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += file;
                mainwindow.MainTextBox.Text += "                     ";
                mainwindow.MainTextBox.Text += file.Length;
            }

            mainwindow.GetEndingText();
        }
        else if (cutCommand.ToLower() == " creation time")
        {
            foreach (FileInfo file in fileDirs)
            {
                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += file;
                mainwindow.MainTextBox.Text += "                     ";
                mainwindow.MainTextBox.Text += file.CreationTime;
            }

            foreach (var directory in dirDirs)
            {
                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += directory;
                mainwindow.MainTextBox.Text += "                     <DIR>                      ";
                mainwindow.MainTextBox.Text += directory.CreationTime;
            }

            mainwindow.GetEndingText();
        }
        else if (cutCommand.ToLower() == " attributes")
        {
            foreach (FileInfo file in fileDirs)
            {
                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += file;
                mainwindow.MainTextBox.Text += "                     <DIR>                      ";
                mainwindow.MainTextBox.Text += file.Attributes;
            }

            foreach (var directory in dirDirs)
            {
                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += directory;
                mainwindow.MainTextBox.Text += "                     ";
                mainwindow.MainTextBox.Text += directory.Attributes;
            }

            mainwindow.GetEndingText();
        }
        else if (cutCommand.ToLower() == " -a")
        {
            foreach (FileInfo file in fileDirs)
            {
                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += file;
                mainwindow.MainTextBox.Text += "                     ";
                mainwindow.MainTextBox.Text += file.Length;
                mainwindow.MainTextBox.Text += "                     ";
                mainwindow.MainTextBox.Text += file.CreationTime;
                mainwindow.MainTextBox.Text += "                     ";
                mainwindow.MainTextBox.Text += file.Attributes;
            }

            foreach (var directory in dirDirs)
            {
                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += directory;
                mainwindow.MainTextBox.Text += "                     <DIR>                      ";
                mainwindow.MainTextBox.Text += directory.CreationTime;
                mainwindow.MainTextBox.Text += "                     ";
                mainwindow.MainTextBox.Text += directory.Attributes;
            }

            mainwindow.GetEndingText();
        }
    }
}