using System;
using System.Globalization;
using System.Windows.Data;
using PetGallery.MVVM.ViewModels;

namespace PetGallery.Core
{
    public class ViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case HomeViewModel _ when (string) parameter == "Home":
                case ExploreViewModel _ when (string) parameter == "Explore":
                    return true;
                default:
                    return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}