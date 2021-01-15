using Terraria.ModLoader;
using BossScale.UI;
using Microsoft.Xna.Framework;
using Terraria.UI;
using System.Collections.Generic;
using Terraria;

namespace BossScale
{
	public class BossScale : Mod
	{
        private UserInterface _OpenUserInterface;
		private UserInterface _ScaleBarUserInterface;
        internal ScaleBar scaleBar;
        internal Open open;
        public override void Load()
        {
            open = new Open();
             scaleBar = new ScaleBar();
            _ScaleBarUserInterface = new UserInterface();
            _OpenUserInterface = new UserInterface();
            _ScaleBarUserInterface.SetState(scaleBar);
            _OpenUserInterface.SetState(open);
        }
        internal void ShowMyUI()
        {
            if (_ScaleBarUserInterface.CurrentState == null)
            {
                _ScaleBarUserInterface?.SetState(scaleBar);
            }
           else if (_ScaleBarUserInterface.CurrentState != null)
            {
                _ScaleBarUserInterface?.SetState(null);
            }
        }


        public override void Unload()
        {
            _OpenUserInterface = null; 
            _ScaleBarUserInterface = null;
            bossmult.bossmults = 1;
            bossmult.max = 1;
        }
        public override void UpdateUI(GameTime gameTime)
        {
            _OpenUserInterface?.Update(gameTime);
            _ScaleBarUserInterface?.Update(gameTime);
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "BossScale: Open",
                    delegate {
                            _OpenUserInterface.Draw(Main.spriteBatch, new GameTime());
                        
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
            if (resourceBarIndex != -1)
            {
                layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
                    "BossScale: Scale Bar",
                    delegate
                    {
                        _ScaleBarUserInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
    }
}