namespace LinuxTerminalEmulatorUI;

public static class DeleteDirectory
{
    public static void DeleteDirectoryCommand(this MainWindow mainwindow)
    {
        var path = LineModel.LastLineDirectory;
        var command = LineModel.LastLineCommand;

        var cutCommand = command.Substring(3);

        var fullPath = path + cutCommand;

        DirectoryInfo newDir = new DirectoryInfo(fullPath);

        try
        {
            if (Directory.Exists(newDir.ToString()))
            {
                    newDir.Delete();

                    mainwindow.MainTextBox.Text += "\n";
                    mainwindow.MainTextBox.Text += "The directory ";
                    mainwindow.MainTextBox.Text += fullPath;
                    mainwindow.MainTextBox.Text += " was succesfully deleted.";
                    mainwindow.MainTextBox.Text += "\n\n";
                    mainwindow.MainTextBox.Text += LineModel.LastLineDirectory;
                    mainwindow.MainTextBox.Text += "> ";
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
        catch
        {
            mainwindow.MainTextBox.Text += "\n";
            mainwindow.MainTextBox.Text += "An error occured while deleting the directory.";
            mainwindow.MainTextBox.Text += "\n\n";
            mainwindow.MainTextBox.Text += LineModel.LastLineDirectory;
            mainwindow.MainTextBox.Text += "> ";
        }
    }
}
