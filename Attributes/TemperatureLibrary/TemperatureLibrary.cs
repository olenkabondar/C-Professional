namespace TemperatureLibrary
{
    [Obsolete("Use NewTemperatureConverter instead.")]
    public class TemperatureConverter
    {
        [Obsolete("Use ConvertCelsiusToFahrenheitNew instead.")]
        public static double ConvertCelsiusToFahrenheit(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }

        public static double ConvertFahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        [CustomNote("Це приклад властивості з атрибутом")]
        public static string Info => "Converter v1.0";
    }

    [AttributeUsage(AttributeTargets.All)]
    public class CustomNoteAttribute : Attribute
    {
        public string Message { get; }

        public CustomNoteAttribute(string message)
        {
            Message = message;
        }
    }
}
