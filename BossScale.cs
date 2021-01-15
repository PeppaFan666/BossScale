using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using BossScale.UI;

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
         //   _ScaleBarUserInterface.SetState(scaleBar);
           // _OpenUserInterface.SetState(open);
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
            if(_OpenUserInterface.CurrentState != open)
            {
                _OpenUserInterface.SetState(open);
            }
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
                    delegate
                    {
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