using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

static string LongestVowelSubsequenceAsJson(List<string> words)
{
    List<object> output = new List<object>();
    List<char> letters = new List<char>() { 'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü' };

    foreach (var word in words)
    {
        string longestsequence = "";
        string buildedsequence = "";
        
        foreach (var c in word)
        {
            if (letters.Contains(c))
            {
                buildedsequence += c;
            }
            else
            {
                if (buildedsequence.Length > longestsequence.Length)
                {
                    longestsequence = buildedsequence;
                }
                buildedsequence = "";
            }
        }

        if (buildedsequence.Length > longestsequence.Length) // looptan çıkınca son kontrol, son harf sesli olabilir
            longestsequence = buildedsequence;

        output.Add(new
        {
            word = word,
            sequence = longestsequence,
            length = longestsequence.Length
        });
    }
    return JsonSerializer.Serialize(output, new JsonSerializerOptions { WriteIndented = false });
}