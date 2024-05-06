using System.Windows.Controls;
using System.Windows.Input;
using System;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows;

namespace MainMenu.Pages
{
    /// <summary>
    /// Interaction logic for Controls.xaml
    /// </summary>
    public partial class Controls : Page
    {
        private Label? UpdatedKey { get; set; }
        public Controls()
        {
            InitializeComponent();
        }
        private void CaptureKey(object sender, KeyEventArgs e)
        {
            if (UpdatedKey != null)
            {
                UpdatedKey.Content = e.Key;
                UpdatedKey.FontWeight = FontWeights.Normal;
                UpdatedKey = null;
            }
        }
        private void ChangeKey(object sender, MouseEventArgs e)
        {
            UpdatedKey = (Label)sender;
            UpdatedKey.FontWeight = FontWeights.UltraBold;
            Keyboard.Focus(this);
        }
    }
}
