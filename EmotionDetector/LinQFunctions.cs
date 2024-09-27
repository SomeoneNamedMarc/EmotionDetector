using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Xml.Linq;

namespace EmotionDetector
{
    internal class LinQFunctions
    {
        public LinQFunctions(string path)
        {
            iterateThroughAllFiles();
        }

        Dictionary<string, int> moodCol = new Dictionary<string, int>();

        public void iterateThroughAllFiles() 
        {
            string path = "C:\\Users\\Jannick W. Andresen\\Source\\Repos\\EmotionDetector\\EmotionDetector\\Files\\";
            string[] files = Directory.GetFiles(path);
            XElement elementMessages = XElement.Load(path);
            
            IEnumerable<string> MessagesContent = from Messages in elementMessages.Descendants("Message") select Messages.Value;
            
            foreach (var item in MessagesContent)
            {

            }
        }
        public void mostOccuringWords() 
        {
            //XElement ChatMessages = XElement.Load("Files\\");
            string path = "C:\\Users\\Jannick W. Andresen\\Source\\Repos\\EmotionDetector\\EmotionDetector\\Files\\";
            string[] files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                if (file.EndsWith(".xml"))
                {
                    
                    XElement ChatMessages = XElement.Load(file);

                    IEnumerable<string> EmotionContent = from Messages in ChatMessages.Descendants("Emotion") select Messages.Value;
                    IEnumerable<string> ChatContent = from Messages in ChatMessages.Descendants("Message") select Messages.Value;

                    if (!moodCol.ContainsKey(EmotionContent.First()))
                    {
                        moodCol.Add(EmotionContent.First(), 0);
                    }
                    
                    foreach (var item in ChatContent)
                    {
                        string[] splitMessages = item.Split(" ");
                        
                        foreach (var msg in splitMessages)
                        {
                            if (msg.ToLower().Contains("fun"))
                            {
                                moodCol[EmotionContent.First()] += 1;
                            }
                        }
                    }
                }
                Debug.WriteLine(moodCol.Values.Max());
            }
            MessageBox.Show($"Word: fun\nOccurs: {moodCol.Values.Max()} times.\nEmotion: {moodCol.MaxBy(entry => entry.Value).Key}");
        }
    }
}
