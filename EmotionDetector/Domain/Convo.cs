using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionDetector.Domain
{
    public class Convo
    {
        public List<ChatMessage> ChatMessages = new List<ChatMessage>();

        public string Mood { get; set; } = "";
    }
}
