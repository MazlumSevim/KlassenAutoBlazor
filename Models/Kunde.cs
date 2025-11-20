// C#-Code-Datei.
// - Enthält Logik oder Datenmodelle für das Projekt.

using System;

namespace KlasseAuto.Blazor.Models;

public class Kunde : Person
{
   
    

    public Kunde(string vorname, string nachname)
    {
        Vorname = vorname;
        Nachname = nachname;
        
    }

        // Methode mit Logik/Funktionalität für dieses Modell
    public void KundeInfo()
    {
        Console.WriteLine($"Kundedaten: {Vorname} {Nachname}");
    }
}