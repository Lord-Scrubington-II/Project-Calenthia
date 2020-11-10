using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArcanumOfTheMage", menuName = "Character Classes/Mage", order = 2)]
public class Mage : PlayerActor
{
    private readonly uint BASE_HP = 80;
    private readonly uint BASE_MP = 35;

    private readonly uint BASE_ATK = 10;
    private readonly uint BASE_MATK = 23;
    private readonly uint BASE_DEF = 15;
    private readonly uint BASE_MDEF = 20;
    private readonly uint BASE_SPD = 18;
    private readonly uint BASE_LUK = 14;

    private readonly uint HPG = 9;
    private readonly uint MPG = 6;

    private readonly uint ATKG = 2;
    private readonly uint MATKG = 9;
    private readonly uint DEFG = 4;
    private readonly uint MDEFG = 8;
    private readonly uint SPDG = 6;
    private readonly uint LUKG = 4;
    private void Awake()
    {
        //load from json all mutable fields

        //if no json, load base lv.1 stats
        this.isMartial = false;

        //stats declaration
        LoadLevelOneStats();

        //load starting skills into skills list
        //this.Skills.Add(null);
    }
    public override int StandardAttack()
    {
        throw new System.NotImplementedException();
    }

    public override void UseSkill(GenericSkill skill)
    {
        throw new System.NotImplementedException();
    }

    public override void LoadLevelOneStats()
    {
        this.HPMax = this.CurrentHP = BASE_HP;
        this.MPMax = this.CurrentMP = BASE_MP;
        this.AllGrowthRates = new GrowthRateMatrix(HPG, MPG, ATKG, MATKG, DEFG, MDEFG, SPDG, LUKG);
        this.AllStats = new StatisticsBlock(BASE_ATK, BASE_MATK, BASE_DEF, BASE_MDEF, BASE_SPD, BASE_LUK);
        this.Level = 1;
    }
}
