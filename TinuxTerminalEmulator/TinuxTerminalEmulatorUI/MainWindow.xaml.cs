namespace LinuxTerminalEmulatorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        FileInfo commandDir = new FileInfo(@"C:\LinuxTerminalEmulator\Commands.txt");
        FileInfo translatedCommandLineDir = new FileInfo(@"C:\LinuxTerminalEmulator\TranslatedCommandLines.txt");
        FileInfo translatedCommandDir = new FileInfo(@"C:\LinuxTerminalEmulator\TranslatedCommands.txt");

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DirectoryInfo lteDir = new DirectoryInfo(@"C:\LinuxTerminalEmulator");

            if (!Directory.Exists(lteDir.ToString()))
            {
                lteDir.Create();
            }
            else
            {

            }

            if (!File.Exists(commandDir.ToString()))
            {
                commandDir.Create();
            }
            else
            {

            }
            if (!File.Exists(translatedCommandLineDir.ToString()))
            {
                translatedCommandLineDir.Create();
            }
            else
            {

            }
        }

        private void MainTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                // Does not add enters in the begining

                e.Handled = true;

                // First translation
                string code = MainTextBox.Text;

                commandDir.WriteLineToFile(code);

                // Second Translation

                var lines = commandDir.GetAllLines();

                List<string> corLines = new List<string>();

                using (StreamReader sreader = commandDir.OpenText())
                {
                    foreach (var line in lines)
                    {
                        if (line.Includes(@"\>"))
                        {
                            corLines.Add(line);
                        }
                    }
                }

                using (StreamWriter swriter = translatedCommandLineDir.CreateText())
                {
                    foreach (var corLine in corLines)
                    {
                        corLine.Trim();
                        swriter.WriteLine(corLine);
                    }
                }

                // Third translation

                List<string> commandLines = translatedCommandLineDir.GetAllLines();

                List<string> dirs = new List<string>();

                using (StreamWriter swriter = translatedCommandDir.CreateText())
                {
                    List<List<string>> seperatedCommandLineList = new List<List<string>>();

                    foreach (var commandLine in commandLines)
                    {
                        seperatedCommandLineList.Add(commandLine.Split("\\> ").ToList());
                    }

                    foreach (var seperatedCommandLine in seperatedCommandLineList)
                    {
                        if (seperatedCommandLine.Count > 2)
                        {
                            MainTextBox.Text += "\n";
                            MainTextBox.Text += @"Error: Cannot have more than 2 \> s";
                        }

                        dirs.Add(seperatedCommandLine[0]);

                        seperatedCommandLine.RemoveAt(0);

                        foreach (string commandLine in seperatedCommandLine)
                        {
                            swriter.WriteLine(commandLine);
                        }
                    }
                }

                var lc = translatedCommandDir.GetLastLine();

                LineModel.LastLineCommand = lc;

                var ld = dirs[dirs.Count - 1];

                ld += "\\";

                LineModel.LastLineDirectory = ld;

                // Check what each command is

                this.CheckCommand();

                // Set couror to the end of the textbox

                MainTextBox.Select(MainTextBox.Text.Length, 0);
                
            }

            else if (e.Key == Key.Up)
            {

            }

            else if (e.Key == Key.Down)
            {

            }
        }
    }
}
