using System.ComponentModel;

namespace LosowaMoneta
{
    public class Config
    {
        [Description("Podstawy")]
        public bool CzyPluginJestWlaczony { get; set; } = true;
        public bool CzyDebugJestWlaczony { get; set; } = false;
        [Description("Tłumaczenie")]
        public string DobryEfekt { get; set; } = "<b><color=green>Wylosował Ci Się Dobry Efekt</color> Na Czas <color=blue>{duration}s";
        public string ZlyEfekt { get; set; } = "<b><color=red>Wylosował Ci Się Zły Efekt</color> Na Czas <color=blue>{duration}s";
        public string LosowyPrzedmiot { get; set; } = "<b><color=yellow>Dostałeś Losowy Przedmiot</color>";
        public string KolejnyCoin { get; set; } = "<b><color=yellow>Dostałeś Kolejnego Coina</color>";
        public string InnaRola { get; set; } = "<b><color=yellow>Zamieniłeś Się W Kogoś Innego</color>";
        public string Spectator { get; set; } = "<b><color=red>Zamieniłeś Się W Spectatora</color>";
        public string RozowyCukierek { get; set; } = "<b><color=red>Dostałeś Ciekawego Cukierka</color>";
        public string UtrataEkwipunku { get; set; } = "<b><color=red>UPSS Twój Ekwipunek Wyparował</color>";
        public string ZniszczonyCoin { get; set; } = "<b><color=red>Nie Masz Szczęścia :( Coin Się Zniszczył</color>";
        [Description("Inne")]
        public byte DlugoscWyswietlaniaHintuWSekundach { get; set; } = 10;
    }
}
