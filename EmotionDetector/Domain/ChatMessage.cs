using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionDetector.Domain
{
    public class ChatMessage
    {
        public string Message { get; set; }
        public ChatMessage(string msg) 
        { 
            Message = msg;
        }
    }
}
