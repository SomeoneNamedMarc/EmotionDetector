using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _selectedEmotion;
        private string _selectedConversation;
        public ObservableCollection<string> Messages { get; set; }
        public ObservableCollection<string> Conversations { get; set; }
        public ObservableCollection<string> EmotionsSelection { get; set; }
        private LoadUseCase loadUseCase;

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
            Conversations = new ObservableCollection<string>
            {
                "HappyConvo",
                "SadConvo",
                "AngryConvo",
                "REEE",
                "REEEE"
            };
            EmotionsSelection = loadUseCase.AllEmotions("C:\\Users\\marc0\\source\\repos\\EmotionDetector\\EmotionDetector\\Files\\");

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
                MessageBox.Show($"You selected: {SelectedConversation}");
            }
        }

        void btnSearchOnClick(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"Word: fun\nOccurs: {moodCol.Values.Max()} times.\nEmotion: {moodCol.MaxBy(entry => entry.Value).Key}");
            MessageBox.Show(SearchTermTextBox.Text);
            //messages.clear();
            //foreach (var message in loadusecase.getmessages("c:\\users\\mikae\\source\\repos\\emotiondetector\\emotiondetector\\files\\chatmessage1.0sad.xml"))
            //{
            //    messages.add(message.message);
            //}
        }
        void btnSearchOccuranceOnClick(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"Word: fun\nOccurs: {moodCol.Values.Max()} times.\nEmotion: {moodCol.MaxBy(entry => entry.Value).Key}");
            MessageBox.Show(SearchTermTextBox.Text);
        }
    }
}