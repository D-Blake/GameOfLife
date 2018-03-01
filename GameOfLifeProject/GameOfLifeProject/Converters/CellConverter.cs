using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace GameOfLifeProject.Converters
{
    class CellConverter : IValueConverter
    {
        //Converts from a boolean to a color depending on whether the cell is alive or not
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() != typeof(bool))
            {
                throw new Exception("Bad Conversion");
            }
            switch ((bool)value)
            {
                case true:
                    return Brushes.Yellow;
                case false:
                default:
                    return Brushes.Gray;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
