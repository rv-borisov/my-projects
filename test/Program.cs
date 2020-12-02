using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace test
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите адрес: ");
            string address = Console.ReadLine();
            Console.WriteLine("Введите частоту точек: ");
            int step = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите имя и тип файла для сохранения: ");
            string filename = Console.ReadLine();
            Start(address, step, filename);
        }

        static void Start(string address, int step, string filename)
        {
            address = address.Replace(" ", "%20");
            string url = $"https://nominatim.openstreetmap.org/search?q={address}&format=json&polygon_svg=1";
           
            string response = Request.GetResponse(Request.CreateRequest(url));
            
            /// В данном приложении использован сервис Nominatim, предоставляющий API для получения информации с сервиса OpenStreetMap
            /// Для использовния других сервисов необходимо реализовать класс, соответствующий интерфейсу IResponse
            var deserialized = JsonSerializer.Deserialize<List<NominatimResponse>>(response)[0];

            Coordinates coordinates = new Coordinates(deserialized);

            ///Файл создается в папке с программой (netcoreapp3.1)
            FileProcessing.CreateRecord(filename, coordinates, step);
        }
        
    }
}
