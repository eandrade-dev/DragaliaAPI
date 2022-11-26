using System.Text.Json.Serialization;
using DragaliaAPI.Shared.Definitions.Enums;

namespace DragaliaAPI.Shared.Definitions;

public record DataAdventurer(
    int IdLong,
    string FullName,
    int WeaponTypeId,
    int Rarity,
    int MaxLimitBreakCount,
    [property: JsonConverter(typeof(JsonStringEnumConverter))] UnitElement ElementalType,
    int MinHp3,
    int MinHp4,
    int MinHp5,
    int MaxHp,
    int AddMaxHp1,
    int PlusHp0,
    int PlusHp1,
    int PlusHp2,
    int PlusHp3,
    int PlusHp4,
    int PlusHp5,
    int McFullBonusHp5,
    int MinAtk3,
    int MinAtk4,
    int MinAtk5,
    int MaxAtk,
    int AddMaxAtk1,
    int PlusAtk0,
    int PlusAtk1,
    int PlusAtk2,
    int PlusAtk3,
    int PlusAtk4,
    int PlusAtk5,
    int McFullBonusAtk5,
    int MinDef,
    int DefCoef,
    int Skill1ID,
    int Skill2ID,
    int HoldEditSkillCost,
    int EditSkillId,
    int EditSkillLevelNum,
    int EditSkillCost,
    int EditSkillRelationId,
    int Abilities11,
    int Abilities12,
    int Abilities13,
    int Abilities14,
    int Abilities21,
    int Abilities22,
    int Abilities23,
    int Abilities24,
    int Abilities31,
    int Abilities32,
    int Abilities33,
    int Abilities34,
    int ExAbilityData1,
    int ExAbilityData2,
    int ExAbilityData3,
    int ExAbilityData4,
    int ExAbilityData5,
    int ExAbility2Data1,
    int ExAbility2Data2,
    int ExAbility2Data3,
    int ExAbility2Data4,
    int ExAbility2Data5,
    string Availability
);