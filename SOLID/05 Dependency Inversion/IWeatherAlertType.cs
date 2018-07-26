using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._05_Dependency_Inversion
{
    interface IWeatherAlertType
    {
        string GenerateWeatherAlert(string weatherCondition);
    }
}
