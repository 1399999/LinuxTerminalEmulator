namespace LinuxTerminalEmulatorUI;

public static class Command
{
    public static void CheckCommand(this MainWindow mainwindow)
    {
        if (LineModel.LastLineCommand == "")
        {
            mainwindow.GetEndingTextSpecial();
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
        else if (LineModel.LastLineCommand.Contains("cd "))
        {
            mainwindow.ChangeDirectoryCommand();
        }
        else if (LineModel.LastLineCommand.Contains("dir -p "))
        {
            mainwindow.DirectoryPropertyCommand();
        }
        else if (LineModel.LastLineCommand.Contains("cp "))
        {
            mainwindow.CopyFileCommand();
        }
        else if (LineModel.LastLineCommand.Contains("mv "))
        {
            mainwindow.MoveFileCommand();
        }
        else if (LineModel.LastLineCommand.Contains("rmdir "))
        {
            mainwindow.DeleteEmptyDirectoryCommand();
        }
        else if (LineModel.LastLineCommand.Contains("mkfile "))
        {
            mainwindow.CreateFileCommand();
        }
        else if (LineModel.LastLineCommand.Contains("locate "))
        {
            mainwindow.LocateFileCommand();
        }
        else if (LineModel.LastLineCommand.Contains("findtxt "))
        {
            mainwindow.FindTextInFileCommand();
        }
        else if (LineModel.LastLineCommand == "exit")
        {
            mainwindow.Close();
        }
        else if (LineModel.LastLineCommand == "pwd")
        {
            mainwindow.MainTextBox.Text += "\n";
            mainwindow.MainTextBox.Text += LineModel.LastLineDirectory;
            mainwindow.GetEndingText();
        }
        else
        {
            mainwindow.MainTextBox.Text += "\n";
            mainwindow.MainTextBox.Text += "The command is unregognized.";
            mainwindow.GetEndingText();
        }
    }

    public static void GetEndingText(this MainWindow mainwindow)
    {
        mainwindow.MainTextBox.Text += "\n\n";
        mainwindow.MainTextBox.Text += LineModel.LastLineDirectory;
        mainwindow.MainTextBox.Text += "> ";
    }
    public static void GetEndingTextSpecial(this MainWindow mainwindow)
    {
        mainwindow.MainTextBox.Text += "\n";
        mainwindow.MainTextBox.Text += LineModel.LastLineDirectory;
        mainwindow.MainTextBox.Text += "> ";
    }
}
