using System;

namespace SOLID._05_Dependency_Inversion
{
    public class WeatherTracker
    {
        WeathersEnum currentConditions;
        private readonly IWeatherAlertType _phone;
        private readonly IWeatherAlertType _emailer;

        public enum WeathersEnum
        {
            Rainy,
            Sunny
        }

        public WeatherTracker(Phone phone, Emailer emailer)
        {
            _phone = phone;
            _emailer = emailer;
        }

        public void TriggerWeatherAlert(WeathersEnum weatherDescription)
        {
            SetCurrentConditions(weatherDescription);
            PrintWeatherAlert();
        }

        public void SetCurrentConditions(WeathersEnum weatherDescription)
        {
            this.currentConditions = weatherDescription;
        }

        public void PrintWeatherAlert()
        {
            string alert = string.Empty;

            switch (currentConditions)
            {
                case WeathersEnum.Rainy:
                    alert = _phone.GenerateWeatherAlert(currentConditions.ToString());
                    break;
                case WeathersEnum.Sunny:
                    alert = _emailer.GenerateWeatherAlert(currentConditions.ToString());
                    break;
                default:
                    break;
            }
            Console.WriteLine(alert);
        }
    }
}
