using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elon
{
    /// <summary>
    /// Attributes of car defines its capabilities.
    /// Method for displaying car status,
    /// and drive and recharge to resemble driving logic.
    /// </summary>
    internal class Car
    {
        #region Attributes
        private int _battery = 100;
        private int _drivenMeters = 0;
        public Color Color;
        #endregion

        #region Methods
        public string CarStatus()
        {
            return $"Battery: {_battery}% | Distance: {_drivenMeters/1000} km";
        }
        public void Drive()
        {
            _drivenMeters += 20;
            _battery -= 1;
        }

        public void Recharge()
        {
            _drivenMeters = 0;
            _battery = 100;
        }

        public int GetDrivenMeters()
        {
            return _drivenMeters;
        }

        public int GetBatteryCapacity()
        {
            return _battery;
        }
        #endregion
    }
}