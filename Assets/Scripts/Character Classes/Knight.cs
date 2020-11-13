using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BookOfTheKnight", menuName = "Character Classes/Knight", order = 1)]
public class Knight : PlayerActor
{
    private readonly int BASE_HP = 100;
    private readonly int BASE_MP = 20;

    private readonly int BASE_ATK = 20;
    private readonly int BASE_MATK = 10;
    private readonly int BASE_DEF = 20;
    private readonly int BASE_MDEF = 17;
    private readonly int BASE_SPD = 12;
    private readonly int BASE_LUK = 16;

    private readonly int HPG = 12;
    private readonly int MPG = 3;

    private readonly int ATKG = 8;
    private readonly int MATKG = 2;
    private readonly int DEFG = 8;
    private readonly int MDEFG = 5;
    private readonly int SPDG = 4;
    private readonly int LUKG = 4;

    private void Awake()
    {
        //load from json all fields

        //if no json, load base lv.1 stats

        this.isMartial = true;

        //lv. 1 stats declaration
        LoadLevelOneStats();

        //load starting skills into skills list
        //this.Skills.Add(null);
    }

    public override void UseSkill(GenericSkill skill)
    {
        
    }

    public override int StandardAttack()
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