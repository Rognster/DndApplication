using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class DnD5eApiService
{
    private readonly HttpClient _httpClient;

    public DnD5eApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://www.dnd5eapi.co/api/");
    }

    public async Task<EquipmentResponse> GetEquipmentAsync(string equipmentId)
    {
        var response = await _httpClient.GetFromJsonAsync<EquipmentResponse>($"equipment/{equipmentId}");
        return response;
    }
}

public class EquipmentResponse
{
    public string Name { get; set; }
    public string EquipmentCategory { get; set; }
    public string Description { get; set; }
    // Add other fields as necessary
}
