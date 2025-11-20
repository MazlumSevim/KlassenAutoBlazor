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

        // Automarke, z.B. BMW, VW, Mercedes
    public string autoMarke { get; set; }
    public string fahrer { get; set; }
        // Name des Besitzers / der Besitzerin des Fahrzeugs
    public string besitzer { get; set; }

    public Auto(string autoMarke, string fahrer, string besitzer)
    {
        this.autoMarke = autoMarke;
        this.fahrer = fahrer;
        this.besitzer = besitzer;
    }

        // Methode mit Logik/Funktionalität für dieses Modell
    public void autoInfo()
    {
        Console.WriteLine($"Auto Marke: {autoMarke}");
        Console.WriteLine($"Besitzer: {besitzer}");
    }
}