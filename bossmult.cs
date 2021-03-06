﻿using Terraria;
using Terraria.ModLoader;

namespace BossScale
{
    public class bossmult : GlobalNPC
    {
        public static double max = 10.0;
        public static double bossmults = 1.0;
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (bossmults < 0.1)
            {
                bossmults = 0.1;
            }
        }
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

