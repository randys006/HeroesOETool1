using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOETool
{
	internal class sg3
	{
		public class Rootobject
		{
			public string Description { get; set; }
			public string Path { get; set; }
			public string WrittenDateTimeUtc { get; set; }
			public Rootobject1 rootobject { get; set; }
		}

		public class Rootobject1
		{
			public Objects objects { get; set; }
			public Markers markers { get; set; }
			public Sides sides { get; set; }
			public Heroes heroes { get; set; }
			public Squads squads { get; set; }
			public Areas areas { get; set; }
			public Items items { get; set; }
			public Buffs2 buffs { get; set; }
			public Weeks weeks { get; set; }
			public Weather weather { get; set; }
			public Turnmode turnMode { get; set; }
			public Winconditionsdata winConditionsData { get; set; }
			public Mapbonuses mapBonuses { get; set; }
			public Randomitemspool randomItemsPool { get; set; }
			public Randommagicspool randomMagicsPool { get; set; }
			public Randomskillspool randomSkillsPool { get; set; }
			public object[] campaignCounters { get; set; }
			public int daysInGameCount { get; set; }
			public int day { get; set; }
			public int week { get; set; }
			public int month { get; set; }
			public Timetracerdata timeTracerData { get; set; }
			public Propertiesactions propertiesActions { get; set; }
			public Startinfo startInfo { get; set; }
			public Restartinfo restartInfo { get; set; }
			public bool enableFactionLaws { get; set; }
			public bool enableMagicGuild { get; set; }
			public int mapGeneratorChecksum { get; set; }
			public int customHeroMaxLevel { get; set; }
			public bool startingNewDay { get; set; }
		}

		public class Objects
		{
			public Resobj[] resObjs { get; set; }
			public object[] todoObjs { get; set; }
			public Hireobj[] hireObjs { get; set; }
			public Itemobj[] itemObjs { get; set; }
			public Eventbankobj[] eventBankObjs { get; set; }
			public Resmine[] resMines { get; set; }
			public Cityobj[] cityObjs { get; set; }
			public Marketobj[] marketObjs { get; set; }
			public Tavernobj[] tavernObjs { get; set; }
			public object[] portalObjs { get; set; }
			public object[] blockObjs { get; set; }
			public Chestobj[] chestObjs { get; set; }
			public Prisonobj[] prisonObjs { get; set; }
			public Restradelab[] resTradeLabs { get; set; }
			public object[] outposts { get; set; }
			public Garrison[] garrisons { get; set; }
			public Itemmarket[] itemMarkets { get; set; }
			public Randomhire[] randomHires { get; set; }
			public Unitupgrade[] unitUpgrades { get; set; }
			public object[] eternalDragons { get; set; }
			public object[] insarasEyes { get; set; }
			public Chimerologist[] chimerologists { get; set; }
			public Sacrificialshrine[] sacrificialShrines { get; set; }
			public object[] gladiatorArenas { get; set; }
			public Mirage[] mirages { get; set; }
			public object[] fickleShrines { get; set; }
			public Magicmine[] magicMines { get; set; }
			public object[] townGates { get; set; }
			public object[] unitResTradeLabs { get; set; }
			public Citiesnamespool citiesNamesPool { get; set; }
		}

		public class Citiesnamespool
		{
			public Citiesnamesperfractiondict citiesNamesPerFractionDict { get; set; }
		}

		public class Citiesnamesperfractiondict
		{
			public Datum[] data { get; set; }
		}

		public class Datum
		{
			public string key { get; set; }
			public Val val { get; set; }
		}

		public class Val
		{
			public string[] citiesNamesList { get; set; }
		}

		public class Resobj
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public object[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty garnisonParty { get; set; }
			public Rewardset rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
			public Resourceslist[] resourcesList { get; set; }
		}

		public class Garnisonparty
		{
			public object[] units { get; set; }
		}

		public class Rewardset
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public object[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public object[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Resourceslist
		{
			public string name { get; set; }
			public int value { get; set; }
		}

		public class Hireobj
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public Property1[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty1 garnisonParty { get; set; }
			public Rewardset1 rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
			public Initguardunit[] initGuardUnits { get; set; }
			public Assortmentdata assortmentData { get; set; }
			public bool isConstantGrowth { get; set; }
			public int countGrowth { get; set; }
		}

		public class Garnisonparty1
		{
			public Unit[] units { get; set; }
		}

		public class Unit
		{
			public string sid { get; set; }
			public int stacks { get; set; }
			public int slotPos { get; set; }
		}

		public class Rewardset1
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public object[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public object[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Assortmentdata
		{
			public Unitset[] unitSets { get; set; }
			public int extraCharge { get; set; }
		}

		public class Unitset
		{
			public string[] sids { get; set; }
			public int level { get; set; }
			public int weeklyIncrement { get; set; }
			public int currentAmount { get; set; }
		}

		public class Property1
		{
			public int id { get; set; }
			public bool active { get; set; }
			public int dataId { get; set; }
		}

		public class Initguardunit
		{
			public string sid { get; set; }
			public int stacks { get; set; }
			public int slotPos { get; set; }
		}

		public class Itemobj
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public Property2[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty2 garnisonParty { get; set; }
			public Rewardset2 rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
		}

		public class Garnisonparty2
		{
			public object[] units { get; set; }
		}

		public class Rewardset2
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public object[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public object[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Property2
		{
			public int id { get; set; }
			public bool active { get; set; }
			public int dataId { get; set; }
		}

		public class Eventbankobj
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public Property3[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty3 garnisonParty { get; set; }
			public Rewardset3 rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
			public object[] visitorsList { get; set; }
		}

		public class Garnisonparty3
		{
			public Unit1[] units { get; set; }
		}

		public class Unit1
		{
			public string sid { get; set; }
			public int stacks { get; set; }
			public int slotPos { get; set; }
		}

		public class Rewardset3
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public Cost[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public Reward[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Cost
		{
			public string name { get; set; }
			public int cost { get; set; }
		}

		public class Reward
		{
			public string stringRewardType { get; set; }
			public int rewardType { get; set; }
			public int rewardShowType { get; set; }
			public bool applyRewardFloating { get; set; }
			public string rewardIcon { get; set; }
			public string rewardName { get; set; }
			public string rewardDesc { get; set; }
			public string rewardNotificationDesc { get; set; }
			public string[] parameters { get; set; }
		}

		public class Property3
		{
			public int id { get; set; }
			public bool active { get; set; }
			public int dataId { get; set; }
		}

		public class Resmine
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public object[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty4 garnisonParty { get; set; }
			public Rewardset4 rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
		}

		public class Garnisonparty4
		{
			public object[] units { get; set; }
		}

		public class Rewardset4
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public object[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public object[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Cityobj
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public Property4[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty5 garnisonParty { get; set; }
			public Rewardset5 rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
			public int garnisonHeroId { get; set; }
			public int visitorHeroId { get; set; }
			public Visitparty visitParty { get; set; }
			public Buildings buildings { get; set; }
			public string cityName { get; set; }
			public int garrisonStartValue { get; set; }
			public float garrisonWeeklyIncrementBonus { get; set; }
			public int aiBuildOrder { get; set; }
			public bool isConstantGrowth { get; set; }
			public int countGrowth { get; set; }
		}

		public class Garnisonparty5
		{
			public Unit2[] units { get; set; }
		}

		public class Unit2
		{
			public string sid { get; set; }
			public int stacks { get; set; }
			public int slotPos { get; set; }
		}

		public class Rewardset5
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public object[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public object[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Visitparty
		{
			public object[] units { get; set; }
		}

		public class Buildings
		{
			public Main[] mains { get; set; }
			public Tavern[] taverns { get; set; }
			public Market[] markets { get; set; }
			public Hire[] hires { get; set; }
			public Magicguild[] magicGuilds { get; set; }
			public Bank[] banks { get; set; }
			public Manafountain[] manaFountains { get; set; }
			public Intelligence[] intelligences { get; set; }
			public Bonusbank[] bonusBanks { get; set; }
			public Unitsconverter[] unitsConverters { get; set; }
			public Trainingrange[] trainingRanges { get; set; }
			public object[] rebirthShrines { get; set; }
			public Herobonusbank[] heroBonusBanks { get; set; }
			public object[] cityBonusBanks { get; set; }
			public object[] myceliumRoots { get; set; }
			public Portalsummoning[] portalSummonings { get; set; }
			public Artifactchanger[] artifactChangers { get; set; }
			public Artifactmarket[] artifactMarkets { get; set; }
			public Wall[] walls { get; set; }
			public int todaysConstructionsCount { get; set; }
		}

		public class Main
		{
			public bool wasApplied { get; set; }
			public string sid { get; set; }
			public int level { get; set; }
			public bool isConstructed { get; set; }
			public string citySid { get; set; }
			public bool[] bansPerLevel { get; set; }
			public int levelOnStart { get; set; }
		}

		public class Tavern
		{
			public string sid { get; set; }
			public int level { get; set; }
			public bool isConstructed { get; set; }
			public string citySid { get; set; }
			public bool[] bansPerLevel { get; set; }
			public int levelOnStart { get; set; }
		}

		public class Market
		{
			public string sid { get; set; }
			public int level { get; set; }
			public bool isConstructed { get; set; }
			public string citySid { get; set; }
			public bool[] bansPerLevel { get; set; }
			public int levelOnStart { get; set; }
		}

		public class Hire
		{
			public Assortment assortment { get; set; }
			public bool isUsePropGrowth { get; set; }
			public string sid { get; set; }
			public int level { get; set; }
			public bool isConstructed { get; set; }
			public string citySid { get; set; }
			public bool[] bansPerLevel { get; set; }
			public int levelOnStart { get; set; }
		}

		public class Assortment
		{
			public Unitset1[] unitSets { get; set; }
			public int extraCharge { get; set; }
		}

		public class Unitset1
		{
			public string[] sids { get; set; }
			public int level { get; set; }
			public int weeklyIncrement { get; set; }
			public int currentAmount { get; set; }
		}

		public class Magicguild
		{
			public Magicguildsinfo[] magicGuildsInfo { get; set; }
			public string sid { get; set; }
			public int level { get; set; }
			public bool isConstructed { get; set; }
			public string citySid { get; set; }
			public bool[] bansPerLevel { get; set; }
			public int levelOnStart { get; set; }
		}

		public class Magicguildsinfo
		{
			public Magicsdict magicsDict { get; set; }
		}

		public class Magicsdict
		{
			public Datum1[] data { get; set; }
		}

		public class Datum1
		{
			public string key { get; set; }
			public Val1 val { get; set; }
		}

		public class Val1
		{
			public string magicSid { get; set; }
			public object[] ownersIndex { get; set; }
		}

		public class Bank
		{
			public bool wasApplied { get; set; }
			public string sid { get; set; }
			public int level { get; set; }
			public bool isConstructed { get; set; }
			public string citySid { get; set; }
			public bool[] bansPerLevel { get; set; }
			public int levelOnStart { get; set; }
		}

		public class Manafountain
		{
			public string sid { get; set; }
			public int level { get; set; }
			public bool isConstructed { get; set; }
			public string citySid { get; set; }
			public bool[] bansPerLevel { get; set; }
			public int levelOnStart { get; set; }
		}

		public class Intelligence
		{
			public string sid { get; set; }
			public int level { get; set; }
			public bool isConstructed { get; set; }
			public string citySid { get; set; }
			public bool[] bansPerLevel { get; set; }
			public int levelOnStart { get; set; }
		}

		public class Bonusbank
		{
			public string sid { get; set; }
			public int level { get; set; }
			public bool isConstructed { get; set; }
			public string citySid { get; set; }
			public bool[] bansPerLevel { get; set; }
			public int levelOnStart { get; set; }
		}

		public class Unitsconverter
		{
			public string sid { get; set; }
			public int level { get; set; }
			public bool isConstructed { get; set; }
			public string citySid { get; set; }
			public bool[] bansPerLevel { get; set; }
			public int levelOnStart { get; set; }
		}

		public class Trainingrange
		{
			public string sid { get; set; }
			public int level { get; set; }
			public bool isConstructed { get; set; }
			public string citySid { get; set; }
			public bool[] bansPerLevel { get; set; }
			public int levelOnStart { get; set; }
		}

		public class Herobonusbank
		{
			public object[] listIndexVisitorHeroes { get; set; }
			public string sid { get; set; }
			public int level { get; set; }
			public bool isConstructed { get; set; }
			public string citySid { get; set; }
			public bool[] bansPerLevel { get; set; }
			public int levelOnStart { get; set; }
		}

		public class Portalsummoning
		{
			public string sid { get; set; }
			public int level { get; set; }
			public bool isConstructed { get; set; }
			public string citySid { get; set; }
			public bool[] bansPerLevel { get; set; }
			public int levelOnStart { get; set; }
		}

		public class Artifactchanger
		{
			public string sid { get; set; }
			public int level { get; set; }
			public bool isConstructed { get; set; }
			public string citySid { get; set; }
			public bool[] bansPerLevel { get; set; }
			public int levelOnStart { get; set; }
		}

		public class Artifactmarket
		{
			public Itemmarketpool itemMarketPool { get; set; }
			public string sid { get; set; }
			public int level { get; set; }
			public bool isConstructed { get; set; }
			public string citySid { get; set; }
			public bool[] bansPerLevel { get; set; }
			public int levelOnStart { get; set; }
		}

		public class Itemmarketpool
		{
			public Item[] items { get; set; }
			public int[] itemsCountPerRarity { get; set; }
			public bool isCity { get; set; }
		}

		public class Item
		{
			public string sid { get; set; }
			public int level { get; set; }
		}

		public class Wall
		{
			public string[] selectedEffectsList { get; set; }
			public int[] selectedEffectsPerLevel { get; set; }
			public bool wasApplied { get; set; }
			public string sid { get; set; }
			public int level { get; set; }
			public bool isConstructed { get; set; }
			public string citySid { get; set; }
			public bool[] bansPerLevel { get; set; }
			public int levelOnStart { get; set; }
		}

		public class Property4
		{
			public int id { get; set; }
			public bool active { get; set; }
			public int dataId { get; set; }
		}

		public class Marketobj
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public object[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty6 garnisonParty { get; set; }
			public Rewardset6 rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
		}

		public class Garnisonparty6
		{
			public object[] units { get; set; }
		}

		public class Rewardset6
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public object[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public object[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Tavernobj
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public object[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty7 garnisonParty { get; set; }
			public Rewardset7 rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
		}

		public class Garnisonparty7
		{
			public object[] units { get; set; }
		}

		public class Rewardset7
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public object[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public object[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Chestobj
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public Property5[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty8 garnisonParty { get; set; }
			public Rewardset8 rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
		}

		public class Garnisonparty8
		{
			public object[] units { get; set; }
		}

		public class Rewardset8
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public object[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public Reward1[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Reward1
		{
			public string stringRewardType { get; set; }
			public int rewardType { get; set; }
			public int rewardShowType { get; set; }
			public bool applyRewardFloating { get; set; }
			public string rewardIcon { get; set; }
			public string rewardName { get; set; }
			public string rewardDesc { get; set; }
			public string rewardNotificationDesc { get; set; }
			public string[] parameters { get; set; }
		}

		public class Property5
		{
			public int id { get; set; }
			public bool active { get; set; }
			public int dataId { get; set; }
		}

		public class Prisonobj
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public Property6[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty9 garnisonParty { get; set; }
			public Rewardset9 rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
			public string heroSid { get; set; }
		}

		public class Garnisonparty9
		{
			public object[] units { get; set; }
		}

		public class Rewardset9
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public object[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public Reward2[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Reward2
		{
			public string stringRewardType { get; set; }
			public int rewardType { get; set; }
			public int rewardShowType { get; set; }
			public bool applyRewardFloating { get; set; }
			public string rewardIcon { get; set; }
			public string rewardName { get; set; }
			public string rewardDesc { get; set; }
			public string rewardNotificationDesc { get; set; }
			public string[] parameters { get; set; }
		}

		public class Property6
		{
			public int id { get; set; }
			public bool active { get; set; }
			public int dataId { get; set; }
		}

		public class Restradelab
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public object[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty10 garnisonParty { get; set; }
			public Rewardset10 rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
		}

		public class Garnisonparty10
		{
			public object[] units { get; set; }
		}

		public class Rewardset10
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public object[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public object[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Garrison
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public object[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty11 garnisonParty { get; set; }
			public Rewardset11 rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
		}

		public class Garnisonparty11
		{
			public object[] units { get; set; }
		}

		public class Rewardset11
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public object[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public object[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Itemmarket
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public object[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty12 garnisonParty { get; set; }
			public Rewardset12 rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
			public Itemmarketpool1 itemMarketPool { get; set; }
		}

		public class Garnisonparty12
		{
			public object[] units { get; set; }
		}

		public class Rewardset12
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public object[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public object[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Itemmarketpool1
		{
			public Item1[] items { get; set; }
			public int[] itemsCountPerRarity { get; set; }
			public bool isCity { get; set; }
		}

		public class Item1
		{
			public string sid { get; set; }
			public int level { get; set; }
		}

		public class Randomhire
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public object[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty13 garnisonParty { get; set; }
			public Rewardset13 rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
			public Assortmentdata1 assortmentData { get; set; }
			public bool needRefresh { get; set; }
		}

		public class Garnisonparty13
		{
			public object[] units { get; set; }
		}

		public class Rewardset13
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public object[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public object[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Assortmentdata1
		{
			public Unitset2[] unitSets { get; set; }
			public int extraCharge { get; set; }
		}

		public class Unitset2
		{
			public string[] sids { get; set; }
			public int level { get; set; }
			public int weeklyIncrement { get; set; }
			public int currentAmount { get; set; }
		}

		public class Unitupgrade
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public object[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty14 garnisonParty { get; set; }
			public Rewardset14 rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
		}

		public class Garnisonparty14
		{
			public object[] units { get; set; }
		}

		public class Rewardset14
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public object[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public object[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Chimerologist
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public object[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty15 garnisonParty { get; set; }
			public Rewardset15 rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
			public Dataparty dataParty { get; set; }
		}

		public class Garnisonparty15
		{
			public object[] units { get; set; }
		}

		public class Rewardset15
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public object[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public object[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Dataparty
		{
			public object[] units { get; set; }
		}

		public class Sacrificialshrine
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public object[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty16 garnisonParty { get; set; }
			public Rewardset16 rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
			public Dataparty1 dataParty { get; set; }
			public Datainventory dataInventory { get; set; }
		}

		public class Garnisonparty16
		{
			public object[] units { get; set; }
		}

		public class Rewardset16
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public object[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public object[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Dataparty1
		{
			public object[] units { get; set; }
		}

		public class Datainventory
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

		public class Mirage
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public Property7[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty17 garnisonParty { get; set; }
			public Rewardset17 rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
			public Dataparty2 dataParty { get; set; }
			public bool isVisit { get; set; }
		}

		public class Garnisonparty17
		{
			public object[] units { get; set; }
		}

		public class Rewardset17
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public object[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public Reward3[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Reward3
		{
			public string stringRewardType { get; set; }
			public int rewardType { get; set; }
			public int rewardShowType { get; set; }
			public bool applyRewardFloating { get; set; }
			public string rewardIcon { get; set; }
			public string rewardName { get; set; }
			public string rewardDesc { get; set; }
			public string rewardNotificationDesc { get; set; }
			public string[] parameters { get; set; }
		}

		public class Dataparty2
		{
			public object[] units { get; set; }
		}

		public class Property7
		{
			public int id { get; set; }
			public bool active { get; set; }
			public int dataId { get; set; }
		}

		public class Magicmine
		{
			public int idMapObject { get; set; }
			public string sidConfig { get; set; }
			public bool released { get; set; }
			public int ownerSide { get; set; }
			public bool isNeutralObj { get; set; }
			public object[] properties { get; set; }
			public int aiValue { get; set; }
			public Garnisonparty18 garnisonParty { get; set; }
			public Rewardset18 rewardSet { get; set; }
			public object[] sideScoutings { get; set; }
			public int lastInteractedSide { get; set; }
		}

		public class Garnisonparty18
		{
			public object[] units { get; set; }
		}

		public class Rewardset18
		{
			public int showType { get; set; }
			public int applyType { get; set; }
			public int cancelType { get; set; }
			public object[] cost { get; set; }
			public bool cantCompleteApplying { get; set; }
			public object[] rewards { get; set; }
			public int id { get; set; }
			public int heroId { get; set; }
			public int objectId { get; set; }
			public string label { get; set; }
			public string selectionWindowType { get; set; }
		}

		public class Markers
		{
			public object[] list { get; set; }
		}

		public class Sides
		{
			public int myIndex { get; set; }
			public int[] hotseatSides { get; set; }
			public Array[] array { get; set; }
		}

		public class Array
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
			public int[] uniqueMagicCostModifiers { get; set; }
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
			public Datum2[] data { get; set; }
		}

		public class Datum2
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
			public Itemslot1[] itemSlots { get; set; }
			public Lockslot1[] lockSlots { get; set; }
		}

		public class Itemslot1
		{
			public int type { get; set; }
			public int maxCount { get; set; }
			public bool isInfinite { get; set; }
			public object[] items { get; set; }
		}

		public class Lockslot1
		{
			public int type { get; set; }
			public int maxCount { get; set; }
			public bool isInfinite { get; set; }
			public object[] items { get; set; }
		}

		public class Datatimerside
		{
			public int startTime { get; set; }
			public int extraTimeDay { get; set; }
			public int incTimeDay { get; set; }
			public int extraTimeWeek { get; set; }
			public int incTimeWeek { get; set; }
			public int maxAccumulationTimes { get; set; }
			public int currentTimeFight { get; set; }
			public int extraTimeFight { get; set; }
			public int minTimeAfterFight { get; set; }
			public int extraTimeAfterFight { get; set; }
			public int minExtraTimeInFight { get; set; }
			public int startTimePVP { get; set; }
			public int extraTimePVP { get; set; }
			public int viewTimePVP { get; set; }
			public int viewExtraTimePVP { get; set; }
			public int arenaPreparationTime { get; set; }
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
			public int magicLearnCostPerBonus { get; set; }
			public int magicUpgradeCostPerBonus { get; set; }
			public int itemUpgradeCostPerBonus { get; set; }
			public int heroCostPerBonus { get; set; }
			public int unitsFromBarracksIncrementPerBonus { get; set; }
			public int cityExpCoef { get; set; }
			public bool disableMarketsExtraCharge { get; set; }
			public int tempMagicLevelBonus { get; set; }
			public int decreaseLawPointsOpenLine { get; set; }
			public int percentDustForDestroyItem { get; set; }
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
			public object[] data { get; set; }
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

		public class Heroes
		{
			public int freeId { get; set; }
			public List1[] list { get; set; }
			public Pool pool { get; set; }
		}

		public class Pool
		{
			public int[] list { get; set; }
		}

		public class List1
		{
			public int id { get; set; }
			public int sideId { get; set; }
			public int node { get; set; }
			public int rotationAngle { get; set; }
			public bool inBattle_ { get; set; }
			public int status { get; set; }
			public string configSid { get; set; }
			public string mountSid { get; set; }
			public string skillsRollVariant { get; set; }
			public string unitsNativeBiome { get; set; }
			public int worldMovePoints { get; set; }
			public int currentLevel { get; set; }
			public int currentExp { get; set; }
			public int mana { get; set; }
			public Dataenergy[] dataEnergies { get; set; }
			public Party party { get; set; }
			public Slots slots { get; set; }
			public Inventory inventory { get; set; }
			public Statsbylevel statsByLevel { get; set; }
			public Additionalstats1 additionalStats { get; set; }
			public Skills skills { get; set; }
			public Buffs1 buffs { get; set; }
			public Magics magics { get; set; }
			public Aidata1 aiData { get; set; }
			public Leveluppool levelUpPool { get; set; }
			public Specialization specialization { get; set; }
			public Subclasses subClasses { get; set; }
			public Pickedbonuses pickedBonuses { get; set; }
			public bool disableAiHero { get; set; }
			public bool disableAiResurect { get; set; }
		}

		public class Party
		{
			public Unit3[] units { get; set; }
		}

		public class Unit3
		{
			public string sid { get; set; }
			public int stacks { get; set; }
			public int slotPos { get; set; }
		}

		public class Slots
		{
			public string sid { get; set; }
			public int containerType { get; set; }
			public Itemslot2[] itemSlots { get; set; }
			public Lockslot2[] lockSlots { get; set; }
		}

		public class Itemslot2
		{
			public int type { get; set; }
			public int maxCount { get; set; }
			public bool isInfinite { get; set; }
			public int[] items { get; set; }
		}

		public class Lockslot2
		{
			public int type { get; set; }
			public int maxCount { get; set; }
			public bool isInfinite { get; set; }
			public int[] items { get; set; }
		}

		public class Inventory
		{
			public string sid { get; set; }
			public int containerType { get; set; }
			public Itemslot3[] itemSlots { get; set; }
			public Lockslot3[] lockSlots { get; set; }
		}

		public class Itemslot3
		{
			public int type { get; set; }
			public int maxCount { get; set; }
			public bool isInfinite { get; set; }
			public object[] items { get; set; }
		}

		public class Lockslot3
		{
			public int type { get; set; }
			public int maxCount { get; set; }
			public bool isInfinite { get; set; }
			public object[] items { get; set; }
		}

		public class Statsbylevel
		{
			public int offence { get; set; }
			public int defence { get; set; }
			public int spellPower { get; set; }
			public int intelligence { get; set; }
			public int luck { get; set; }
			public int moral { get; set; }
			public int movementBonus { get; set; }
		}

		public class Additionalstats1
		{
			public int offence { get; set; }
			public int defence { get; set; }
			public int spellPower { get; set; }
			public int intelligence { get; set; }
			public int luck { get; set; }
			public int moral { get; set; }
			public int statsNum { get; set; }
			public int viewRadius { get; set; }
			public int slowestUnitSpeed { get; set; }
			public int offencePer { get; set; }
			public int defencePer { get; set; }
			public int spellPowerPer { get; set; }
			public int spellPowerFinal { get; set; }
			public int intelligencePer { get; set; }
			public int movementBonus { get; set; }
			public int movementRestoreBonus { get; set; }
			public int movementPerBonus { get; set; }
			public int movementAfterBattlePerBonus { get; set; }
			public int movementAfterBattleBonus { get; set; }
			public int roadPerBonus { get; set; }
			public int landscapePenaltyPerBonus { get; set; }
			public int flyMotionPerBonus { get; set; }
			public bool flyMotion { get; set; }
			public int moveRestoreEnergyBonus { get; set; }
			public bool disableMagicBook { get; set; }
			public bool enableMagicExchange { get; set; }
			public bool enableMagicStealing { get; set; }
			public bool enableNecromancy { get; set; }
			public bool enableNecromancyFactionBonus { get; set; }
			public bool enableNecromancyManaRestoreBonus { get; set; }
			public bool enableNecromancyLevelBonus { get; set; }
			public bool enableDiplomacy { get; set; }
			public bool enableBattleEscapeBan { get; set; }
			public bool enableBansEvasion { get; set; }
			public bool enableBansEvasionBattle { get; set; }
			public bool enableMarketsCounting { get; set; }
			public bool enableSquadReactionType { get; set; }
			public bool enableSquadCounts { get; set; }
			public bool enableEnemyHeroInfo { get; set; }
			public bool enableEnemyCityInfo { get; set; }
			public bool enableDisguise { get; set; }
			public bool enableBattleOnNativeBiome { get; set; }
			public bool enableHeroNativeBiome { get; set; }
			public bool enableTactics { get; set; }
			public bool enableEnemyVisionInTactics { get; set; }
			public bool banTactics { get; set; }
			public bool enableSavePartyByEscape { get; set; }
			public bool enableSavePartyByEscapeNeutral { get; set; }
			public bool enableSaveHeroByKill { get; set; }
			public bool enableImmuneDebufInMap { get; set; }
			public bool enableSilence { get; set; }
			public bool magicCrits { get; set; }
			public bool immuneToDebuffs { get; set; }
			public bool banHeroAbilities { get; set; }
			public bool disableSameMagicCounterRefresh { get; set; }
			public int necromancyPerBonus { get; set; }
			public int diplomacyEfficiencyPerBonus { get; set; }
			public int diplomacySumValuePerBonus { get; set; }
			public int diplomacyFractionPerBonus { get; set; }
			public int diplomacyCostPerBonus { get; set; }
			public int diplomacyUnitsCountBonus { get; set; }
			public int capitulationCostPerBonus { get; set; }
			public int expPerBonus { get; set; }
			public int sideExpPerBonus { get; set; }
			public bool ignoreFinalDamageBonus { get; set; }
			public bool ignoreFinalHealingBonus { get; set; }
			public bool ignoreFinalSummonBonus { get; set; }
			public int finalDamageBonusPercent { get; set; }
			public int finalHealingBonusPercent { get; set; }
			public int finalManaCostBonusPercent { get; set; }
			public int finalSummonBonusPercent { get; set; }
			public bool ignoreSchoolCastsLimit { get; set; }
			public bool ignoreSpellCastsLimit { get; set; }
			public int minAllowedMagicRank { get; set; }
			public int maxAllowedMagicRank { get; set; }
			public int sameMagicCastsPerRound { get; set; }
			public int sameSchoolCastsPerRound { get; set; }
			public int magicCastsPerRound { get; set; }
			public int magicOverloadsPerRound { get; set; }
			public int magicOverloadPercent { get; set; }
			public int magicUsageLimitBonus { get; set; }
			public int magicAttackPerBonus { get; set; }
			public int crit { get; set; }
			public int anticrit { get; set; }
			public int manaBonus { get; set; }
			public int manaBonusPercent { get; set; }
			public int manaCostBonus { get; set; }
			public int manaCostBonusPercent { get; set; }
			public int manaRestoreBonus { get; set; }
			public int manaRestoreBonusPercent { get; set; }
			public int energyLevelsCountBonus { get; set; }
			public int energyPerLevelDiscount { get; set; }
			public int startEnergyBonus { get; set; }
			public int startEnergyLevelsBonus { get; set; }
			public int energyPerRoundBonus { get; set; }
			public int energyLevelsPerRoundBonus { get; set; }
			public int maxEnergyLevelsBonus { get; set; }
			public int outComingGlobalBuffDuration { get; set; }
			public int outComingBuffDuration { get; set; }
			public int outComingDebuffDuration { get; set; }
			public int obstacleHpBonus { get; set; }
			public int karaDurationBonus { get; set; }
			public int tacticsPlacementSize { get; set; }
			public Spellpowerschoolset spellPowerSchoolSet { get; set; }
			public Spellpowersidset spellPowerSidSet { get; set; }
			public Magicschoolset1 magicSchoolSet { get; set; }
			public Magicsidset1 magicSidSet { get; set; }
			public Magiccostschoolset magicCostSchoolSet { get; set; }
			public Magiccostsidset magicCostSidSet { get; set; }
			public Energyvaluesset energyValuesSet { get; set; }
			public Energyenablesset energyEnablesSet { get; set; }
			public Magiccounterset magicCounterSet { get; set; }
			public Outdmgmultipliersset outDmgMultipliersSet { get; set; }
			public Herorespercentset heroResPercentSet { get; set; }
		}

		public class Spellpowerschoolset
		{
			public Statsbyschool1 statsBySchool { get; set; }
		}

		public class Statsbyschool1
		{
			public Datum3[] data { get; set; }
		}

		public class Datum3
		{
			public int key { get; set; }
			public Val2 val { get; set; }
		}

		public class Val2
		{
			public int school { get; set; }
			public int bonus { get; set; }
		}

		public class Spellpowersidset
		{
			public Statsbysid statsBySid { get; set; }
		}

		public class Statsbysid
		{
			public object[] data { get; set; }
		}

		public class Magicschoolset1
		{
			public Statsbyschool2[] statsBySchool { get; set; }
		}

		public class Statsbyschool2
		{
			public int school { get; set; }
			public int maxAvailableRank { get; set; }
			public int levelBonus { get; set; }
		}

		public class Magicsidset1
		{
			public object[] statsList { get; set; }
		}

		public class Magiccostschoolset
		{
			public Statsbyschool3[] statsBySchool { get; set; }
		}

		public class Statsbyschool3
		{
			public int school { get; set; }
			public int costBonus { get; set; }
			public int costPerBonus { get; set; }
		}

		public class Magiccostsidset
		{
			public Statsbysid1 statsBySid { get; set; }
		}

		public class Statsbysid1
		{
			public object[] data { get; set; }
		}

		public class Energyvaluesset
		{
			public Statslist[] statsList { get; set; }
		}

		public class Statslist
		{
			public int typeEnergy { get; set; }
			public int powerRecovery { get; set; }
			public int maxValue { get; set; }
		}

		public class Energyenablesset
		{
			public Statslist1[] statsList { get; set; }
		}

		public class Statslist1
		{
			public int typeEnergy { get; set; }
			public bool isEnable { get; set; }
		}

		public class Magiccounterset
		{
		}

		public class Outdmgmultipliersset
		{
			public object[] list { get; set; }
		}

		public class Herorespercentset
		{
			public Statsdict statsDict { get; set; }
		}

		public class Statsdict
		{
			public object[] data { get; set; }
		}

		public class Skills
		{
			public List2[] list { get; set; }
		}

		public class List2
		{
			public string sid { get; set; }
			public int level { get; set; }
			public bool wasApplied { get; set; }
			public Subskill[] subSkills { get; set; }
		}

		public class Subskill
		{
			public string sid { get; set; }
			public int level { get; set; }
			public int status { get; set; }
			public bool wasApplied { get; set; }
		}

		public class Buffs1
		{
			public object[] list { get; set; }
		}

		public class Magics
		{
			public List3[] list { get; set; }
		}

		public class List3
		{
			public string sidConfig { get; set; }
			public int level { get; set; }
			public bool isLearned { get; set; }
			public int usageCounter { get; set; }
		}

		public class Aidata1
		{
			public bool wentOnThisDay { get; set; }
			public bool targetForCourier { get; set; }
			public Objectpergame1 objectPerGame { get; set; }
			public Objectperweek1 objectPerWeek { get; set; }
		}

		public class Objectpergame1
		{
			public object[] data { get; set; }
		}

		public class Objectperweek1
		{
			public object[] data { get; set; }
		}

		public class Leveluppool
		{
			public List4[] list { get; set; }
			public int heroLevelUpSubSkillMode { get; set; }
			public bool applySkillReplace { get; set; }
			public int newSkillLevel { get; set; }
			public int statsNumBonus { get; set; }
			public int freeId { get; set; }
		}

		public class List4
		{
			public Skillstage skillStage { get; set; }
			public Subskillstage subSkillStage { get; set; }
			public Alternativesubskillstage alternativeSubSkillStage { get; set; }
			public bool canRefreshNextLevelUps { get; set; }
			public bool refreshAll { get; set; }
			public bool canActivateNextLevelUp { get; set; }
			public int id { get; set; }
		}

		public class Skillstage
		{
			public int levelUpId { get; set; }
			public bool isActive { get; set; }
			public Skillspack skillsPack { get; set; }
			public int heroLevel { get; set; }
			public object[] stats { get; set; }
			public string skillSid { get; set; }
			public bool applySkillReplace { get; set; }
			public int newSkillLevel { get; set; }
			public int statsNumBonus { get; set; }
		}

		public class Skillspack
		{
			public object[] skillSids { get; set; }
		}

		public class Subskillstage
		{
			public int levelUpId { get; set; }
			public bool isActive { get; set; }
			public string skillSid { get; set; }
			public int skillLevel { get; set; }
			public string subSkillSid { get; set; }
		}

		public class Alternativesubskillstage
		{
			public int levelUpId { get; set; }
			public bool isActive { get; set; }
			public string skillSid { get; set; }
			public int skillLevel { get; set; }
			public object[] subSkillsSids { get; set; }
		}

		public class Specialization
		{
			public string sid { get; set; }
		}

		public class Subclasses
		{
			public List5[] list { get; set; }
		}

		public class List5
		{
			public string sid { get; set; }
			public bool active { get; set; }
		}

		public class Pickedbonuses
		{
			public object[] bonuses { get; set; }
		}

		public class Dataenergy
		{
			public int typeEnergy { get; set; }
			public int value { get; set; }
		}

		public class Squads
		{
			public List6[] list { get; set; }
			public int freeId { get; set; }
		}

		public class List6
		{
			public string configSid { get; set; }
			public int id { get; set; }
			public int node { get; set; }
			public Unit4[] units { get; set; }
			public Property8[] properties { get; set; }
			public bool mainSquad { get; set; }
			public int reactionType { get; set; }
			public float weeklyIncrementBonus { get; set; }
			public float diplomacyUnitsCountBonus { get; set; }
			public int startValue { get; set; }
			public bool released { get; set; }
			public bool isNPC { get; set; }
			public bool isEscape { get; set; }
			public bool isFreeDiplomacy { get; set; }
			public bool isCampaignFreeDiplomacy { get; set; }
			public bool isCampaingDiplomacy { get; set; }
			public bool isAutobattle { get; set; }
			public bool isIgnoreMultiply { get; set; }
			public string obstruction { get; set; }
			public int customStacks { get; set; }
			public string customTopUnit { get; set; }
		}

		public class Unit4
		{
			public string sid { get; set; }
			public int amount { get; set; }
		}

		public class Property8
		{
			public int id { get; set; }
			public bool active { get; set; }
			public int dataId { get; set; }
		}

		public class Areas
		{
		}

		public class Items
		{
			public object[] list { get; set; }
			public int freeId { get; set; }
		}

		public class Buffs2
		{
			public object[] list { get; set; }
		}

		public class Weeks
		{
			public Allweek[] allWeeks { get; set; }
			public Allmonth[] allMonths { get; set; }
			public object[] waitingToReturnWeeks { get; set; }
			public object[] waitingToReturnMonths { get; set; }
			public string currentWeekSid { get; set; }
			public bool isMonthWeek { get; set; }
			public bool enabled { get; set; }
		}

		public class Allweek
		{
			public string sid { get; set; }
			public int rollChance { get; set; }
			public bool isMonth { get; set; }
		}

		public class Allmonth
		{
			public string sid { get; set; }
			public int rollChance { get; set; }
			public bool isMonth { get; set; }
		}

		public class Weather
		{
			public int index { get; set; }
		}

		public class Turnmode
		{
			public int turnPhase { get; set; }
			public int turnMode { get; set; }
			public bool canEndRealtimeOnDay { get; set; }
			public int realtimeEndDay { get; set; }
			public object[] sidesQueue { get; set; }
			public int currentSideIndex { get; set; }
			public int nextMode { get; set; }
		}

		public class Winconditionsdata
		{
			public Array1[] array { get; set; }
		}

		public class Array1
		{
			public Mapwincondition mapWinCondition { get; set; }
			public int?[] countDayDesertion { get; set; }
			public int?[] countDayHighlightSide { get; set; }
			public object[] countDayLostStartCity { get; set; }
			public int countDayGladiatorArena { get; set; }
			public int countDayDelayStart { get; set; }
			public object[] idHeroesGladiatorArena { get; set; }
			public int nodeGladiatorArena { get; set; }
			public bool[] isNotification { get; set; }
			public bool?[] isWasNotificationDesertionOrHeroLight { get; set; }
			public object[] idCitiesHold { get; set; }
			public object[] daysCitiesHold { get; set; }
			public object[] pointsTournament { get; set; }
			public object[] winnerSides { get; set; }
			public int currentStageTournament { get; set; }
			public bool isStartCountingDays { get; set; }
		}

		public class Mapwincondition
		{
			public int typeWinCondition { get; set; }
			public int valueDesertion { get; set; }
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

		public class Mapbonuses
		{
			public object[] list { get; set; }
		}

		public class Randomitemspool
		{
		}

		public class Randommagicspool
		{
		}

		public class Randomskillspool
		{
		}

		public class Timetracerdata
		{
			public float secPassed { get; set; }
		}

		public class Propertiesactions
		{
			public object[] list_ { get; set; }
		}

		public class Startinfo
		{
			public int play { get; set; }
			public int load { get; set; }
			public string fileHashSum { get; set; }
			public bool isQuickGame { get; set; }
			public int[] mySides { get; set; }
			public Side[] sides { get; set; }
			public object[] pickGameBannedHeroes { get; set; }
			public object[] sidesWithoutTimer { get; set; }
			public int restartUsageCount { get; set; }
			public Settings settings { get; set; }
			public Campaigninfo campaignInfo { get; set; }
			public Initialstartdatetime initialStartDateTime { get; set; }
		}

		public class Settings
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

		public class Campaigninfo
		{
			public bool isEmpty_ { get; set; }
			public string mapSid_ { get; set; }
			public string missionTitleSid_ { get; set; }
			public string missionDescriptionSid_ { get; set; }
			public Storyhubsave_ storyHubSave_ { get; set; }
			public Storyhubsavebeforestartmission_ storyHubSaveBeforeStartMission_ { get; set; }
			public Campaigndifficulty_ campaignDifficulty_ { get; set; }
			public object[] campaignBannedMagics { get; set; }
			public bool transferHeroProgressFromSession_ { get; set; }
			public bool disableFactionLaws { get; set; }
			public bool disableMagicGuild { get; set; }
			public object[] idSidesWithoutTimer { get; set; }
		}

		public class Storyhubsave_
		{
			public bool isEmpty { get; set; }
			public Storyhubdata storyHubData { get; set; }
			public Savingdatetime savingDateTime { get; set; }
			public object[] counters { get; set; }
			public Items1 items { get; set; }
			public Nodessaves nodesSaves { get; set; }
			public Heroessaves heroesSaves { get; set; }
			public Actsdata actsData { get; set; }
			public string gameVersion { get; set; }
		}

		public class Storyhubdata
		{
			public bool wonInLastMission { get; set; }
			public bool lastNodeDoneActionsInvoked { get; set; }
			public string lastInteractedNodeSid { get; set; }
			public int currentDifficultyIndex { get; set; }
			public string hubDescriptionSid { get; set; }
			public Activeprofile activeProfile { get; set; }
			public int seed { get; set; }
		}

		public class Activeprofile
		{
			public int id { get; set; }
			public string campaignSid { get; set; }
			public string name { get; set; }
			public int timeSpentInSeconds { get; set; }
			public int completedMissionsCount { get; set; }
			public Lastsavetime lastSaveTime { get; set; }
		}

		public class Lastsavetime
		{
			public int value { get; set; }
		}

		public class Savingdatetime
		{
			public int value { get; set; }
		}

		public class Items1
		{
			public object[] list { get; set; }
			public int freeId { get; set; }
		}

		public class Nodessaves
		{
			public object[] data { get; set; }
		}

		public class Heroessaves
		{
			public object[] data { get; set; }
		}

		public class Actsdata
		{
			public object[] data { get; set; }
		}

		public class Storyhubsavebeforestartmission_
		{
			public bool isEmpty { get; set; }
			public Storyhubdata1 storyHubData { get; set; }
			public Savingdatetime1 savingDateTime { get; set; }
			public object[] counters { get; set; }
			public Items2 items { get; set; }
			public Nodessaves1 nodesSaves { get; set; }
			public Heroessaves1 heroesSaves { get; set; }
			public Actsdata1 actsData { get; set; }
			public string gameVersion { get; set; }
		}

		public class Storyhubdata1
		{
			public bool wonInLastMission { get; set; }
			public bool lastNodeDoneActionsInvoked { get; set; }
			public string lastInteractedNodeSid { get; set; }
			public int currentDifficultyIndex { get; set; }
			public string hubDescriptionSid { get; set; }
			public Activeprofile1 activeProfile { get; set; }
			public int seed { get; set; }
		}

		public class Activeprofile1
		{
			public int id { get; set; }
			public string campaignSid { get; set; }
			public string name { get; set; }
			public int timeSpentInSeconds { get; set; }
			public int completedMissionsCount { get; set; }
			public Lastsavetime1 lastSaveTime { get; set; }
		}

		public class Lastsavetime1
		{
			public int value { get; set; }
		}

		public class Savingdatetime1
		{
			public int value { get; set; }
		}

		public class Items2
		{
			public object[] list { get; set; }
			public int freeId { get; set; }
		}

		public class Nodessaves1
		{
			public object[] data { get; set; }
		}

		public class Heroessaves1
		{
			public object[] data { get; set; }
		}

		public class Actsdata1
		{
			public object[] data { get; set; }
		}

		public class Campaigndifficulty_
		{
			public int index { get; set; }
			public string sid { get; set; }
			public string nameSid { get; set; }
			public string descriptionSid { get; set; }
			public Economic economic { get; set; }
			public int neutralPowerMultiplier { get; set; }
			public int neutralExpMultiplier { get; set; }
			public int guardPowerMultiplier { get; set; }
			public object[] heroesArmies { get; set; }
			public Ai ai { get; set; }
		}

		public class Economic
		{
			public string name { get; set; }
			public Playerstartresources playerStartResources { get; set; }
			public Aistartresources aiStartResources { get; set; }
			public int coefFractionLawPlayer { get; set; }
			public int coefFractionLawAI { get; set; }
		}

		public class Playerstartresources
		{
			public int gold { get; set; }
			public int wood { get; set; }
			public int ore { get; set; }
			public int gemstones { get; set; }
			public int crystals { get; set; }
			public int mercury { get; set; }
			public int alchemicalDust { get; set; }
		}

		public class Aistartresources
		{
			public int gold { get; set; }
			public int wood { get; set; }
			public int ore { get; set; }
			public int gemstones { get; set; }
			public int crystals { get; set; }
			public int mercury { get; set; }
			public int alchemicalDust { get; set; }
		}

		public class Ai
		{
			public string name { get; set; }
			public string script { get; set; }
			public string battleScript { get; set; }
			public int resourceAddPercent { get; set; }
			public int tempStacksMultiplier { get; set; }
			public int heroCountMax { get; set; }
			public int heroCountIncrement { get; set; }
			public int heroMaxHirePerDay { get; set; }
			public int heroMaxHirePerDayIncrement { get; set; }
			public int heroCountMaxHard { get; set; }
			public int valuesVsMobsMultiplier { get; set; }
			public int blockAreaByEnemyMultiplier { get; set; }
			public string buildTag { get; set; }
			public int manaPerDay { get; set; }
		}

		public class Initialstartdatetime
		{
			public long value { get; set; }
		}

		public class Side
		{
			public string name { get; set; }
			public int eType { get; set; }
			public string fractionSid { get; set; }
			public bool isFractionRandom { get; set; }
			public string heroSid { get; set; }
			public bool isHeroRandom { get; set; }
			public int colorId { get; set; }
			public int spawnId { get; set; }
			public Iconplayer iconPlayer { get; set; }
			public int restartPoints { get; set; }
			public object[] campaignSpawns { get; set; }
		}

		public class Iconplayer
		{
			public int m_FileID { get; set; }
			public int m_PathID { get; set; }
		}

		public class Restartinfo
		{
			public int play { get; set; }
			public int load { get; set; }
			public string fileHashSum { get; set; }
			public bool isQuickGame { get; set; }
			public int[] mySides { get; set; }
			public Side1[] sides { get; set; }
			public object[] pickGameBannedHeroes { get; set; }
			public object[] sidesWithoutTimer { get; set; }
			public int restartUsageCount { get; set; }
			public Settings1 settings { get; set; }
			public Campaigninfo1 campaignInfo { get; set; }
			public Initialstartdatetime1 initialStartDateTime { get; set; }
		}

		public class Settings1
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
			public Sidetimersettings1 sideTimerSettings { get; set; }
			public bool onlyAdminSave { get; set; }
			public int endRealtimeWeek { get; set; }
			public int endRealtimeDay { get; set; }
			public bool weekEffectEnabled { get; set; }
		}

		public class Sidetimersettings1
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

		public class Campaigninfo1
		{
			public bool isEmpty_ { get; set; }
			public string mapSid_ { get; set; }
			public string missionTitleSid_ { get; set; }
			public string missionDescriptionSid_ { get; set; }
			public Storyhubsave_1 storyHubSave_ { get; set; }
			public Storyhubsavebeforestartmission_1 storyHubSaveBeforeStartMission_ { get; set; }
			public Campaigndifficulty_1 campaignDifficulty_ { get; set; }
			public object[] campaignBannedMagics { get; set; }
			public bool transferHeroProgressFromSession_ { get; set; }
			public bool disableFactionLaws { get; set; }
			public bool disableMagicGuild { get; set; }
			public object[] idSidesWithoutTimer { get; set; }
		}

		public class Storyhubsave_1
		{
			public bool isEmpty { get; set; }
			public Storyhubdata2 storyHubData { get; set; }
			public Savingdatetime2 savingDateTime { get; set; }
			public object[] counters { get; set; }
			public Items3 items { get; set; }
			public Nodessaves2 nodesSaves { get; set; }
			public Heroessaves2 heroesSaves { get; set; }
			public Actsdata2 actsData { get; set; }
			public string gameVersion { get; set; }
		}

		public class Storyhubdata2
		{
			public bool wonInLastMission { get; set; }
			public bool lastNodeDoneActionsInvoked { get; set; }
			public string lastInteractedNodeSid { get; set; }
			public int currentDifficultyIndex { get; set; }
			public string hubDescriptionSid { get; set; }
			public Activeprofile2 activeProfile { get; set; }
			public int seed { get; set; }
		}

		public class Activeprofile2
		{
			public int id { get; set; }
			public string campaignSid { get; set; }
			public string name { get; set; }
			public int timeSpentInSeconds { get; set; }
			public int completedMissionsCount { get; set; }
			public Lastsavetime2 lastSaveTime { get; set; }
		}

		public class Lastsavetime2
		{
			public int value { get; set; }
		}

		public class Savingdatetime2
		{
			public int value { get; set; }
		}

		public class Items3
		{
			public object[] list { get; set; }
			public int freeId { get; set; }
		}

		public class Nodessaves2
		{
			public object[] data { get; set; }
		}

		public class Heroessaves2
		{
			public object[] data { get; set; }
		}

		public class Actsdata2
		{
			public object[] data { get; set; }
		}

		public class Storyhubsavebeforestartmission_1
		{
			public bool isEmpty { get; set; }
			public Storyhubdata3 storyHubData { get; set; }
			public Savingdatetime3 savingDateTime { get; set; }
			public object[] counters { get; set; }
			public Items4 items { get; set; }
			public Nodessaves3 nodesSaves { get; set; }
			public Heroessaves3 heroesSaves { get; set; }
			public Actsdata3 actsData { get; set; }
			public string gameVersion { get; set; }
		}

		public class Storyhubdata3
		{
			public bool wonInLastMission { get; set; }
			public bool lastNodeDoneActionsInvoked { get; set; }
			public string lastInteractedNodeSid { get; set; }
			public int currentDifficultyIndex { get; set; }
			public string hubDescriptionSid { get; set; }
			public Activeprofile3 activeProfile { get; set; }
			public int seed { get; set; }
		}

		public class Activeprofile3
		{
			public int id { get; set; }
			public string campaignSid { get; set; }
			public string name { get; set; }
			public int timeSpentInSeconds { get; set; }
			public int completedMissionsCount { get; set; }
			public Lastsavetime3 lastSaveTime { get; set; }
		}

		public class Lastsavetime3
		{
			public int value { get; set; }
		}

		public class Savingdatetime3
		{
			public int value { get; set; }
		}

		public class Items4
		{
			public object[] list { get; set; }
			public int freeId { get; set; }
		}

		public class Nodessaves3
		{
			public object[] data { get; set; }
		}

		public class Heroessaves3
		{
			public object[] data { get; set; }
		}

		public class Actsdata3
		{
			public object[] data { get; set; }
		}

		public class Campaigndifficulty_1
		{
			public int index { get; set; }
			public string sid { get; set; }
			public string nameSid { get; set; }
			public string descriptionSid { get; set; }
			public Economic1 economic { get; set; }
			public int neutralPowerMultiplier { get; set; }
			public int neutralExpMultiplier { get; set; }
			public int guardPowerMultiplier { get; set; }
			public object[] heroesArmies { get; set; }
			public Ai1 ai { get; set; }
		}

		public class Economic1
		{
			public string name { get; set; }
			public Playerstartresources1 playerStartResources { get; set; }
			public Aistartresources1 aiStartResources { get; set; }
			public int coefFractionLawPlayer { get; set; }
			public int coefFractionLawAI { get; set; }
		}

		public class Playerstartresources1
		{
			public int gold { get; set; }
			public int wood { get; set; }
			public int ore { get; set; }
			public int gemstones { get; set; }
			public int crystals { get; set; }
			public int mercury { get; set; }
			public int alchemicalDust { get; set; }
		}

		public class Aistartresources1
		{
			public int gold { get; set; }
			public int wood { get; set; }
			public int ore { get; set; }
			public int gemstones { get; set; }
			public int crystals { get; set; }
			public int mercury { get; set; }
			public int alchemicalDust { get; set; }
		}

		public class Ai1
		{
			public string name { get; set; }
			public string script { get; set; }
			public string battleScript { get; set; }
			public int resourceAddPercent { get; set; }
			public int tempStacksMultiplier { get; set; }
			public int heroCountMax { get; set; }
			public int heroCountIncrement { get; set; }
			public int heroMaxHirePerDay { get; set; }
			public int heroMaxHirePerDayIncrement { get; set; }
			public int heroCountMaxHard { get; set; }
			public int valuesVsMobsMultiplier { get; set; }
			public int blockAreaByEnemyMultiplier { get; set; }
			public string buildTag { get; set; }
			public int manaPerDay { get; set; }
		}

		public class Initialstartdatetime1
		{
			public long value { get; set; }
		}

		public class Side1
		{
			public string name { get; set; }
			public int eType { get; set; }
			public string fractionSid { get; set; }
			public bool isFractionRandom { get; set; }
			public string heroSid { get; set; }
			public bool isHeroRandom { get; set; }
			public int colorId { get; set; }
			public int spawnId { get; set; }
			public Iconplayer1 iconPlayer { get; set; }
			public int restartPoints { get; set; }
			public object[] campaignSpawns { get; set; }
		}

		public class Iconplayer1
		{
			public int m_FileID { get; set; }
			public int m_PathID { get; set; }
		}

	}
}
