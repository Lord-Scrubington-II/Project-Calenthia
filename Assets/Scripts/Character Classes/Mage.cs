using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArcanumOfTheMage", menuName = "Character Classes/Mage", order = 2)]
public class Mage : PlayerActor
{
    private readonly int BASE_HP = 80;
    private readonly int BASE_MP = 35;

    private readonly int BASE_ATK = 10;
    private readonly int BASE_MATK = 23;
    private readonly int BASE_DEF = 15;
    private readonly int BASE_MDEF = 20;
    private readonly int BASE_SPD = 18;
    private readonly int BASE_LUK = 14;

    private readonly int HPG = 9;
    private readonly int MPG = 6;

    private readonly int ATKG = 2;
    private readonly int MATKG = 9;
    private readonly int DEFG = 4;
    private readonly int MDEFG = 8;
    private readonly int SPDG = 6;
    private readonly int LUKG = 4;
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
