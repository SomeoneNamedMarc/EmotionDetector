using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionDetector.Domain
{
    internal interface ILinq
    {
        ObservableCollection<string> GetMessages(string filePath);
        string GetEmotion(string filePath);
        ObservableCollection<string> GetAllEmotions(string filePath);
        ObservableCollection<string> GetAllFileNames(string filePath);
    }
}

