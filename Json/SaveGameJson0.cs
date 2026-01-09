using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOE.Json
{
	internal class SaveGameJson0
	{
		// this is the first json blob in the quicksave file
		public class Rootobject
		{
			public string title { get; set; }
			public string template { get; set; }
			public int gameMode { get; set; }
			public Campaigninfo campaignInfo { get; set; }
			public string desc { get; set; }
			public string displayWinCondition { get; set; }
			public Datetime dateTime { get; set; }
			public string hashSum { get; set; }
			public bool nameFromLocalization { get; set; }
			public bool descFromLocalization { get; set; }
			public Spawns spawns { get; set; }
			public Startsettings startSettings { get; set; }
			public int sizeX { get; set; }
			public int sizeZ { get; set; }
			public Baninfodata banInfoData { get; set; }
			public int daysInGame { get; set; }
			public bool isAutoSave { get; set; }
			public string gameVersion { get; set; }
		}

		public class Campaigninfo
		{
			public string missionNameSid { get; set; }
			public string missionDescSid { get; set; }
			public string campaignSid { get; set; }
			public string campaignDescSid { get; set; }
			public string hubIconSid { get; set; }
		}

		public class Datetime
		{
			public long value { get; set; }
		}

		public class Spawns
		{
			public int playersCount { get; set; }
			public Spawn[] spawns { get; set; }
			public object[] takenHeroes { get; set; }
		}

		public class Spawn
		{
			public int owner { get; set; }
			public int spawnType { get; set; }
			public string playerId { get; set; }
			public int spawnPointType { get; set; }
			public bool isCityDefined { get; set; }
			public string factionSid { get; set; }
			public bool isHeroDefined { get; set; }
			public string heroSid { get; set; }
			public int colorId { get; set; }
			public bool isAlive { get; set; }
		}

		public class Startsettings
		{
			public int seed { get; set; }
			public int gameSpeedIndex { get; set; }
			public int battleSpeedIndex { get; set; }
			public int difficultyEconomic { get; set; }
			public int difficultyNetrals { get; set; }
			public int difficultyAi { get; set; }
			public int restartPoints { get; set; }
			public int turnMode { get; set; }
			public bool canEndRealtimeOnDay { get; set; }
			public int realtimeEndDay { get; set; }
			public Sidetimersettings sideTimerSettings { get; set; }
			public bool onlyAdminSave { get; set; }
			public int endRealtimeWeek { get; set; }
			public int endRealtimeDay { get; set; }
			public bool weekEffectEnabled { get; set; }
		}

		public class Sidetimersettings
		{
			public bool basicTimersEnabled { get; set; }
			public int startTimeSide { get; set; }
			public int extraTimeDay { get; set; }
			public int incTimeDay { get; set; }
			public int extraTimeWeek { get; set; }
			public int incTimeWeek { get; set; }
			public int maxAccumulationTimes { get; set; }
			public bool battlePVETimerEnabled { get; set; }
			public int startPVETime { get; set; }
			public int minTimeAfterFight { get; set; }
			public int extraTimeAfterFight { get; set; }
			public int minExtraTimeInFight { get; set; }
			public bool battlePVPTimersEnabled { get; set; }
			public int startTimePvP { get; set; }
			public int extraTimePvP { get; set; }
			public bool arenaPVPTimersEnabled { get; set; }
			public int arenaStartPVPTime { get; set; }
			public int arenaExtraPVPTime { get; set; }
			public bool arenaPreparationTimerEnabled { get; set; }
			public int arenaPreparationTime { get; set; }
		}

		public class Baninfodata
		{
			public object[] bannedMagics { get; set; }
			public object[] bannedItems { get; set; }
			public object[] bannedSkills { get; set; }
			public object[] bannedHeroes { get; set; }
			public object[] bannedUnits { get; set; }
		}

	}
}
