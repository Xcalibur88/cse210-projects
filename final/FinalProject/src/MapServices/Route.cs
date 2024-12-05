using System.Text;
using System.Text.Json;

class Route(double startLatitude, double startLongitude, double endLatitude, double endLongitude) {
    private readonly double startLatitude = startLatitude;
    private readonly double startLongitude = startLongitude;
    private readonly double endLatitude = endLatitude;
    private readonly double endLongitude = endLongitude;
    
    public async Task SendRequestAsync() {
        string baseUrl = "http://localhost:8082/ors/v2/directions/foot-walking";
        StringContent content = new($"{{\"coordinates\": [[{startLongitude},{startLatitude}],[{endLongitude},{endLatitude}]]}}", Encoding.UTF8, "application/json");

        using HttpClient client = new();
        HttpResponseMessage response = await client.PostAsync(baseUrl, content);

        if (response.IsSuccessStatusCode) {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Route JSON:");
            Console.WriteLine(jsonResponse);

            /*var jsonDoc = JsonDocument.Parse(jsonResponse);
            var coordinates = jsonDoc.RootElement
                .GetProperty("routes")[0]
                .GetProperty("geometry")
                .GetProperty("coordinates");
            var routePoints = new List<PointLatLng>();
            foreach (var coordinate in coordinates.EnumerateArray()) {
                double lon = coordinate[0].GetDouble();
                double lat = coordinate[1].GetDouble();
                routePoints.Add(new PointLatLng(lat, lon));
            }*/
        } else {
            Console.WriteLine($"Error: {response.StatusCode}");
        }
    }
}