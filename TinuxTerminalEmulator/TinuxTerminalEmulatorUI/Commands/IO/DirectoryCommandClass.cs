namespace LinuxTerminalEmulatorUI;

public static class DirectoryCommandClass
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
}
