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
                mainwindow.MainTextBox.Text += "\n\n";
                mainwindow.MainTextBox.Text += LineModel.LastLineDirectory;
                mainwindow.MainTextBox.Text += "> ";
            }
            else
            {
                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += "The directory ";
                mainwindow.MainTextBox.Text += fullPath;
                mainwindow.MainTextBox.Text += " alrady exists.";
                mainwindow.MainTextBox.Text += "\n\n";
                mainwindow.MainTextBox.Text += LineModel.LastLineDirectory;
                mainwindow.MainTextBox.Text += "> ";
            }

        }
        catch
        {
            mainwindow.MainTextBox.Text += "\n";
            mainwindow.MainTextBox.Text += "An error occured while create the directory.";
            mainwindow.MainTextBox.Text += "\n\n";
            mainwindow.MainTextBox.Text += LineModel.LastLineDirectory;
            mainwindow.MainTextBox.Text += "> ";
        }
    }
}

