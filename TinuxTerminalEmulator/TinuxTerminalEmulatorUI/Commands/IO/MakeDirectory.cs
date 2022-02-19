namespace LinuxTerminalEmulatorUI;
public static class MakeDirectory
    {
    public static void MakeDirectoryCommand(this MainWindow mainwindow)
    {
        var path = LineModel.LastLineDirectory;
        var command = LineModel.LastLineCommand;

        var cutCommand = command.Substring(6);

        var fullPath = path + cutCommand;

        DirectoryInfo newDir = new DirectoryInfo(fullPath);

        try
        {
            if (!Directory.Exists(newDir.ToString()))
            {
                newDir.Create();

                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += "The directory ";
                mainwindow.MainTextBox.Text += fullPath;
                mainwindow.MainTextBox.Text += " was succesfully created.";
                mainwindow.GetEndingText();
            }
            else
            {
                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += "The directory ";
                mainwindow.MainTextBox.Text += fullPath;
                mainwindow.MainTextBox.Text += " alrady exists.";
                mainwindow.GetEndingText();
            }

        }
        catch
        {
            mainwindow.MainTextBox.Text += "\n";
            mainwindow.MainTextBox.Text += "An error occured while create the directory.";
            mainwindow.GetEndingText();
        }
    }
}

