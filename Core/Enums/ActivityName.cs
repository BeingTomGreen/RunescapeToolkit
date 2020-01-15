using Core.Attributes;

namespace Core.Enums
{
    public enum ActivityName
    {
        [ActivityTypeMetaData("League Points")]
        League,

        [ActivityTypeMetaData("Bounty Hunter Target Kills")]
        BountyHunterTargetKills,

        [ActivityTypeMetaData("Bounty Hunter Rogue Kills")]
        BountyHunterRogueKills,

        [ActivityTypeMetaData("Clue Scrolls: Overall")]
        ClueOverall,

        [ActivityTypeMetaData("Clue Scrolls: Easy")]
        ClueEasy,
        
        [ActivityTypeMetaData("Clue Scrolls: Medium")]
        ClueMedium,
        
        [ActivityTypeMetaData("Clue Scrolls: Hard")]
        ClueHard,
        
        [ActivityTypeMetaData("Clue Scrolls: Elite")]
        ClueElite,
        
        [ActivityTypeMetaData("Clue Scrolls: Master")]
        ClueMaster,
        
        [ActivityTypeMetaData("Last Man Standing")]
        LastManStanding
    }
}
