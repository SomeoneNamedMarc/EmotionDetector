using EmotionDetector.Domain;
using System;
using System.Collections.Generic;
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
    }
}
