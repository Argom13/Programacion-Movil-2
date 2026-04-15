using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using GestorRutinas.MVVM.Models;

namespace GestorRutinas.MVVM.ViewModels
{
    public class VolumenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(bool))
            {
                if (value is string s)
                    return !string.IsNullOrWhiteSpace(s);
                return value != null;
            }

            if (targetType == typeof(string))
            {
                if (value == null) return "0 kg";
                if (value is double d)
                    return $"{d:F0} kg";
                if (double.TryParse(value.ToString(), out var parsed))
                    return $"{parsed:F0} kg";
                return value.ToString();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class VolumenColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double vol = 0;
            if (value is double d) vol = d;
            else if (value != null && double.TryParse(value.ToString(), out var p)) vol = p;

            if (vol <= 0) return Colors.Gray;
            if (vol >= 100) return Color.FromArgb("#27AE60");
            return Color.FromArgb("#FF6B35");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DiasColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int dias = int.MaxValue;
            if (value is int i) dias = i;
            else if (value != null && int.TryParse(value.ToString(), out var p)) dias = p;

            if (dias == int.MaxValue) return Color.FromArgb("#999999");
            if (dias <= 3) return Color.FromArgb("#27AE60");
            if (dias <= 14) return Color.FromArgb("#FF6B35");
            return Color.FromArgb("#E74C3C");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class FechaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dt)
            {
                if (dt == DateTime.MinValue) return "N/A";
                return dt.ToString("dd/MM/yyyy");
            }
            return value?.ToString() ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DiasTextoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "N/A";
            if (value is int i)
            {
                if (i == int.MaxValue) return "N/A";
                return $"{i} días";
            }
            if (int.TryParse(value.ToString(), out var parsed))
            {
                if (parsed == int.MaxValue) return "N/A";
                return $"{parsed} días";
            }
            return "N/A";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
