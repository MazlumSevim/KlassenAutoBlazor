using System;

namespace KlasseAuto.Blazor.Models;

public class Kunde : Person
{
   
    

    public Kunde(string vorname, string nachname)
    {
        Vorname = vorname;
        Nachname = nachname;
        
    }

    public void KundeInfo()
    {
        Console.WriteLine($"Kundedaten: {Vorname} {Nachname}");
    }
}