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
    class plus : ModItem
    {
        
        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.SwingThrow;
        }
        public override bool UseItem(Player player)
        {
            Main.NewText(bossmult.bossmults + " times");
            bossmult.bossmults += 1;
            return true;
            
        }
    }
}
