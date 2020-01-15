using Core.Attributes;

namespace Core.Enums
{
    public enum ActivityName
    {
        [DisplayValue("League Points")]
        League,

        [DisplayValue("Bounty Hunter Target Kills")]
        BountyHunterTargetKills,

        [DisplayValue("Bounty Hunter Rogue Kills")]
        BountyHunterRogueKills,

        [DisplayValue("Clue Scrolls: Overall")]
        ClueOverall,

        [DisplayValue("Clue Scrolls: Easy")]
        ClueEasy,

        [DisplayValue("Clue Scrolls: Medium")]
        ClueMedium,
        
        [DisplayValue("Clue Scrolls: Hard")]
        ClueHard,

        [DisplayValue("Clue Scrolls: Elite")]
        ClueElite,
        
        [DisplayValue("Clue Scrolls: Master")]
        ClueMaster,
        
        [DisplayValue("Last Man Standing")]
        LastManStanding
    }
}
