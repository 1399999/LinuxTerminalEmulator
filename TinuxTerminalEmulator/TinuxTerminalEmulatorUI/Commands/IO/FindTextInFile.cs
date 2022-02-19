namespace LinuxTerminalEmulatorUI;

public static class FindTextInFile
{
    public static void FindTextInFileCommand(this MainWindow mainwindow)
    {
        var path = LineModel.LastLineDirectory;
        var command = LineModel.LastLineCommand;
        var cutCommand = command.Substring(8);

        var splitCommand = cutCommand.Split(' ').ToList();

        if (splitCommand.Count == 3)
        {
            var text = splitCommand[0];
            var fileName = splitCommand[2];

            var fullPath = path + fileName;

            if (File.Exists(fullPath))
            {
                var lines = File.ReadAllLines(fullPath);

                int LineNumber = 1;

                foreach (var line in lines)
                {
                    if (line.Includes(text))
                    {
                        mainwindow.MainTextBox.Text += "\n";
                        mainwindow.MainTextBox.Text += LineNumber;
                        mainwindow.MainTextBox.Text += "   ";
                        mainwindow.MainTextBox.Text += line;
                    }

                    LineNumber++;
                }
            }
        }
        else
        {
            mainwindow.MainTextBox.Text += "\n";
            mainwindow.MainTextBox.Text += "Invalid number of spaces.";
        }

        mainwindow.GetEndingText();
    }
}

