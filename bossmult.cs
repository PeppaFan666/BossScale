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
       
        public static float bossmults = 1f;
        public override void SetDefaults(NPC npc)
        {
            float max = (float)npc.lifeMax;
   
            if (npc.boss == true)
            {
                max *= bossmults;
                npc.lifeMax = (int)max;
            }
        }

    }
    }

