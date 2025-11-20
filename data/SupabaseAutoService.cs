// C#-Code-Datei.
// - Service, um Autos über Supabase zu speichern und zu laden.

using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using KlasseAuto.Blazor.Models;

namespace KlasseAuto.Blazor.Data;

public class SupabaseAutoService
{
    private readonly HttpClient _httpClient;

    // TODO: Hier deine echten Supabase-Werte eintragen
    private const string SupabaseUrl = "https://zuiycppuqtvxidgwapzg.supabase.co";
    private const string SupabaseAnonKey = "sb_publishable_mDdlLhAZ9L_wr7a6wzErCg_d7hKfJRh";

    public SupabaseAutoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Alle Autos aus der Supabase-Tabelle laden
    public async Task<List<Auto>> GetAutosAsync()
    {
        var request = new HttpRequestMessage(
            HttpMethod.Get,
            $"{SupabaseUrl}/rest/v1/autos?select=*"
        );

        request.Headers.Add("apikey", SupabaseAnonKey);
        request.Headers.Add("Authorization", $"Bearer {SupabaseAnonKey}");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var autos = await response.Content.ReadFromJsonAsync<List<Auto>>();
        return autos ?? new List<Auto>();
    }

    // Ein Auto in Supabase speichern
    public async Task<Auto?> AddAutoAsync(Auto auto)
    {
        // JSON-Objekt bauen, Felder müssen zu deiner Supabase-Tabelle passen
        var json = JsonSerializer.Serialize(new
        {
            autoMarke = auto.autoMarke,
            fahrer = auto.fahrer,
            besitzer = auto.besitzer
        });

        var request = new HttpRequestMessage(
            HttpMethod.Post,
            $"{SupabaseUrl}/rest/v1/autos"
        );

        request.Headers.Add("apikey", SupabaseAnonKey);
        request.Headers.Add("Authorization", $"Bearer {SupabaseAnonKey}");
        request.Headers.Add("Prefer", "return=representation"); // gespeichertes Objekt zurückgeben

        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var autos = await response.Content.ReadFromJsonAsync<List<Auto>>();
        return autos != null && autos.Count > 0 ? autos[0] : null;
    }
}
