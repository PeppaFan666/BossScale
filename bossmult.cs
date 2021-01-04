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
       
        public static double bossmults = 1.0;
        public override void SetDefaults(NPC npc)
        {
            double max = (double)npc.lifeMax;
   
            if (npc.boss == true)
            {
                max *= bossmults;
                npc.lifeMax = (int)max;
            }
        }

    }
    }

