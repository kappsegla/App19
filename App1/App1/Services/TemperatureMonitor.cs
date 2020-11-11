using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App1.Models;

namespace App1.Services
{
    public class TemperatureMonitor : IObservable<Temperature>
    {
        List<IObserver<Temperature>> observers;

        public TemperatureMonitor()
        {
            observers = new List<IObserver<Temperature>>();
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Temperature>> _observers;
            private IObserver<Temperature> _observer;

            public Unsubscriber(List<IObserver<Temperature>> observers, IObserver<Temperature> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }

        public IDisposable Subscribe(IObserver<Temperature> observer)
        {
            if( observers.Count == 0)
                StartMeasurement();
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }
        
        private void StartMeasurement()
        {
            // Create an array of sample data to mimic a temperature device.
            // Some values are anomalies and will call onError to notify about failed readings.
            // At the end of the series a null value comes that will call onCompleted
            // and remove all subscribers.
            decimal?[] temps =
            {
                14.6m, 14.65m, 14.7m, 14.9m, 14.9m, 15.2m, 15.25m, 15.2m,
                15.4m, 15.45m, 100.0m, 14.65m, 14.7m, 14.9m, 14.9m, 15.2m, 15.25m, 15.2m,
                15.4m, 15.45m, 100.0m, 14.65m, 14.7m, 14.9m, 14.9m, 15.2m, 15.25m, 15.2m,
                15.4m, 15.45m, 100.0m, 14.65m, 14.7m, 14.9m, 14.9m, 15.2m, 15.25m, 15.2m,
                15.4m, 15.45m, 100.0m, 14.65m, 14.7m, 14.9m, 14.9m, 15.2m, 15.25m, 15.2m,
                15.4m, 15.45m, null
            };
            Task.Run(async () =>
            {
                foreach (var temp in temps)
                {
                    await Task.Delay(5000);
                    if (temp.HasValue && temp.Value == 100.0m)
                    {
                        foreach (var observer in observers)
                            observer.OnError(new Exception("Couldn't read temperature value"));
                    }
                    else if (temp.HasValue)
                    {
                        Temperature tempData = new Temperature(temp.Value, DateTime.Now);
                        foreach (var observer in observers)
                            observer.OnNext(tempData);
                    }
                    else
                    {
                        foreach (var observer in observers.ToArray())
                        {
                            observer?.OnCompleted();
                        }

                        observers.Clear();
                        break;
                    }
                }
            });
        }
    }
}