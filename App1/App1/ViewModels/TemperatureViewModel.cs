using System;
using App1.Models;
using App1.Services;

namespace App1.ViewModels
{
    public class TemperatureViewModel : BaseViewModel, IObserver<Temperature>
    {
        private IDisposable unsubscriber;
        private Temperature last;
        private bool error;
        private TemperatureMonitor _service = new TemperatureMonitor();

        public TemperatureViewModel()
        {
            Temp = new Temperature(0.0m, DateTime.Now);
            Subscribe(_service);
        }

        public Temperature Temp
        {
            get => last;
            set
            {
                last = value;
                OnPropertyChanged();
            }
        }

        public bool Error
        {
            get => error;
            set
            {
                error = value;
                OnPropertyChanged();
            }
        }

        public virtual void Subscribe(IObservable<Temperature> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("Additional temperature data will not be transmitted.");
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine("An Error happened");
            Error = true;
        }

        public virtual void OnNext(Temperature value)
        {
            if( Error != false)
                Error = false;
            Console.WriteLine("The temperature is {0}°C at {1:g}", value.Degrees, value.Date);
            Temp = value;
        }
    }
}