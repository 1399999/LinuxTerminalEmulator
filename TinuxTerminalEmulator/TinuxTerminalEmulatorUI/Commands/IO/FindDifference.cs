namespace LinuxTerminalEmulatorUI;

public static class FindDifference
{
    public static void FindDifferenceCommand(this MainWindow mainwindow)
    {
        var path = LineModel.LastLineDirectory;
        var command = LineModel.LastLineCommand;
        var cutCommand = command.Substring(5);

        var splitCommand = cutCommand.Split(' ').ToList();

        if (splitCommand.Count == 2)
        {
            try
            {
                var compare1 = splitCommand[0];
                var fullPath1 = path + compare1;
                
                var compare2 = splitCommand[1];

                if (compare2.Contains("\\"))
                {

                }
                else
                {
                    var fullPath2 = path + compare2;

                    FileInfo file1 = new FileInfo(fullPath1);
                    var lines1 = file1.GetAllLines(); 
                    FileInfo file2 = new FileInfo(fullPath2);
                    var lines2 = file2.GetAllLines();

                    for (int lineNumber = 1; lineNumber < file1.Length; lineNumber++)
                    {
                        DifferenceModel.LineContents1 = file1.ReadLineByIndex(lineNumber);
                        DifferenceModel.LineContents2 = file2.ReadLineByIndex(lineNumber);

                        if (DifferenceModel.LineContents1 != DifferenceModel.LineContents2)
                        {
                            mainwindow.WriteNewLine();
                            mainwindow.MainTextBox.Text += "Line Number ";
                            mainwindow.MainTextBox.Text += lineNumber;
                            mainwindow.WriteNewLine();
                            mainwindow.MainTextBox.Text += file1.Name;
                            mainwindow.MainTextBox.Text += ": ";
                            mainwindow.MainTextBox.Text += DifferenceModel.LineContents1;
                            mainwindow.WriteNewLine();
                            mainwindow.MainTextBox.Text += file2.Name;
                            mainwindow.MainTextBox.Text += ": ";
                            mainwindow.MainTextBox.Text += DifferenceModel.LineContents2;
                            mainwindow.WriteNewLine();
                        }
                        else
                        {

                        }
                    }
                }
            }
            catch
            {
                mainwindow.WriteNewLine();
                mainwindow.MainTextBox.Text += "An error occured while finding the difference of the file.";
            }
        }
        else
        {
            mainwindow.WriteNewLine();
            mainwindow.MainTextBox.Text += "Invalid number of spaces.";
        }

        mainwindow.GetEndingText();
    }
}

