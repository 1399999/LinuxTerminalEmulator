namespace LinuxTerminalEmulatorUI;

public static class MianTextBox
{
    public static void WriteNewLine(this MainWindow mainwindow)
    {
        mainwindow.MainTextBox.Text += "\n";
    }
}

