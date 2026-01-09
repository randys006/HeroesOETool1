using HeroesOE.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static HeroesOE.Json.DungeonCityJson;

namespace HeroesOE
{
	internal class SaveGamePlayersJson
	{
		public class SaveGamePlayers
		{
			public SaveGamePlayers(string save)
			{
				tokens = JsonSerializer.Deserialize<Rootobject>(save).tokens;
				foreach (var token in tokens)
				{
					// TODO: parse DungeonCity
					Debug.WriteLine($"Player {token.index}: {token.name}:");
					var res = token.res;
					Debug.WriteLine($"     RES: {res.gold.value,7} {res.wood.value,4} {res.ore.value,4} {res.gemstones.value,4} {res.crystals.value,4} {res.mercury.value,4} {res.dust.value,4}");
				}
			}

			public Token[] tokens;

		}

		public class Rootobject
		{
			[System.Text.Json.Serialization.JsonPropertyName("array")]
			public Token[] tokens { get; set; }
		}

		public class Token
		{
			public bool turnEnded_ { get; set; }
			public string name { get; set; }
			public int index { get; set; }
			public int status { get; set; }
			public int turnQueue { get; set; }
			public int typeOnCreate { get; set; }
			public Res res { get; set; }
			public Fogdata fogData { get; set; }
			public Rewardsets rewardSets { get; set; }
			public Heroeshirepool heroesHirePool { get; set; }
			public Heroesreservepool heroesReservePool { get; set; }
			public Fractionlaws fractionLaws { get; set; }
			public Sidemagics sideMagics { get; set; }
			public Sideheroes sideHeroes { get; set; }
			public Sideobjects sideObjects { get; set; }
			public Garrisonparty garrisonParty { get; set; }
			public Garrisoninventory garrisonInventory { get; set; }
			public int currentState_ { get; set; }
			public int colorId { get; set; }
			public string fraction { get; set; }
			public string startHeroSid { get; set; }
			public int startSpawnId { get; set; }
			public object[] campaignSpawns { get; set; }
			public int currentLevel { get; set; }
			public int currentExp { get; set; }
			public int currentLawsPoints { get; set; }
			public int insaraPoints { get; set; }
			public bool isWinConditionHighlight { get; set; }
			public Datatimerside dataTimerSide { get; set; }
			public bool useMagicInAutoBattle { get; set; }
			public int restartPoints { get; set; }
			public Additionalstats additionalStats { get; set; }
			public Buffs buffs { get; set; }
			public Aidata aiData { get; set; }
			public int lastSelectedHero { get; set; }
			public int startCityId { get; set; }
			public int debugRandomNumber { get; set; }
		}

		public class Res
		{
			public Gold gold { get; set; }
			public Wood wood { get; set; }
			public Ore ore { get; set; }
			public Gemstones gemstones { get; set; }
			public Crystals crystals { get; set; }
			public Mercury mercury { get; set; }
			public Dust dust { get; set; }
			public Graal graal { get; set; }
		}

		public class Gold
		{
			public string name { get; set; }
			public int value { get; set; }
		}

		public class Wood
		{
			public string name { get; set; }
			public int value { get; set; }
		}

		public class Ore
		{
			public string name { get; set; }
			public int value { get; set; }
		}

		public class Gemstones
		{
			public string name { get; set; }
			public int value { get; set; }
		}

		public class Crystals
		{
			public string name { get; set; }
			public int value { get; set; }
		}

		public class Mercury
		{
			public string name { get; set; }
			public int value { get; set; }
		}

		public class Dust
		{
			public string name { get; set; }
			public int value { get; set; }
		}

		public class Graal
		{
			public string name { get; set; }
			public int value { get; set; }
		}

		public class Fogdata
		{
			public bool[] visibilityMap { get; set; }
			public int sizeX { get; set; }
			public int sizeZ { get; set; }
		}

		public class Rewardsets
		{
			public object[] list { get; set; }
			public int freeId { get; set; }
		}

		public class Heroeshirepool
		{
			public int[] heroes { get; set; }
		}

		public class Heroesreservepool
		{
			public int heroId { get; set; }
		}

		public class Fractionlaws
		{
			public string fraction { get; set; }
			public List[] list { get; set; }
			public int spentPoints { get; set; }
		}

		public class List
		{
			public string sid { get; set; }
			public int line { get; set; }
			public int group { get; set; }
			public int level { get; set; }
			public bool wasApplied { get; set; }
		}

		public class Sidemagics
		{
			public int todaysLearningsCount { get; set; }
			public bool isCustomLearningBlocked { get; set; }
			public int[] learningsCountByRanks { get; set; }
			public Magic[] magics { get; set; }
			public Uniquemagic[] uniqueMagics { get; set; }
			public float[] uniqueMagicCostModifiers { get; set; }
			public int gameMode { get; set; }
		}

		public class Magic
		{
			public string sid { get; set; }
			public bool isLearned { get; set; }
			public int upgradeLevel { get; set; }
			public bool wasCustomUpgrade { get; set; }
		}

		public class Uniquemagic
		{
			public string sid { get; set; }
			public bool isLearned { get; set; }
			public int upgradeLevel { get; set; }
			public bool wasCustomUpgrade { get; set; }
		}

		public class Sideheroes
		{
			public int[] heroes { get; set; }
		}

		public class Sideobjects
		{
			public Allobjectsbytype allObjectsByType { get; set; }
		}

		public class Allobjectsbytype
		{
			public Datum[] data { get; set; }
		}

		public class Datum
		{
			public int key { get; set; }
			public int?[] val { get; set; }
		}

		public class Garrisonparty
		{
			public object[] units { get; set; }
		}

		public class Garrisoninventory
		{
			public string sid { get; set; }
			public int containerType { get; set; }
			public Itemslot[] itemSlots { get; set; }
			public Lockslot[] lockSlots { get; set; }
		}

		public class Itemslot
		{
			public int type { get; set; }
			public int maxCount { get; set; }
			public bool isInfinite { get; set; }
			public object[] items { get; set; }
		}

		public class Lockslot
		{
			public int type { get; set; }
			public int maxCount { get; set; }
			public bool isInfinite { get; set; }
			public object[] items { get; set; }
		}

		public class Datatimerside
		{
			public float startTime { get; set; }
			public int extraTimeDay { get; set; }
			public int incTimeDay { get; set; }
			public int extraTimeWeek { get; set; }
			public int incTimeWeek { get; set; }
			public int maxAccumulationTimes { get; set; }
			public float currentTimeFight { get; set; }
			public int extraTimeFight { get; set; }
			public int minTimeAfterFight { get; set; }
			public int extraTimeAfterFight { get; set; }
			public int minExtraTimeInFight { get; set; }
			public float startTimePVP { get; set; }
			public int extraTimePVP { get; set; }
			public float viewTimePVP { get; set; }
			public float viewExtraTimePVP { get; set; }
			public float arenaPreparationTime { get; set; }
			public bool isFightSetup { get; set; }
			public string nameTypeTimer { get; set; }
			public bool isTimerWork { get; set; }
			public int numberTypeTimerAction { get; set; }
			public int indexPlayer { get; set; }
			public bool isArenaGame { get; set; }
			public bool basicTimerEnabled { get; set; }
			public bool battlePVETimerEnabled { get; set; }
			public bool battlePVPTimersEnabled { get; set; }
			public bool arenaPreparationTimerEnabled { get; set; }
		}

		public class Additionalstats
		{
			public Magicsidset magicSidSet { get; set; }
			public Magicschoolset magicSchoolSet { get; set; }
			public float magicLearnCostPerBonus { get; set; }
			public float magicUpgradeCostPerBonus { get; set; }
			public float itemUpgradeCostPerBonus { get; set; }
			public float heroCostPerBonus { get; set; }
			public float unitsFromBarracksIncrementPerBonus { get; set; }
			public float cityExpCoef { get; set; }
			public bool disableMarketsExtraCharge { get; set; }
			public int tempMagicLevelBonus { get; set; }
			public int decreaseLawPointsOpenLine { get; set; }
			public float percentDustForDestroyItem { get; set; }
		}

		public class Magicsidset
		{
			public object[] statsList { get; set; }
		}

		public class Magicschoolset
		{
			public Statsbyschool[] statsBySchool { get; set; }
		}

		public class Statsbyschool
		{
			public int school { get; set; }
			public int maxAvailableRank { get; set; }
			public int levelBonus { get; set; }
		}

		public class Buffs
		{
			public object[] list { get; set; }
		}

		public class Aidata
		{
			public int heroesHiredToday { get; set; }
			public bool heroDieOnThisTurn { get; set; }
			public Objectpergame objectPerGame { get; set; }
			public Objectperweek objectPerWeek { get; set; }
			public Markedsquads markedSquads { get; set; }
			public int markedObject { get; set; }
			public int markedCity { get; set; }
			public int makredEnemyCity { get; set; }
			public int markedCityToCourier { get; set; }
			public int markedNode { get; set; }
			public int markedHero { get; set; }
			public Blockedareas blockedAreas { get; set; }
			public int?[] areasReachable { get; set; }
			public int?[] areasLastOpen { get; set; }
			public Unitsupgrade unitsUpgrade { get; set; }
			public Markedareaguard markedAreaGuard { get; set; }
			public int markedCityToUnitUpgrade { get; set; }
			public Bannedareas bannedAreas { get; set; }
			public bool[] bannedAreasMap { get; set; }
			public string hardStrategy { get; set; }
		}

		public class Objectpergame
		{
			public object[] data { get; set; }
		}

		public class Objectperweek
		{
			public object[] data { get; set; }
		}

		public class Markedsquads
		{
			public object[] data { get; set; }
		}

		public class Blockedareas
		{
			public object[] data { get; set; }
		}

		public class Unitsupgrade
		{
			public Datum1[] data { get; set; }
		}

		public class Datum1
		{
			public string key { get; set; }
			public string val { get; set; }
		}

		public class Markedareaguard
		{
			public int eType { get; set; }
			public int id { get; set; }
			public int node { get; set; }
		}

		public class Bannedareas
		{
			public object[] data { get; set; }
		}

	}
}
