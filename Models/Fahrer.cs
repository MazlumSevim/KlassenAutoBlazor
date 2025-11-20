// C#-Code-Datei.
// - Enthält Logik oder Datenmodelle für das Projekt.

using System;

namespace KlasseAuto.Blazor.Models;

public class Fahrer : Person
{
    public bool HatFuehrerschein { get; set; }

    public Fahrer(string vorname, string nachname, bool hatFuehrerschein)
    {
        Vorname = vorname;
        Nachname = nachname;
        HatFuehrerschein = hatFuehrerschein;
    }

        // Methode mit Logik/Funktionalität für dieses Modell
    public void FahrerInfo()
    {
         Console.WriteLine($"Fahrer: {Vorname} {Nachname} (Führerschein: {HatFuehrerschein})");
    }
}