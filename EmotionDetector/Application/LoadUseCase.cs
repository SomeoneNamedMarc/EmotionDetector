using EmotionDetector.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionDetector.Application
{
    internal class LoadUseCase
    {
        private readonly ILinq _repository;
        public LoadUseCase(ILinq repository)
        {
            _repository = repository;
        }

        public ObservableCollection<string> GetMessages(string filePath)
        {
            var allMessages = _repository.GetMessages(filePath);
            return allMessages;
        }

        public ObservableCollection<string> AllEmotions(string filePath)
        {
            return _repository.GetAllEmotions(filePath);
        }
        public ObservableCollection<string> GetAllFileNames(string filePath)
        {
            return _repository.GetAllFileNames(filePath);
        }
    }
}
