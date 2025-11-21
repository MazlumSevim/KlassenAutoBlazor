// Diese Klasse repräsentiert ein Auto.
// - Enthält Eigenschaften wie Marke, Modell, Baujahr usw.
// - Wird von den Seiten verwendet, um Eingaben zu speichern.

using System;

namespace KlasseAuto.Blazor.Models;

public class Auto
{
    // Parameterloser Konstruktor für Blazor / Binding
    public Auto()
    {
    }

    // Standardwerte: leere Strings statt null
    public string autoMarke { get; set; } = "";
    public string fahrer { get; set; } = "";
    public string besitzer { get; set; } = "";

    public Auto(string autoMarke, string fahrer, string besitzer)
    {
        this.autoMarke = autoMarke;
        this.fahrer = fahrer;
        this.besitzer = besitzer;
    }

    public void autoInfo()
    {
        Console.WriteLine($"Auto Marke: {autoMarke}");
        Console.WriteLine($"Besitzer: {besitzer}");
    }
}
