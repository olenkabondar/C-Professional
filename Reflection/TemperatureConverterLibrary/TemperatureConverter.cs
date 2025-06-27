namespace TemperatureConverterLibrary
{
    public static class TemperatureConverter
    {
        // З Цельсія в Фаренгейт
        public static double CelsiusToFahrenheit(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }

        // З Фаренгейту в Цельсій
        public static double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        // З Цельсія в Кельвін
        public static double CelsiusToKelvin(double celsius)
        {
            return celsius + 273.15;
        }

        // З Кельвіна у Цельсій
        public static double KelvinToCelsius(double kelvin)
        {
            return kelvin - 273.15;
        }
    }
}
