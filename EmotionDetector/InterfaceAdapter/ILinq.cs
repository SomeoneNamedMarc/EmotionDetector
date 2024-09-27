using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmotionDetector.Domain;

namespace EmotionDetector.InterfaceAdapter
{
    internal interface ILinq
    {
        List<ChatMessage> GetMessages(string filePath); 
    }
}

