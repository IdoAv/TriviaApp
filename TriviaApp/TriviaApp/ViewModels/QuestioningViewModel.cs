using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using TriviaApp.Models;
using TriviaApp.Services;
using Xamarin.Forms;

namespace TriviaApp.ViewModels
{
    class QuestioningViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region fields
        private string question;
        private int correctAnswers;
        private int wrongAnswers;
        private bool nextQuestionEnabled;
        #endregion
        #region properties
        public string Question
        {
            get
            {
                return question;
            }
            set
            {
                if (question != value)
                {
                    question = value;
                    OnPropertyChanged();
                }
            }
        }
        public int CorrectAnswers
        {
            get
            {
                return correctAnswers;
            }
            set
            {
                if (correctAnswers != value)
                {
                    correctAnswers = value;
                    OnPropertyChanged();
                }
            }
        }
        public int WrongAnswers
        {
            get
            {
                return wrongAnswers;
            }
            set
            {
                if (wrongAnswers != value)
                {
                    wrongAnswers = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool NextQuestionEnabled
        {
            get
            {
                return nextQuestionEnabled;
            }
            set
            {
                if (nextQuestionEnabled != value)
                {
                    nextQuestionEnabled = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<ICommand> AnswersCommands { get; set; }
        public ObservableCollection<string> Answers { get; set; }
        public ObservableCollection<Color> AnswerColors { get; set; }
        public ICommand NextQuestionCommand { get; set; }
        #endregion
        #region constructor
        public QuestioningViewModel()
        {

        }
        #endregion
        #region functions
        private async void NewQuestion()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            AmericanQuestion question = await proxy.GetRandomQuestion();
        }
        #endregion
    }
}
