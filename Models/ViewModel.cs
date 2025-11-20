// C#-Code-Datei.
// - Enthält Logik oder Datenmodelle für das Projekt.

using System;
namespace KlasseAuto.Blazor.Models;

public class ViewModel
{
        // Automarke, z.B. BMW, VW, Mercedes
    public string Marke { get; set; } = "";
    public string Fahrer { get; set; } = "";
    public string Kunde { get; set; } = "";
        // Name des Besitzers / der Besitzerin des Fahrzeugs
    public string Besitzer { get; set; } = "";
    public string FuehrerscheinInfo { get; set; } = "";
    
}