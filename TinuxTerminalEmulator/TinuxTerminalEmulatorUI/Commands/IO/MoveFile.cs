namespace LinuxTerminalEmulatorUI;

public static class MoveFile
{
    public static void MoveFileCommand(this MainWindow mainwindow)
    {
        var command = LineModel.LastLineCommand;
        var path = LineModel.LastLineDirectory;

        var cutCommand = command.Substring(3);

        var splitPath = cutCommand.Split(" ").ToList();

        if (splitPath.Count == 2)
        {
            try
            {
                var combinedPath = path + splitPath[0];

                FileInfo copyFile = new FileInfo(combinedPath);
                FileInfo toDir = new FileInfo(splitPath[1]);

                CopyFileModel.FileName = copyFile.Name;

                var fileLine = copyFile.GetAllLines().ToList();
                CopyFileModel.FileLines = fileLine;

                if (toDir.ToString().Contains("\\"))
                {
                    File.WriteAllLines(toDir.ToString(), fileLine);

                    copyFile.Delete();
                }
                else
                {
                    var toCombinedDir = path + splitPath[1];

                    File.WriteAllLines(toCombinedDir, fileLine);

                    copyFile.Delete();
                }

                mainwindow.WriteNewLine();
                mainwindow.MainTextBox.Text += copyFile.Name;
                mainwindow.MainTextBox.Text += " successfully moved to ";
                mainwindow.MainTextBox.Text += toDir.Name;
            }
            catch (Exception ex)
            {
                mainwindow.WriteNewLine();
                mainwindow.MainTextBox.Text += ex;
            }
        }
        else
        {
            mainwindow.WriteNewLine();
            mainwindow.MainTextBox.Text += "The command ";
            mainwindow.MainTextBox.Text += LineModel.LastLineCommand;
            mainwindow.MainTextBox.Text += " is not valid";
        }

        mainwindow.GetEndingText();
    }
}
