namespace LinuxTerminalEmulatorUI;

public static class CopyFile
{
    public static void CopyFileCommand(this MainWindow mainwindow)
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
                }
                else
                {
                    var toCombinedDir = path + splitPath[1];
                    
                    File.WriteAllLines(toCombinedDir, fileLine);
                }

                mainwindow.WriteNewLine();
                mainwindow.MainTextBox.Text += copyFile.Name;
                mainwindow.MainTextBox.Text += " successfully copied to ";
                mainwindow.MainTextBox.Text += toDir.Name;
            }
            catch
            {
                mainwindow.WriteNewLine();
                mainwindow.MainTextBox.Text += "An error occured while copying the file.";
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
