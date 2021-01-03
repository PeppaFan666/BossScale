using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace BossScale
{
     public class bossmult: GlobalNPC
    {
        public static int bossmults = 1;
        public override void SetDefaults(NPC npc)
        {
            if (npc.boss == true)
            {
                npc.lifeMax *= bossmults;
            }
        }

    }
    }

