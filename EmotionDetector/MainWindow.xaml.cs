using System.Collections.ObjectModel;
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
using EmotionDetector.Application;
using EmotionDetector.Domain;
using EmotionDetector.Infastructure;

namespace EmotionDetector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   

        public ObservableCollection<string> Messages { get; set; }
        public ObservableCollection<string> Conversations { get; set; }
        public ObservableCollection<string> EmotionsSelection { get; set; }
        private LoadUseCase loadUseCase;

        public MainWindow()
        {
            InitializeComponent();
            Messages = new ObservableCollection<string>
            {
                "Message 1 (right-aligned)",
                "Message 2 (left-aligned)",
                "Message 3 (right-aligned)",
                "Message 4 (left-aligned)",
                "Another long message to see the wrapping behavior. rEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee"
            };
            Conversations = new ObservableCollection<string>
            {
                "HappyConvo",
                "SadConvo",
                "AngryConvo",
                "REEE",
                "REEEE"
            };
            EmotionsSelection = new ObservableCollection<string>
            {
                "None",
                "HappyConvo",
                "SadConvo",
                "AngryConvo",
                "REEE",
                "REEEE"
            };

            DataContext = this;

            loadUseCase = new LoadUseCase(new FileService());
        }

        void btnSearchOnClick(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"Word: fun\nOccurs: {moodCol.Values.Max()} times.\nEmotion: {moodCol.MaxBy(entry => entry.Value).Key}");
            MessageBox.Show(SearchTermTextBox.Text);
        }
        void btnSearchOccuranceOnClick(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"Word: fun\nOccurs: {moodCol.Values.Max()} times.\nEmotion: {moodCol.MaxBy(entry => entry.Value).Key}");
            MessageBox.Show(SearchTermTextBox.Text);
        }
    }
}