namespace LinuxTerminalEmulatorUI;

public static class LocateFile
{
    public static void LocateFileCommand(this MainWindow mainwindow)
    {
        var path = LineModel.LastLineDirectory;
        var command = LineModel.LastLineCommand;
        var cutCommand = command.Substring(7);
        var pathLength = path.Length; 

        List<string> dirs = Directory.GetDirectories(path).ToList();
        List<string> files = Directory.GetFiles(path).ToList();

        foreach (var dir in dirs)
        {
            var cutDirName = dir.Substring(pathLength);

            if (cutDirName.Contains(cutCommand))
            {
                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += cutDirName;
                mainwindow.MainTextBox.Text += "              <DIR>";
            }
        }

        foreach (var file in files)
        {
            var cutFileName = file.Substring(pathLength);

            if (cutFileName.Contains(cutCommand))
            {
                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += cutFileName;
            }
        }

        mainwindow.GetEndingText();
    }
}

