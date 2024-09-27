using EmotionDetector.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionDetector.Infastructure
{
    public interface IMessageRepository
    {
        List<ChatMessage> LoadMessages(string filePath);
    }
}
