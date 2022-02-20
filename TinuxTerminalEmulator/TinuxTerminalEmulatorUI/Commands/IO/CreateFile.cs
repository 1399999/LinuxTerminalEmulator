namespace LinuxTerminalEmulatorUI;

public static class CreateFile
{
    public static void CreateFileCommand(this MainWindow mainwindow)
    {
        var path = LineModel.LastLineDirectory;
        var command = LineModel.LastLineCommand;

        var cutCommand = command.Substring(7);

        var fullPath = path + cutCommand;

        FileInfo newDir = new FileInfo(fullPath);

        try
        {
            if (!File.Exists(newDir.ToString()))
            {
                newDir.Create();

                mainwindow.WriteNewLine();
                mainwindow.MainTextBox.Text += "The file ";
                mainwindow.MainTextBox.Text += fullPath;
                mainwindow.MainTextBox.Text += " was succesfully created.";
            }
            else
            {
                mainwindow.WriteNewLine();
                mainwindow.MainTextBox.Text += "The file ";
                mainwindow.MainTextBox.Text += fullPath;
                mainwindow.MainTextBox.Text += " alrady exists.";
            }

        }
        catch
        {
            mainwindow.WriteNewLine();
            mainwindow.MainTextBox.Text += "An error occured while create the directory.";
        }

        mainwindow.GetEndingText();
    }
}
