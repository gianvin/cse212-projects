using System.ComponentModel;
using System.Net.Http.Json;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;

public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    private const string BaseUrl = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

    public async Task<string> EarthquakeDailySummary()
    {
        using HttpClient httpClient = new HttpClient();

        try
        {
            // Fetch the JSON DATA from USGS API
            var response = await httpClient.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();

            //Deserialize the JSON response

            var earthquakeData = await response.Content.ReadFromJsonAsync<earthquakeData>();

            // Earthquake locations and magnitude
            List<string> formattedStrings = new List<string>();
            foreach (var feature in earthquakeData.Features)
            {
                // Format the output string using 'place' and  'mag'
                string formattedString = $"{feature.Properties.Place} - Mag {feature.Properties.Mag}";
                formattedStrings.Add(formattedString);
            }

            // join all the formatted string into a single output
            return $"[{string.Join(", ", formattedStrings)}]";
        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine($"Error fetching eartquake data: {httpEx.Message}");
            return "[]";
        }
        catch (TaskCanceledException timeoutEx)
        {
            Console.WriteLine($"Error fetching earthquake data: The request timed out");
            return "[]";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error occured: {ex.Message}");
            return "[]";
        }
    }
}
public class earthquakeData
{
    public List<Feature> Features { get; set; }
}


public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public string Place { get; set; } // 'place' attribute for location
    public double Mag { get; set; } // 'mag' attribute for magnitude
}
class Program
{
    static async Task Main(string[] args)
    {
        FeatureCollection featureCollection = new FeatureCollection();
        string earthquakeSummary = await featureCollection.EarthquakeDailySummary();
        Console.WriteLine(earthquakeSummary);
    }
}