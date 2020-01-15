using Core.Enums;

namespace Core.Models
{
    public class BossKill
    {
        public BossName BossName { get; private set; }

        public int Rank { get; private set; }

        public int Number { get; private set; }

        public BossKill(BossName bossKillType, int rank, int number)
        {
            this.BossName = bossKillType;
            this.Rank = rank;
            this.Number = number;
        }
    }
}
