using System;
using System.Linq;
using System.Xml.Linq;
using System.Text.Json;


        string xml = "<People><Person><Name>Selim</Name><Age>32</Age><Department>IT</Department><Salary>5500</Salary><HireDate>2018-08-05</HireDate></Person></People>";

        Console.WriteLine(FilterPeopleFromXml(xml));


   static string FilterPeopleFromXml(string xmlData)
    {
        XDocument doc = XDocument.Parse(xmlData);


        var people = doc.Descendants("Person")
            .Select(p => new
            {
                Name = (string)p.Element("Name"),
                Age = (int)p.Element("Age"),
                Department = (string)p.Element("Department"),
                Salary = (decimal)p.Element("Salary"),
                HireDate = (DateTime)p.Element("HireDate")
            });


        var filtered = people.Where(p => p.Department == "IT" && p.Age>30 && p.Salary>5000 && p.HireDate <  new DateTime(2019, 1, 1)).ToList();


        var result = new
        {
            Names = filtered.Select(p => p.Name).OrderBy(n => n).ToList(),
            TotalSalary = filtered.Sum(p => p.Salary),
            AverageSalary = filtered.Any() ? filtered.Average(p => p.Salary) : 0,
            MaxSalary = filtered.Any() ? filtered.Max(p => p.Salary) : 0,
            Count = filtered.Count
        };

        return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = false });
    }

