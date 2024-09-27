using System.Diagnostics;
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
using EmotionDetector.Domain;
using EmotionDetector.Infastructure;

namespace EmotionDetector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ILinq linq;
        public MainWindow()
        {
            InitializeComponent();
            linq = new FileService();
                       
        }
        private void LoadMessagesBtn_Click(object sender, RoutedEventArgs e)
        {
            var messages = linq.GetMessages("C:\\Users\\Jannick W. Andresen\\Source\\Repos\\EmotionDetector\\EmotionDetector\\xmlFiles\\ChatMessage1.0Sad.xml");  
            foreach (var message in messages)
            {
                MessageBox.Show($"Message: {message.Message}");
            }
        }
    }
}