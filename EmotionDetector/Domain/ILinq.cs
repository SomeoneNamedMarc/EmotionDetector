using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionDetector.Domain
{
    internal interface ILinq
    {
        List<ChatMessage> GetMessages(string filePath);
        string GetEmotion(string filePath);
    }
}

