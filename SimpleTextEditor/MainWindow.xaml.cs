using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleTextEditor
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

        private void cutBtn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            if (String.IsNullOrEmpty(tb.SelectedText))
            {
                MessageBox.Show("Select text first");
                return;
            }
            Clipboard.SetDataObject(tb.SelectedText);
            if (tb.SelectedText == tb.Text)
            {
                tb.Text = "";
            }
            else {
                string textLeft = tb.Text.Substring(0, tb.Text.IndexOf(tb.SelectedText));
                tb.Text = textLeft + tb.Text.Substring(tb.SelectedText.Length + textLeft.Length);
            }
        }

        private void copyBtn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            if (String.IsNullOrEmpty(tb.SelectedText))
            {
                MessageBox.Show("Select text first");
                return;
            }
            Clipboard.SetDataObject(tb.SelectedText);
        }

        private void pasteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                string clipboardText = Clipboard.GetText(TextDataFormat.Text);
                tb.Text += clipboardText;
            }
            else MessageBox.Show("clipboard doesn't contain text");
        }
    }
}
