using CustomPlayerEffects;
using InventorySystem.Items;
using InventorySystem.Items.Usables.Scp244.Hypothermia;
using InventorySystem.Items.Usables.Scp330;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Handlers;
using LabApi.Features;
using LabApi.Loader.Features.Plugins;
using PlayerRoles;
using System;

namespace LosowaMoneta
{
    public class LosowaMoneta : Plugin<Config>
    {
        public override string Name => "LosowaMoneta";
        public override string Author => "PluginShop";
        public override Version Version => new Version(1, 0, 0);
        public override string Description => "Dzięki temu pluginowi gdy gracz użyje monetki to jest szansa na: losowy item, losowy efekt, zamienienie gracza w losową role, teleportacja w losowe miejsce";
        public override Version RequiredApiVersion => LabApiProperties.CurrentVersion;
        private System.Random rnd = new System.Random();

        public override void Enable()
        {
            if (this.Config.CzyPluginJestWlaczony)
            {
                ServerConsole.AddLog("LosowaMoneta włączona");
                PlayerEvents.FlippingCoin += OnUsingItem;
            }
        }

        public override void Disable()
        {
            ServerConsole.AddLog("LosowaMoneta wyłączona");
            PlayerEvents.FlippingCoin -= OnUsingItem;
        }

        private void OnUsingItem(PlayerFlippingCoinEventArgs ev)
        {
            if (this.Config.CzyDebugJestWlaczony)
            {
                ServerConsole.AddLog("Gracz Właśnie Użył Coina");
            }
            double roll = rnd.NextDouble();
            if (roll < 0.02)
            {
                int duration = rnd.Next(6, 21);
                ev.Player.EnableEffect<Invisible>(1, duration);
                ev.Player.SendHint($"{Config.DobryEfekt.Replace("{duration}", duration.ToString())}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.04)
            {
                int duration = rnd.Next(6, 21);
                ev.Player.EnableEffect<MovementBoost>(200, duration);
                ev.Player.SendHint($"{Config.DobryEfekt.Replace("{duration}", duration.ToString())}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.06)
            {
                int duration = rnd.Next(6, 21);
                ev.Player.EnableEffect<SilentWalk>(200, duration);
                ev.Player.SendHint($"{Config.DobryEfekt.Replace("{duration}", duration.ToString())}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.08)
            {
                int duration = rnd.Next(6, 21);
                ev.Player.EnableEffect<Invigorated>(200, duration);
                ev.Player.SendHint($"{Config.DobryEfekt.Replace("{duration}", duration.ToString())}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.10)
            {
                int duration = rnd.Next(6, 21);
                ev.Player.EnableEffect<NightVision>(50, duration);
                ev.Player.SendHint($"{Config.DobryEfekt.Replace("{duration}", duration.ToString())}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.12)
            {
                int duration = rnd.Next(6, 21);
                ev.Player.EnableEffect<AmnesiaVision>(50, duration);
                ev.Player.SendHint($"{Config.ZlyEfekt.Replace("{duration}", duration.ToString())}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.14)
            {
                int duration = rnd.Next(6, 21);
                ev.Player.EnableEffect<Bleeding>(1, duration);
                ev.Player.SendHint($"{Config.ZlyEfekt.Replace("{duration}", duration.ToString())}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.16)
            {
                int duration = rnd.Next(6, 11);
                ev.Player.EnableEffect<Decontaminating>(1, duration);
                ev.Player.SendHint($"{Config.ZlyEfekt.Replace("{duration}", duration.ToString())}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.18)
            {
                int duration = rnd.Next(11, 21);
                ev.Player.EnableEffect<Stained>(200, duration);
                ev.Player.SendHint($"{Config.ZlyEfekt.Replace("{duration}", duration.ToString())}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.20)
            {
                int duration = rnd.Next(6, 21);
                ev.Player.EnableEffect<Hypothermia>(255, duration);
                ev.Player.SendHint($"{Config.ZlyEfekt.Replace("{duration}", duration.ToString())}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.22)
            {
                int duration = rnd.Next(6, 16);
                ev.Player.EnableEffect<Flashed>(255, duration);
                ev.Player.SendHint($"{Config.ZlyEfekt.Replace("{duration}", duration.ToString())}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.24)
            {
                ev.Player.AddItem(ItemType.KeycardScientist);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.26)
            {
                ev.Player.AddItem(ItemType.SurfaceAccessPass);
                ev.Player.RemoveItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.28)
            {
                ev.Player.AddItem(ItemType.KeycardResearchCoordinator);
                ev.Player.RemoveItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.30)
            {
                ev.Player.AddItem(ItemType.KeycardContainmentEngineer);
                ev.Player.RemoveItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.32)
            {
                ev.Player.AddItem(ItemType.KeycardMTFPrivate);
                ev.Player.RemoveItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.34)
            {
                ev.Player.AddItem(ItemType.KeycardZoneManager);
                ev.Player.RemoveItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.36)
            {
                ev.Player.AddItem(ItemType.Radio);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.38)
            {
                ev.Player.AddItem(ItemType.GunCOM15);
                ev.Player.RemoveItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.40)
            {
                ev.Player.AddItem(ItemType.Medkit);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.42)
            {
                ev.Player.AddItem(ItemType.Medkit);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.44)
            {
                ev.Player.AddItem(ItemType.Flashlight);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.46)
            {
                ev.Player.AddItem(ItemType.SCP500);
                ev.Player.RemoveItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.48)
            {
                ev.Player.AddItem(ItemType.SCP207);
                ev.Player.RemoveItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.50)
            {
                ev.Player.AddItem(ItemType.GunCrossvec);
                ev.Player.RemoveItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.52)
            {
                ev.Player.AddItem(ItemType.GrenadeHE);
                ev.Player.RemoveItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.54)
            {
                ev.Player.AddItem(ItemType.GrenadeFlash);
                ev.Player.RemoveItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.56)
            {
                ev.Player.AddItem(ItemType.SCP268);
                ev.Player.RemoveItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.58)
            {
                ev.Player.AddItem(ItemType.Adrenaline);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.60)
            {
                ev.Player.AddItem(ItemType.Painkillers);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.62)
            {
                ev.Player.AddItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.KolejnyCoin}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.64)
            {
                ev.Player.AddItem(ItemType.ArmorCombat);
                ev.Player.RemoveItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.66)
            {
                ev.Player.AddItem(ItemType.Jailbird);
                ev.Player.RemoveItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.68)
            {
                ev.Player.AddItem(ItemType.Lantern);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.70)
            {
                ev.Player.AddItem(ItemType.GunA7);
                ev.Player.RemoveItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.LosowyPrzedmiot}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.72)
            {
                ev.Player.SetRole(RoleTypeId.ChaosMarauder);
                ev.Player.SendHint($"{this.Config.InnaRola}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.74)
            {
                ev.Player.SetRole(RoleTypeId.ClassD);
                ev.Player.SendHint($"{this.Config.InnaRola}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.78)
            {
                ev.Player.SetRole(RoleTypeId.FacilityGuard);
                ev.Player.SendHint($"{this.Config.InnaRola}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.80)
            {
                ev.Player.SetRole(RoleTypeId.Scientist);
                ev.Player.SendHint($"{this.Config.InnaRola}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.82)
            {
                ev.Player.SetRole(RoleTypeId.NtfPrivate);
                ev.Player.SendHint($"{this.Config.InnaRola}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.84)
            {
                ev.Player.SetRole(RoleTypeId.Scp0492);
                ev.Player.SendHint($"{this.Config.InnaRola}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.86)
            {
                ev.Player.SetRole(RoleTypeId.Spectator);
                ev.Player.SendHint($"{this.Config.Spectator}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.88)
            {
                ev.Player.GiveCandy(CandyKindID.Pink, ItemAddReason.AdminCommand);
                ev.Player.RemoveItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.RozowyCukierek}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else if (roll < 0.93)
            {
                ev.Player.ClearInventory();
                ev.Player.RemoveItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.UtrataEkwipunku}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
            else
            {
                ev.Player.RemoveItem(ItemType.Coin);
                ev.Player.SendHint($"{this.Config.ZniszczonyCoin}", this.Config.DlugoscWyswietlaniaHintuWSekundach);
            }
        }
    }
}