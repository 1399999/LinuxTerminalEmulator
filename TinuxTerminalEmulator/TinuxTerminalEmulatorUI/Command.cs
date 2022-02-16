namespace LinuxTerminalEmulatorUI;

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
        else if (LineModel.LastLineCommand == "dir" || LineModel.LastLineCommand == "ls")
        {
            mainwindow.DirectoryCommand();
        }
        else if (LineModel.LastLineCommand.Contains("cat "))
        {
            mainwindow.ShowFileContentsCommand();
        }
        else if (LineModel.LastLineCommand.Contains("mkdir "))
        {
            mainwindow.MakeDirectoryCommand();
        }
        else if (LineModel.LastLineCommand.Contains("rm "))
        {
            mainwindow.DeleteDirectoryCommand();
        }
        else
        {

        }
    }
}
