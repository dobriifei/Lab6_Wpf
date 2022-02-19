using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab6_Wpf
{
    enum Precipitation
    {
        sunny,
        cloudly,
        rain,
        snow
    }
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TempProperty;
        private string wind_dir;
        private int wind_speed;
        private Precipitation precipitation;
        public string Wind_dir{ get; set; }
        public int Wind_speed{ get; set; }

        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }
        public WeatherControl(string wind_dir, int wind_speed, Precipitation precipitation)
        {
            this.Wind_dir = wind_dir;
            this.Wind_speed = wind_speed;
            this.precipitation = precipitation;

        }
        static WeatherControl() => TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                 typeof(WeatherControl),
                 new FrameworkPropertyMetadata(
                     0,
                     FrameworkPropertyMetadataOptions.AffectsMeasure |
                     FrameworkPropertyMetadataOptions.AffectsRender,
                     null,
                     new CoerceValueCallback(CoerceTemp)),
                     new ValidateValueCallback(ValidateTemp));

        private static bool ValidateTemp(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= 50 && v <= -50)
            {
                return v;
            }
            else
            {
                return 0;
            }
        }
    }
}

