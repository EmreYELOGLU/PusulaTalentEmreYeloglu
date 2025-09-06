using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

static string MaxIncreasingSubarrayAsJson(List<int> numbers)
{
    List<int> subarray = new List<int>();
    List<int> subarraytry = new List<int>();
    int max = 0;
    int sum = 0;
    for (int i=0; i<=numbers.Count-1;i++)
    {
        subarraytry.Clear();
        sum = 0 + numbers[i];
        subarraytry.Add(numbers[i]);
        for (int j = i+1; j <= numbers.Count-1; j++)
        {
            if (numbers[j-1] >= numbers[j])
            {
                break;
            }
            else
            {
                subarraytry.Add(numbers[j]);
                sum += numbers[j];
            }

        }
        if (sum>max)
        {
            max = sum;
            subarray.Clear();
            foreach(int number in subarraytry)
            {
                subarray.Add(number);
            }
        }
    }
    String jsonString = JsonSerializer.Serialize(subarray);
    return jsonString;
}
