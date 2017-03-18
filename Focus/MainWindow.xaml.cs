using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Focus
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

        public string FileName { get; private set; }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) // Is Alt key pressed
            {
                if (Keyboard.IsKeyDown(Key.O))
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == true)
                    {
                        UpdateEditingFileName(openFileDialog.FileName);
                        MenloStyleTextBox.Text = File.ReadAllText(this.FileName);
                    }
                    e.Handled = true;
                }
                else if (Keyboard.IsKeyDown(Key.S))
                {
                    if (String.IsNullOrWhiteSpace(this.FileName) )
                    {
                        SelectAndSaveFile();
                    }
                    else
                    {
                        SaveFile();
                    }
                    e.Handled = true;
                }
                else if (Keyboard.IsKeyDown(Key.E))
                {
                    SelectAndSaveFile();
                    e.Handled = true;
                }
            }
        }

        private void SelectAndSaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                UpdateEditingFileName(saveFileDialog.FileName);
                SaveFile();
            }
        }

        private void UpdateEditingFileName(String fileName)
        {
            this.FileName = fileName;
            EditingFileName.Text = "File Name: " + this.FileName;
        }

        private void SaveFile()
        {
            File.WriteAllText(this.FileName, MenloStyleTextBox.Text);
        }
    }
}
