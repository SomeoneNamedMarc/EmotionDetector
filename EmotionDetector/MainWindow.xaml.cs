using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _selectedEmotion;
        private string _selectedConversation;
        public ObservableCollection<string> Messages { get; set; }
        public ObservableCollection<string> Conversations { get; set; }
        public ObservableCollection<string> EmotionsSelection { get; set; }
        private LoadUseCase loadUseCase;
        private string path = "C:\\Users\\mikae\\source\\repos\\EmotionDetector\\EmotionDetector\\Files\\";

        public MainWindow()
        {
            InitializeComponent();
            loadUseCase = new LoadUseCase(new FileService());
            Messages = new ObservableCollection<string>
            {
                "Message 1 (right-aligned)",
                "Message 2 (left-aligned)",
                "Message 3 (right-aligned)",
                "Message 4 (left-aligned)",
                "Another long message to see the wrapping behavior. rEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee"
            };
            Conversations = loadUseCase.GetAllFileNames("C:\\Users\\mikae\\Source\\Repos\\EmotionDetector\\EmotionDetector\\Files\\");
            EmotionsSelection = loadUseCase.AllEmotions("C:\\Users\\mikae\\Source\\Repos\\EmotionDetector\\EmotionDetector\\Files\\");

            DataContext = this;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string SelectedEmotion
        {
            get => _selectedEmotion;
            set
            {
                _selectedEmotion = value;
                OnPropertyChanged(nameof(SelectedEmotion));
                MessageBox.Show($"You selected: {SelectedEmotion}");
            }
        }

        public string SelectedConversation
        {
            get => _selectedConversation;
            set
            {
                _selectedConversation = value;
                OnPropertyChanged(nameof(SelectedConversation));
                Messages = loadUseCase.GetMessages(path + SelectedConversation + ".xml");
                OnPropertyChanged(nameof(Messages));

            }
        }

        void btnSearchOnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SearchTermTextBox.Text);
        }
        void btnSearchOccuranceOnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SearchTermTextBox.Text);
        }
    }
}