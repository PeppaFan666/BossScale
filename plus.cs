using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using BossScale;
using Microsoft.Xna.Framework;

namespace BossScale
{
    class plus : ModItem
    {
      
        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.UseSound = SoundID.DD2_WitherBeastAuraPulse;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool UseItem(Player player)
        {
            bossmult.bossmults += 0.100;
            Main.NewText(bossmult.bossmults);
            return true;
        }
    }
}
