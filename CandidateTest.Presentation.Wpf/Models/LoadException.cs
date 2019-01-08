using System;

namespace CandidateTest.Presentation.Wpf.Models
{
    internal sealed class LoadException : Exception
    {
        public LoadException(string message) : base(message)
        {
        }
    }
}