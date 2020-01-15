using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class PlayerBossKill
    {
        public BossKillType BossKillType { get; private set; }

        public int Rank { get; private set; }

        public int Number { get; private set; }

        public PlayerBossKill(BossKillType bossKillType, int rank, int number)
        {
            this.BossKillType = bossKillType;
            this.Rank = rank;
            this.Number = number;
        }
    }
}
