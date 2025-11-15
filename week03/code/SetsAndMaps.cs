using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> wordSet = new HashSet<string>(words);
        HashSet<string> pairs = new HashSet<string>();
        
        foreach (string word in words)
        {
            if (word.Length != 2) continue;
            if (word[0] == word[1]) continue;
            
            string reversed = word[1].ToString() + word[0].ToString();
            
            if (wordSet.Contains(reversed) && !pairs.Contains($"{reversed} & {word}"))
            {
                pairs.Add($"{word} & {reversed}");
            }
        }
        
        return pairs.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length >= 4)
            {
                string degree = fields[3].Trim();
                
                if (!string.IsNullOrEmpty(degree))
                {
                    if (degrees.ContainsKey(degree))
                        degrees[degree]++;
                    else
                        degrees[degree] = 1;
                }
            }
        }
        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        string clean1 = word1.Replace(" ", "").ToLower();
        string clean2 = word2.Replace(" ", "").ToLower();
        
        if (clean1.Length != clean2.Length) return false;
        
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        
        foreach (char c in clean1)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }
        
        foreach (char c in clean2)
        {
            if (!charCount.ContainsKey(c)) return false;
            charCount[c]--;
            if (charCount[c] == 0) charCount.Remove(c);
        }
        
        return charCount.Count == 0;
    }

    public static string[] EarthquakeDailySummary()
    {
        try
        {
            const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
            using var client = new HttpClient();
            var json = client.GetStringAsync(uri).Result;
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

            if (featureCollection?.Features == null) return new string[0];

            var results = new List<string>();
            foreach (var feature in featureCollection.Features)
            {
                if (feature?.Properties != null)
                {
                    string description = $"{feature.Properties.Place} - Mag {feature.Properties.Mag}";
                    results.Add(description);
                }
            }
            return results.ToArray();
        }
        catch (Exception ex)
        {
            return new string[] { $"Error: {ex.Message}" };
        }
    }
}