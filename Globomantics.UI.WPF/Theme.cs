using System;
using System.Windows;
using System.Windows.Media;

namespace Globomantics.UI.WPF
{
    public sealed class Theme
    {
        [ThreadStatic]
        private static ResourceDictionary? resourceDictionary;

        internal static ResourceDictionary ResourceDictionary
        {
            get
            {
                if (resourceDictionary != null)
                {
                    return resourceDictionary;
                }

                resourceDictionary = new ResourceDictionary();
                LoadThemeType(ThemeType.Light);
                return resourceDictionary;
            }
        }

        public static ThemeType ThemeType { get; set; } = ThemeType.Light;

        public static void LoadThemeType(ThemeType type)
        {
            ThemeType = type;
            switch (type)
            {
                case ThemeType.Light:
                    {
                        SetResource(ThemeResourceKey.ContentBackground.ToString(), new SolidColorBrush(ColorFromHex("#FF_FF_FF_FF")));
                        SetResource(ThemeResourceKey.ContentForeground.ToString(), new SolidColorBrush(ColorFromHex("#FF_00_00_00")));
                        break;
                    }
                case ThemeType.Dark:
                    {
                        SetResource(ThemeResourceKey.ContentBackground.ToString(), new SolidColorBrush(ColorFromHex("#FF_00_00_00")));
                        SetResource(ThemeResourceKey.ContentForeground.ToString(), new SolidColorBrush(ColorFromHex("#FF_FF_FF_FF")));
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static object GetResource(ThemeResourceKey resourceKey)
        {
#pragma warning disable CS8603
            return ResourceDictionary.Contains(resourceKey.ToString()) ? ResourceDictionary[resourceKey.ToString()] : null;
#pragma warning restore CS8603
        }

        internal static void SetResource(object key, object resource)
        {
            ResourceDictionary[key] = resource;
        }

        internal static Color ColorFromHex(string colorHex)
        {
            return (Color)ColorConverter.ConvertFromString(colorHex);
        }
    }
}
