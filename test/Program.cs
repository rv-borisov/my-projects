using System.Net;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System;
using System.Linq;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest httpWebRequest;
            HttpWebResponse httpWebResponse;
            string city, lat, lon, response;
            do
            {
                Console.WriteLine("Введите 1 для ввода названия города: ");
                Console.WriteLine("Введите 2 для ввода координат: ");
                Console.WriteLine("Введите 3 для выхода: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Введите название города:");
                        city = Console.ReadLine();
                        httpWebRequest = (HttpWebRequest)WebRequest
                            .Create($"http://api.openweathermap.org/data/2.5/forecast?q={city}&units=metric&appid=00ba27a8190801d0b52cd6a74c04c179");
                        httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                        {
                            response = streamReader.ReadToEnd();
                        }
                        Start(response);
                        break;
                    case "2":
                        Console.WriteLine("Введите координаты:");
                        Console.WriteLine("Широта:");
                        lat = Console.ReadLine();
                        Console.WriteLine("Долгота:");
                        lon = Console.ReadLine();
                        httpWebRequest = (HttpWebRequest)WebRequest
                            .Create($"http://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&units=metric&appid=00ba27a8190801d0b52cd6a74c04c179");
                        httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                        {
                            response = streamReader.ReadToEnd();
                        }
                        Start(response);
                        break;
                }
            } while (Console.ReadLine() != "3");
        }
        static void Start(string response)
        {
            WeatherResponse weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(response);
            List<Day> days = new List<Day>();
            foreach (var w in weatherResponse.PeriodList)
            {
                DateTime dateTime = DateTime.Parse(w.Dt_txt);
                if (dateTime.Hour + 3 <= 12 && dateTime.Hour + 3 >= 6)
                {
                    Temp dayTemp = new Temp();
                    dayTemp.Time = dateTime;
                    dayTemp.Time = dayTemp.Time.AddHours(3);
                    dayTemp.Temperature = w.Main.Temp;

                    if (days.Any() && days[^1].Date == dateTime.Date)
                    {
                        days[^1].tempList.Add(dayTemp);
                    }
                    else
                    {
                        Day day = new Day();
                        day.Date = dateTime.Date;
                        day.tempList.Add(dayTemp);
                        days.Add(day);
                    }
                }
            }
            Console.WriteLine(weatherResponse.City.Name);
            foreach (var d in days)
            {
                d.AvgTemp = Math.Round(d.tempList.Average(t => t.Temperature), 1);
                Temp temp = new Temp();
                temp.Temperature = d.tempList.Max(t => t.Temperature);
                temp.Time = d.tempList.Where(t => t.Temperature == temp.Temperature).First().Time;
                temp.Temperature = Math.Round(d.tempList.Max(t => t.Temperature), 1);
                d.MaxTemp = temp;
                Console.Write($"День - {d.Date.Day}.{d.Date.Month}.{d.Date.Year}");
                Console.WriteLine($"  AVG (6-12h) : {d.AvgTemp} C; MAX (6-12h) : {d.MaxTemp.Temperature} C at {d.MaxTemp.Time} UTC");
                Console.WriteLine();
            }
        }
    }
    class Day
    {
        public DateTime Date { get; set; }
        public double AvgTemp { get; set; }
        public Temp MaxTemp { get; set; }
        public List<Temp> tempList = new List<Temp>(); 
    }
    class Temp
    {
        public DateTime Time { get; set; }
        public double Temperature { get; set; }
    }
    class WeatherResponse
    {
        [JsonPropertyName("list")]
        public List<PeriodList> PeriodList { get; set; }
        [JsonPropertyName("city")]
        public City City { get; set; }
    }
    class City
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("coord")]
        public Coord Coord { get; set; }
    }
    class Coord
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
        [JsonPropertyName("lon")]
        public double Lon { get; set; }
    }
    class PeriodList
    {
        [JsonPropertyName("main")]
        public Main Main { get; set; }
        [JsonPropertyName("dt_txt")]
        public string Dt_txt { get; set; }
    }
    class Main
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
    }
}
