using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOE.Json
{
	internal class SaveGameJson1
		// this is the 2nd json blob in the quicksavegame
	{
		public class Rootobject
		{
			public string MapName { get; set; }
			public int sizeX_ { get; set; }
			public int sizeZ_ { get; set; }
			public int[] tilesMap { get; set; }
			public int[] levelsMap { get; set; }
			public int[] climbsMap { get; set; }
			public int[] roadsMap { get; set; }
			public int[] waterMap { get; set; }
			public int cliffRandomSeed { get; set; }
			public View[] views { get; set; }
			public Object[] objects { get; set; }
			public int objectsFreeId { get; set; }
			public object[] squads { get; set; }
			public int squadsFreeId { get; set; }
			public object[] markers { get; set; }
			public int markersFreeId { get; set; }
			public Area[] areas { get; set; }
			public int areasVersion { get; set; }
			public River[] rivers { get; set; }
			public Objectsproperties objectsProperties { get; set; }
			public int[] keyObjects { get; set; }
			public Objectvaluesoverrides objectValuesOverrides { get; set; }
			public Settings settings { get; set; }
			public Baninfodata banInfoData { get; set; }
			public object[] takenHeroes { get; set; }
			public bool haveCustomAreas { get; set; }
			public object[] customAreasPainting { get; set; }
			public string generatorChecksum { get; set; }
		}

		public class Objectsproperties
		{
			public object[] propsName { get; set; }
			public object[] propComments { get; set; }
			public Propspawn[] propSpawns { get; set; }
			public Propcity[] propCities { get; set; }
			public object[] propHeroes { get; set; }
			public Proprandomsquad[] propRandomSquads { get; set; }
			public Proprandomitem[] propRandomItems { get; set; }
			public Proprandomhire[] propRandomHires { get; set; }
			public Propowner[] propOwners { get; set; }
			public object[] propResources { get; set; }
			public object[] propSquads { get; set; }
			public object[] propDialogWindows { get; set; }
			public object[] propPortals { get; set; }
			public object[] propQuestNames { get; set; }
			public object[] propMainObjects { get; set; }
			public object[] propActionsLegacy { get; set; }
			public Propvariant[] propVariants { get; set; }
			public object[] propActionsBefore { get; set; }
			public object[] propActionsAfter { get; set; }
			public object[] propEntities { get; set; }
			public object[] propAiIntetactions { get; set; }
			public object[] propRewardParams { get; set; }
			public object[] propResParams { get; set; }
			public object[] propMarkers { get; set; }
			public Propgrowthunit[] propGrowthUnits { get; set; }
			public object[] propActivations { get; set; }
			public object[] propNoCombineGeometries { get; set; }
			public object[] propCitiesHold { get; set; }
			public object[] propQuestMarkers { get; set; }
		}

		public class Propspawn
		{
			public int type { get; set; }
			public int id { get; set; }
			public int owner { get; set; }
			public int spawnType { get; set; }
			public int spawnPointType { get; set; }
		}

		public class Propcity
		{
			public int type { get; set; }
			public int id { get; set; }
			public bool isDefined { get; set; }
			public string factionSid { get; set; }
			public bool spawnHero { get; set; }
			public string buildingsConstructionSid { get; set; }
			public string buildingsBanSid { get; set; }
			public string customCityName { get; set; }
		}

		public class Proprandomsquad
		{
			public int type { get; set; }
			public int id { get; set; }
			public object[] sids { get; set; }
			public float requestedValue { get; set; }
			public string fraction { get; set; }
			public int tier { get; set; }
			public bool isMainGuard { get; set; }
			public int reactionType { get; set; }
			public string customTopUnit { get; set; }
			public float weeklyIncrementBonus { get; set; }
			public float diplomacyUnitsCountBonus { get; set; }
			public bool isEscape { get; set; }
			public bool isAutobatle { get; set; }
			public bool isFreeDiplomacy { get; set; }
			public bool isCampaignFreeDiplomacy { get; set; }
			public bool isCampaignDiplomacy { get; set; }
			public bool isIgnoreMultiply { get; set; }
			public string obstruction { get; set; }
			public int customStacks { get; set; }
		}

		public class Proprandomitem
		{
			public int type { get; set; }
			public int id { get; set; }
			public int rarity { get; set; }
		}

		public class Proprandomhire
		{
			public int type { get; set; }
			public int id { get; set; }
			public int tier { get; set; }
			public int fraction { get; set; }
		}

		public class Propowner
		{
			public int type { get; set; }
			public int id { get; set; }
			public int owner { get; set; }
		}

		public class Propvariant
		{
			public int type { get; set; }
			public int id { get; set; }
			public int selectedVar { get; set; }
			public int typeVariant { get; set; }
			public int fraction { get; set; }
			public int unitVersion { get; set; }
		}

		public class Propgrowthunit
		{
			public int type { get; set; }
			public int id { get; set; }
			public bool isConstantGrowth { get; set; }
			public int countGrowth { get; set; }
		}

		public class Objectvaluesoverrides
		{
			public object[] list { get; set; }
		}

		public class Settings
		{
			public int heroCountMin { get; set; }
			public int heroCountMax { get; set; }
			public int heroCountIncrement { get; set; }
			public bool enableHeroHireBan { get; set; }
			public bool enableCustomHeroMaxLevel { get; set; }
			public int customHeroMaxLevel { get; set; }
			public bool isTournamentRules { get; set; }
			public Bonus[] bonuses { get; set; }
			public Mapwincondition[] mapWinConditions { get; set; }
			public int gameMode { get; set; }
			public bool enableCustomAI { get; set; }
			public string customAISid { get; set; }
			public float[] uniqueMagicCostModifiers { get; set; }
		}

		public class Bonus
		{
			public string sid { get; set; }
			public int receiverSide { get; set; }
			public string receiverFilter { get; set; }
			public string[] parameters { get; set; }
		}

		public class Mapwincondition
		{
			public int typeWinCondition { get; set; }
			public float valueDesertion { get; set; }
			public int dayAdditionWinCondition { get; set; }
			public object[] heroSids { get; set; }
			public int indexSideCampaign { get; set; }
			public object[] indexOtherPlayers { get; set; }
			public string sidBuildWinCondition { get; set; }
			public bool isRegistrationStartWork { get; set; }
			public bool isRegistrationStartFight { get; set; }
			public int daysDelayStart { get; set; }
			public int countDayGladiatorArena { get; set; }
			public int countDayLostStartCity { get; set; }
			public int countDayCityHold { get; set; }
			public object[] daysAnounceTournament { get; set; }
			public object[] daysDelayStartFightTournament { get; set; }
			public int countPointsTournament { get; set; }
			public bool isSaveArmyTournament { get; set; }
		}

		public class Baninfodata
		{
			public object[] bannedMagics { get; set; }
			public object[] bannedItems { get; set; }
			public object[] bannedSkills { get; set; }
			public object[] bannedHeroes { get; set; }
			public object[] bannedUnits { get; set; }
		}

		public class View
		{
			public string name { get; set; }
			public int minSecX { get; set; }
			public int minSecZ { get; set; }
			public int secSizeX { get; set; }
			public int secSizeZ { get; set; }
			public bool isUnderground { get; set; }
			public int stack { get; set; }
		}

		public class Object
		{
			public string sid { get; set; }
			public int[] ids { get; set; }
			public int[] nodes { get; set; }
			public int[] rotations { get; set; }
			public float[] levels { get; set; }
		}

		public class Area
		{
			public int id { get; set; }
			public int keyObjectId { get; set; }
			public int rootNode { get; set; }
			public int[] nodes { get; set; }
			public int[] neighbors { get; set; }
			public string biome { get; set; }
		}

		public class River
		{
			public string sid { get; set; }
			public int randomSeed { get; set; }
			public object[] nodes { get; set; }
		}

	}
}
