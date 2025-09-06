using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

    static string FilterEmployees(IEnumerable<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)
    {
        // Filtreleme
        var filtered = employees
            .Where(e => e.Age >= 25 && e.Age <= 40)
            .Where(e => e.Department == "IT" || e.Department == "Finance")
            .Where(e => e.Salary >= 5000m && e.Salary <= 9000m)
            .Where(e => e.HireDate > new DateTime(2017, 1, 1))
            .ToList();

        // İsim sıralama (önce uzunluk desc, sonra alfabetik asc)
        var names = filtered
            .Select(e => e.Name)
            .OrderByDescending(n => n.Length)
            .ThenBy(n => n)
            .ToList();

        // Hesaplamalar
        decimal totalSalary = filtered.Sum(e => e.Salary);
        decimal averageSalary = filtered.Count > 0 ? Math.Round(filtered.Average(e => e.Salary), 2) : 0;
        decimal minSalary = filtered.Count > 0 ? filtered.Min(e => e.Salary) : 0;
        decimal maxSalary = filtered.Count > 0 ? filtered.Max(e => e.Salary) : 0;
        int count = filtered.Count;

        // JSON oluşturma
        var result = new
        {
            Names = names,
            TotalSalary = totalSalary,
            AverageSalary = averageSalary,
            MinSalary = minSalary,
            MaxSalary = maxSalary,
            Count = count
        };

        return JsonSerializer.Serialize(result);
    }

