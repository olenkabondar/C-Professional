using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace _2Task
{
    /*Напишіть програму, яка дозволила б за вказаною адресою web-сторінки вибирати всі посилання на інші сторінки, номери телефонів,
     * поштові адреси та зберігала отриманий результат у файл.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            //string url = Console.ReadLine();
            string url = $"https://meteofor.com.ua/weather-kyiv-4944/month/";

            try
            {
                string html = DownloadHtml(url);

                var links = ExtractLinks(html);
                var phones = ExtractPhones(html);
                var emails = ExtractEmails(html);

                string result = FormatResults(links, phones, emails);

                string filePath = "2Task.txt";
                File.WriteAllText(filePath, result);

                Console.WriteLine($"Результати збережено у файл {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }

        static string DownloadHtml(string url)
        {
            using WebClient client = new WebClient();
            return client.DownloadString(url);
        }

        // всі посилання на інші сторінки
        static string[] ExtractLinks(string html)
        {
            var matches = Regex.Matches(html, @"href\s*=\s*[""'](https?://[^""'#>\s]+)[""']", RegexOptions.IgnoreCase);
            var links = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                links[i] = matches[i].Groups[1].Value;
            }
            return links;
        }

        //посилання на номери телефонів
        static string[] ExtractPhones(string html)
        {
            // для українських номерів мобільних операторів
            var phonePattern = @"(\+?38)?0\d{2}[-\s]?\d{3}[-\s]?\d{2}[-\s]?\d{2}";

            var matches = Regex.Matches(html, phonePattern);
            var phones = new System.Collections.Generic.List<string>();

            foreach (Match match in matches)
            {
                string val = match.Value.Trim();
                phones.Add(val);
            }

            return phones.ToArray();
        }

        //посилання на поштові адреси
        static string[] ExtractEmails(string html)
        {
            var emailPattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";
            var matches = Regex.Matches(html, emailPattern);
            var emails = new System.Collections.Generic.List<string>();
            foreach (Match match in matches)
            {
                emails.Add(match.Value);
            }
            return emails.ToArray();
        }

        static string FormatResults(string[] links, string[] phones, string[] emails)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Посилання:");
            foreach (var link in links)
            {
                sb.AppendLine(link);
            }

            sb.AppendLine("\nНомери телефонів:");
            foreach (var phone in phones)
            {
                sb.AppendLine(phone);
            }

            sb.AppendLine("\nПоштові адреси:");
            foreach (var email in emails)
            {
                sb.AppendLine(email);
            }
            return sb.ToString();
        }
    }
}
