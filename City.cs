using HeroesOE.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HeroesOE.Json.DungeonCityJson;
using static HeroesOE.Json.HumanCityJson;
using static HeroesOE.Json.UndeadCityJson;
using static HeroesOE.Json.UnfrozenCityJson;
using static HeroesOE.Json.UnitsLogicJson;
using static HeroesOE.VGlobals;

namespace HeroesOE
{
	public class CityJsonBase
	{
		public CityTokenBase[] tokens;
	}

	public class CityTokenBase
	{
		// all factions
		public string id { get; set; }
		public string sceneName { get; set; }
		public string fraction { get; set; }
		public int goodsValue { get; set; }
		public int viewRadius { get; set; }
		public Main[] mains { get; set; }
		public Tavern[] taverns { get; set; }
		public Market[] markets { get; set; }
		public Hire[] hires { get; set; }
		public Magicguild[] magicGuilds { get; set; }
		public Bank[] banks { get; set; }
		public Wall[] walls { get; set; }
		public Buildorder[] buildOrders { get; set; }
		// dungeon, unfrozen
		public Herobonusbank[] heroBonusBanks { get; }
		// human, dungeon, unfrozen
		public Artifactmarket[] artifactMarkets { get; }
		// human only
		public Intelligence[] intelligences { get; }
		public Trainingrange[] trainingRanges { get; }
		// dungeon only
		public Artifactchanger[] artifactChangers { get; }
		// undead only
		public Manafountain[] manaFountains { get; }
		public Unitsconverter[] unitsConverters { get; }
		// unfrozen only
		public Portalsummoning[] portalSummonings { get; }
	}

	public class City
	{
		public City(CityJsonBase city_base)
		{
			this.city_base = city_base;
			if (city_base is DungeonCityJson)
			{
				name = "dungeon";
				faction = HeroesOE.Faction.Dungeon;
				dungeon_city = new DungeonCity();
				city_base.tokens = dungeon_city.tokens;
				units = ParseHires(city_base.tokens[0].hires);
			}
			else if (city_base is HumanCityJson)
			{
				name = "human";
				faction = HeroesOE.Faction.Human;
				human_city = new HumanCity();
				city_base.tokens = human_city.tokens;
				units = ParseHires(city_base.tokens[0].hires);
			}
			else if (city_base is UndeadCityJson)
			{
				name = "undead";
				faction = HeroesOE.Faction.Undead;
				undead_city = new UndeadCity();
				city_base.tokens = undead_city.tokens;
				units = ParseHires(city_base.tokens[0].hires);
			}
			else if (city_base is UnfrozenCityJson)
			{
				name = "unfrozen";
				faction = HeroesOE.Faction.Unfrozen;
				unfrozen_city = new UnfrozenCity();
				city_base.tokens = unfrozen_city.tokens;
				units = ParseHires(city_base.tokens[0].hires);
			}
		}

		public UnitsLogic[] ParseHires(Hire[] hires)
		{
			// TODO: finish parsehires
			List<UnitsLogic> units = new List<UnitsLogic>();

			foreach (Hire hire in hires)
			{
				var sids = hire.unitsHire.units[0].sids;
				foreach (var sid in sids)
				{
					// TODO: get name from UnitsAbility
					UnitsLogic ul = new UnitsLogic(sid, hire.unitsHire);
					//ul.unit_name = UnitsLogic.units_ability.units[sid];
					VCity($"{ul.unit_name:40}: {ul.GetStatsCsv(ul.units_hire.units[0].weeklyIncrement)}");
					units.Add(ul);
				}
			}

			return units.ToArray();
		}

		public string name;
		public HeroesOE.Faction faction;
		public CityJsonBase city_base;
		public HumanCity human_city;
		public DungeonCity dungeon_city;
		public UndeadCity undead_city;
		public UnfrozenCity unfrozen_city;

		public UnitsLogic[] units;
		public SaveGameJson1.Object map_object;	// read from sg1
	}

	public class Building
	{
		public Parametersperlevel[] parametersPerLevel { get; set; }
	}
	public class Artifact
	{
		public string sidPrev { get; set; }
		public string sidNew { get; set; }
		public Resarr[] resArr { get; set; }
	}
	public class Artifactchanger : Building
	{
		public string sid { get; set; }
		public bool isConstructedOnStart { get; set; }
		public int levelOnStart { get; set; }
		public string sceneSlot { get; set; }
		public string[] icons { get; set; }
		public string[] names { get; set; }
		public string[] descriptions { get; set; }
		public string[] narrativeDescriptions { get; set; }
		public string[] backgroundImages { get; set; }
		public Artifact[] artifacts { get; set; }
	}
	public class Artifactmarket : Building
	{
		public string sid { get; set; }
		public bool isConstructedOnStart { get; set; }
		public int levelOnStart { get; set; }
		public string sceneSlot { get; set; }
		public string[] icons { get; set; }
		public string[] names { get; set; }
		public string[] descriptions { get; set; }
		public string[] narrativeDescriptions { get; set; }
		public string[] backgroundImages { get; set; }
		public float extraChargePurchase { get; set; }
		public float extraChargeSell { get; set; }
		public int[] itemsCountPerRarity { get; set; }
	}
	public class Bank : Building
	{
		public string sid { get; set; }
		public bool isConstructedOnStart { get; set; }
		public int levelOnStart { get; set; }
		public string sceneSlot { get; set; }
		public string[] icons { get; set; }
		public string[] names { get; set; }
		public string[] descriptions { get; set; }
		public string[] narrativeDescriptions { get; set; }
		public string[] backgroundImages { get; set; }
		public Bonus[] bonuses { get; set; }
	}
	public class Bonus
	{
		public string type { get; set; }
		public object[] parameters { get; set; }
	}
	public class Bonusesperlevel
	{
		public Bonus[] bonuses { get; set; }
	}
	public class Buildorder
	{
		public string buildTag { get; set; }
		public int chance { get; set; }
		public Order[] order { get; set; }
	}
	public class Citybonus
	{
		// TODO: fix cityBonuses cannot convert Number to string line 1436 col 26
		//[System.Text.Json.Serialization.JsonPropertyName("type")]
		public string type { get; set; }
		public string[] parameters { get; set; }
	}
	public class Citybonus2
	{
		// TODO: fix cityBonuses cannot convert Number to string line 1436 col 26
		//[System.Text.Json.Serialization.JsonPropertyName("type")]
		public string type { get; set; }
		public int[] parameters { get; set; }
	}
	public class Conversionpair
	{
		public int tier { get; set; }
		public string sid { get; set; }
	}
	public class Cost
	{
		public string resName { get; set; }
		public int value { get; set; }
	}
	public class Effectsperlevel
	{
		public string[] list { get; set; }
	}
	public class Graal : Building
	{
		public string sid { get; set; }
		public bool isConstructedOnStart { get; set; }
		public int levelOnStart { get; set; }
		public string sceneSlot { get; set; }
		public string[] icons { get; set; }
		public string[] names { get; set; }
		public string[] descriptions { get; set; }
		public string[] narrativeDescriptions { get; set; }
		public string[] backgroundImages { get; set; }
		public string graalType { get; set; }
		public object[] sideBonuses { get; set; }
		public Citybonus[] cityBonuses { get; set; }
	}
	public class Graal2 : Building
	{
		public string sid { get; set; }
		public bool isConstructedOnStart { get; set; }
		public int levelOnStart { get; set; }
		public string sceneSlot { get; set; }
		public string[] icons { get; set; }
		public string[] names { get; set; }
		public string[] descriptions { get; set; }
		public string[] narrativeDescriptions { get; set; }
		public string[] backgroundImages { get; set; }
		public string graalType { get; set; }
		public object[] sideBonuses { get; set; }
		public Citybonus2[] cityBonuses { get; set; }
	}
	public class Hire : Building
	{
		public string sid { get; set; }
		public bool isConstructedOnStart { get; set; }
		public int levelOnStart { get; set; }
		public string sceneSlot { get; set; }
		public string[] icons { get; set; }
		public string[] names { get; set; }
		public string[] descriptions { get; set; }
		public string[] narrativeDescriptions { get; set; }
		public string[] backgroundImages { get; set; }
		public Unitshire unitsHire { get; set; }
	}
	public class Herobonusbank : Building
	{
		public string sid { get; set; }
		public bool isConstructedOnStart { get; set; }
		public int levelOnStart { get; set; }
		public string sceneSlot { get; set; }
		public string[] icons { get; set; }
		public string[] names { get; set; }
		public string[] descriptions { get; set; }
		public string[] narrativeDescriptions { get; set; }
		public string[] backgroundImages { get; set; }
		public Bonus[] bonuses { get; set; }
	}
	public class Intelligence : Building
	{
		public string sid { get; set; }
		public bool isConstructedOnStart { get; set; }
		public int levelOnStart { get; set; }
		public string sceneSlot { get; set; }
		public string[] icons { get; set; }
		public string[] names { get; set; }
		public string[] descriptions { get; set; }
		public string[] narrativeDescriptions { get; set; }
		public string[] backgroundImages { get; set; }
		public int viewRadius { get; set; }
	}
	public class Magicguild : Building
	{
		public string sid { get; set; }
		public bool isConstructedOnStart { get; set; }
		public int levelOnStart { get; set; }
		public string sceneSlot { get; set; }
		public string[] icons { get; set; }
		public string[] names { get; set; }
		public string[] descriptions { get; set; }
		public string[] narrativeDescriptions { get; set; }
		public string[] backgroundImages { get; set; }
		public Rollchance[] rollChances { get; set; }
	}
	public class Main : Building
	{
		public string sid { get; set; }
		public bool isConstructedOnStart { get; set; }
		public int levelOnStart { get; set; }
		public string sceneSlot { get; set; }
		public string[] icons { get; set; }
		public string[] names { get; set; }
		public string[] descriptions { get; set; }
		public string[] narrativeDescriptions { get; set; }
		public string[] backgroundImages { get; set; }
		public Bonusesperlevel[] bonusesPerLevel { get; set; }
	}
	public class Manafountain : Building
	{
		public string sid { get; set; }
		public bool isConstructedOnStart { get; set; }
		public int levelOnStart { get; set; }
		public string sceneSlot { get; set; }
		public string[] icons { get; set; }
		public string[] names { get; set; }
		public string[] descriptions { get; set; }
		public string[] narrativeDescriptions { get; set; }
		public string[] backgroundImages { get; set; }
	}
	public class Market : Building
	{
		public string sid { get; set; }
		public bool isConstructedOnStart { get; set; }
		public int levelOnStart { get; set; }
		public string sceneSlot { get; set; }
		public string[] icons { get; set; }
		public string[] names { get; set; }
		public string[] descriptions { get; set; }
		public string[] narrativeDescriptions { get; set; }
		public string[] backgroundImages { get; set; }
	}
	public class Nodepos
	{
		public int xPos { get; set; }
		public int yPos { get; set; }
	}
	public class Order
	{
		public string sid { get; set; }
		public int level { get; set; }
	}
	public class Parametersperlevel
	{
		public Prevbuilding[] prevBuildings { get; set; }
		public Nodepos nodePos { get; set; }
		public Cost[] costs { get; set; }
	}
	public class Portalsummoning : Building
	{
		public string sid { get; set; }
		public bool isConstructedOnStart { get; set; }
		public int levelOnStart { get; set; }
		public string sceneSlot { get; set; }
		public string[] icons { get; set; }
		public string[] names { get; set; }
		public string[] descriptions { get; set; }
		public string[] narrativeDescriptions { get; set; }
		public string[] backgroundImages { get; set; }
		public int numberPurchases { get; set; }
	}
	public class Prevbuilding
	{
		public string sid { get; set; }
		public int level { get; set; }
	}
	public class Resarr
	{
		public string name { get; set; }
		public int cost { get; set; }
	}
	public class Rollchance
	{
		public string sid { get; set; }
		public int chance { get; set; }
	}
	public class Sidebonus
	{
		[System.Text.Json.Serialization.JsonPropertyName("type")]
		public string bonus_type { get; set; }
		public string receiverAllegiance { get; set; }
		public string[] parameters { get; set; }
	}
	public class Tavern : Building
	{
		public string sid { get; set; }
		public bool isConstructedOnStart { get; set; }
		public int levelOnStart { get; set; }
		public string sceneSlot { get; set; }
		public string[] icons { get; set; }
		public string[] names { get; set; }
		public string[] descriptions { get; set; }
		public string[] narrativeDescriptions { get; set; }
		public string[] backgroundImages { get; set; }
	}
	public class Trainingrange : Building
	{
		public string sid { get; set; }
		public bool isConstructedOnStart { get; set; }
		public int levelOnStart { get; set; }
		public string sceneSlot { get; set; }
		public string[] icons { get; set; }
		public string[] names { get; set; }
		public string[] descriptions { get; set; }
		public string[] narrativeDescriptions { get; set; }
		public string[] backgroundImages { get; set; }
		public Trainingstat[] trainingStats { get; set; }
	}
	public class Trainingstat
	{
		public string name { get; set; }
		public int[] values { get; set; }
		public Cost[] costs { get; set; }
	}
	public class Unit
	{
		public string[] sids { get; set; }
		public int weeklyIncrement { get; set; }
	}
	public class Unitsconverter : Building
	{
		public string sid { get; set; }
		public bool isConstructedOnStart { get; set; }
		public int levelOnStart { get; set; }
		public string sceneSlot { get; set; }
		public string[] icons { get; set; }
		public string[] names { get; set; }
		public string[] descriptions { get; set; }
		public string[] narrativeDescriptions { get; set; }
		public string[] backgroundImages { get; set; }
		public Conversionpair[] conversionPairs { get; set; }
		public string[] bannedUnits { get; set; }
	}
	public class Unitshire
	{
		public Unit[] units { get; set; }
	}
	public class Wall : Building
	{
		public string sid { get; set; }
		public bool isConstructedOnStart { get; set; }
		public int levelOnStart { get; set; }
		public string sceneSlot { get; set; }
		public string[] icons { get; set; }
		public string[] names { get; set; }
		public string[] descriptions { get; set; }
		public string[] narrativeDescriptions { get; set; }
		public string[] backgroundImages { get; set; }
		public Bonusesperlevel[] bonusesPerLevel { get; set; }
		public Effectsperlevel[] effectsPerLevel { get; set; }
	}
}
