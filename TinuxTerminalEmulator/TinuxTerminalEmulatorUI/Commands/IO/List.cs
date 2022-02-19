namespace LinuxTerminalEmulatorUI;

public static class List
{
    public static void ListCommand(this MainWindow mainwindow)
    {
        var command = LineModel.LastLineCommand;
        var cutCommand = command.Substring(3);

        if (cutCommand == "drives")
        {
            var drives = DriveInfo.GetDrives().ToList();

            foreach (var drive in drives)
            {
                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += drive.ToString();
            }
        }
        else if (cutCommand.Contains("drives -p "))
        {
            var drives = DriveInfo.GetDrives().ToList();

            var kiloCutCommand = cutCommand.Substring(9);

            if (kiloCutCommand.Contains("-a"))
            {
                try
                {

                    foreach (var drive in drives)
                    {
                        string postfix = "Bytes";
                        long result = drive.TotalSize;

                        if (drive.TotalSize >= 10995116277760)
                        {
                            result = drive.TotalSize / 1099511627776;
                            postfix = "TB";
                        }
                        else if (drive.TotalSize >= 10737418240)//more than 1 GB
                        {
                            result = drive.TotalSize / 1073741824;
                            postfix = "GB";
                        }
                        else if (drive.TotalSize >= 10485760)//more that 1 MB
                        {
                            result = drive.TotalSize / 1048576;
                            postfix = "MB";
                        }
                        else if (drive.TotalSize >= 10240)//more that 1 KB
                        {
                            result = drive.TotalSize / 1024;
                            postfix = "KB";
                        }

                        long result2 = drive.AvailableFreeSpace;
                        string postfix2 = "Bytes";

                        if (drive.AvailableFreeSpace >= 10995116277760)
                        {
                            result2 = drive.AvailableFreeSpace / 1099511627776;
                            postfix2 = "TB";
                        }
                        else if (drive.AvailableFreeSpace >= 10737418240)//more than 1 GB
                        {
                            result2 = drive.AvailableFreeSpace / 1073741824;
                            postfix2 = "GB";
                        }
                        else if (drive.AvailableFreeSpace >= 10485760)//more that 1 MB
                        {
                            result2 = drive.AvailableFreeSpace / 1048576;
                            postfix2 = "MB";
                        }
                        else if (drive.AvailableFreeSpace >= 10240)//more that 1 KB
                        {
                            result2 = drive.AvailableFreeSpace / 1024;
                            postfix2 = "KB";
                        }

                        mainwindow.MainTextBox.Text += "\n";
                        mainwindow.MainTextBox.Text += drive.ToString();
                        mainwindow.MainTextBox.Text += "    ";
                        mainwindow.MainTextBox.Text += result2;
                        mainwindow.MainTextBox.Text += " ";
                        mainwindow.MainTextBox.Text += postfix2;
                        mainwindow.MainTextBox.Text += " free of ";
                        mainwindow.MainTextBox.Text += "    ";
                        mainwindow.MainTextBox.Text += result;
                        mainwindow.MainTextBox.Text += " ";
                        mainwindow.MainTextBox.Text += postfix;
                        mainwindow.MainTextBox.Text += "    ";
                        mainwindow.MainTextBox.Text += drive.DriveFormat;

                    }
                }
                catch
                {
                    
                }
            }
            else if (kiloCutCommand.Contains("type"))
            {
                foreach (var drive in drives)
                {
                    mainwindow.MainTextBox.Text += "\n";
                    mainwindow.MainTextBox.Text += drive.ToString();
                    mainwindow.MainTextBox.Text += "   ";
                    mainwindow.MainTextBox.Text += drive.DriveType;
                }
            }
            else if (kiloCutCommand.Contains("total space"))
            {
                foreach (var drive in drives)
                {
                    mainwindow.MainTextBox.Text += "\n";
                    mainwindow.MainTextBox.Text += drive.ToString();
                    mainwindow.MainTextBox.Text += "   ";
                    mainwindow.MainTextBox.Text += drive.TotalSize;
                }
            }
            else if (kiloCutCommand.Contains("avialable space"))
            {
                foreach (var drive in drives)
                {
                    mainwindow.MainTextBox.Text += "\n";
                    mainwindow.MainTextBox.Text += drive.ToString();
                    mainwindow.MainTextBox.Text += "   ";
                    mainwindow.MainTextBox.Text += drive.AvailableFreeSpace;
                }
            }
            else
            {
                mainwindow.MainTextBox.Text += "\n";
                mainwindow.MainTextBox.Text += "Unknown proterty:";
                mainwindow.MainTextBox.Text += kiloCutCommand;
            }
        }

        mainwindow.GetEndingText();
    }
}

