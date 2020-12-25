using System;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace TEST2
{
    class Program
    {
        static void Main(string[] args)
        {
            string charcode = "HKD"; //CharCode Гонконгских долларов
            decimal d = 0;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest
                .Create("http://www.cbr.ru/scripts/XML_daily.asp");
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ValCurs));
            ValCurs valCurs;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                valCurs = (ValCurs)xmlSerializer.Deserialize(streamReader);
            }
            foreach (var v in valCurs.Valute)
            {
                if (v.CharCode == charcode)
                {
                    d = Convert.ToDecimal(v.Value) / Convert.ToInt32(v.Nominal);
                    break;
                } 
            }
            Console.WriteLine($"Курс гонконгского доллара к российскому рублю: {d}");
        }
    }
    [XmlRoot(ElementName = "ValCurs")]
    public class ValCurs
    {
        [XmlElement(ElementName = "Valute")]
        public List<Valute> Valute { get; set; }
        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }
    }
    public class Valute
    {
        [XmlElement(ElementName = "CharCode")]
        public string CharCode { get; set; }
        [XmlElement(ElementName = "Nominal")]
        public string Nominal { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Value")]
        public string Value { get; set; }
    }
}