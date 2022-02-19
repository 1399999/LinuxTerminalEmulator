namespace LinuxTerminalEmulatorUI;
public static class ChangeDirectory
    {
    public static void ChangeDirectoryCommand(this MainWindow mainwindow)
    {
        var path = LineModel.LastLineDirectory;
        var command = LineModel.LastLineCommand;

        var cutCommand = command.Substring(3);

        if (cutCommand == "..")
        {
            List<List<string>> Indexs = new List<List<string>>();

            var newPath = "";

            Indexs.Add(path.Split("\\").ToList());

            foreach (var index in Indexs)
            {
                index.RemoveAt(index.Count - 1);
                index.RemoveAt(index.Count - 1);

                foreach (var item in index)
                {
                    var newString = newPath + item;
                    var newString2 = newString + "\\";
                    newPath = newString2;
                }
            }

            LineModel.LastLineDirectory = newPath;
        }
        else
        {
            var fullPath = path + cutCommand;

            DirectoryInfo newDir = new DirectoryInfo(fullPath);

            try
            {
                if (Directory.Exists(newDir.ToString()))
                {
                    LineModel.LastLineDirectory += cutCommand;
                    LineModel.LastLineDirectory += "\\";
                }
                else
                {
                    mainwindow.MainTextBox.Text += "\n";
                    mainwindow.MainTextBox.Text += "The directory ";
                    mainwindow.MainTextBox.Text += fullPath;
                    mainwindow.MainTextBox.Text += " deos not exist.";
                }

            }
            catch
            {
                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += "An error occured while create the directory.";
            }
        }

        mainwindow.GetEndingText();
    }   
}

