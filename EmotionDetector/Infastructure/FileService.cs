using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EmotionDetector.Domain;

using System.Xml.Linq;

namespace EmotionDetector.Infastructure
{
    internal class FileService : ILinq
    {       
        //public List<ChatMessage> LoadMessages(string filePath)
        //{
        //    var messages = new List<ChatMessage>();
        //    var xml = XDocument.Load(filePath);

        //    messages = (from msg in xml.Descendants("message")
        //                select new ChatMessage
        //                {
        //                    Message = msg.Element("text").Value,
        //                }).ToList();
        //    return messages;
        //}
        public List<ChatMessage> GetMessages(string filePath)
        {
            Convo conversation = new Convo();

            XElement chatMessages = XElement.Load(filePath);

            IEnumerable<string> chatContent = from Messages in chatMessages.Descendants("Message") select Messages.Value;

            conversation.Mood = GetEmotion(filePath);

            List<ChatMessage> messages = new List<ChatMessage>();

            foreach (string chatMessage in chatContent)
            {
                messages.Add(new ChatMessage(chatMessage));
            }

            conversation.ChatMessages = messages;

            return conversation.ChatMessages;
        }

        public string GetEmotion(string filePath)
        {
            XElement chatMessages = XElement.Load(filePath);

            IEnumerable<string> emotionContent = from Messages in chatMessages.Descendants("Emotion") select Messages.Value;

            return emotionContent.First();
        }
    }
}
