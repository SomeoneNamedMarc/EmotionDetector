using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EmotionDetector.Domain;

using System.Xml.Linq;
using EmotionDetector.InterfaceAdapter;

namespace EmotionDetector.Infastructure
{
    internal class LinqFunctions : IMessageRepository, ILinq
    {       
        public List<ChatMessage> LoadMessages(string filePath)
        {
            var messages = new List<ChatMessage>();
            var xml = XDocument.Load(filePath);

            messages = (from msg in xml.Descendants("message")
                        select new ChatMessage
                        {
                            Message = msg.Element("text").Value,
                        }).ToList();
            return messages;
        }
        public List<ChatMessage> GetMessages(string filePath)
        {
            return LoadMessages(filePath).ToList();
        }
    }
}
