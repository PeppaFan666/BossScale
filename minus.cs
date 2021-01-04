using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using BossScale;
namespace BossScale
{
    class minus : ModItem
    {
        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.SwingThrow;
        }
        public override void UpdateInventory(Player player)
        {
            if (bossmult.bossmults < 0.1f)
            {
                bossmult.bossmults = 0.1f;
            }
        }
        public override bool UseItem(Player player)
        {
            bossmult.bossmults -= 0.1f;
            Main.NewText(bossmult.bossmults + " times");
            return true;

        }
    }
}
