using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._05_Dependency_Inversion
{
    public class Emailer : IWeatherAlertType
    {
        public string GenerateWeatherAlert(string weatherCondition)
        {
            return "It is " + weatherCondition;
        }
    }
}
