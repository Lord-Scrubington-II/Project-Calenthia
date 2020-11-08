using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BookOfTheKnight", menuName = "Character Classes/Knight", order = 1)]
public class Knight : PlayerActor
{
    private readonly uint BASE_HP = 100;
    private readonly uint BASE_MP = 20;

    private readonly uint BASE_ATK = 20;
    private readonly uint BASE_MATK = 10;
    private readonly uint BASE_DEF = 20;
    private readonly uint BASE_MDEF = 17;
    private readonly uint BASE_SPD = 12;
    private readonly uint BASE_LUK = 16;

    private readonly uint HPG = 12;
    private readonly uint MPG = 3;

    private readonly uint ATKG = 8;
    private readonly uint MATKG = 2;
    private readonly uint DEFG = 8;
    private readonly uint MDEFG = 5;
    private readonly uint SPDG = 4;
    private readonly uint LUKG = 4;

    private void Awake()
    {
        //load from json all fields

        //if no json, load base lv.1 stats

        this.isMartial = true;

        //stats declaration
        this.HPMax = this.CurrentHP = BASE_HP;
        this.MPMax = this.CurrentMP = BASE_MP;
        this.AllGrowthRates = new GrowthRateMatrix(HPG, MPG, ATKG, MATKG, DEFG, MDEFG, SPDG, LUKG);
        this.AllStats = new StatisticsBlock(BASE_ATK, BASE_MATK, BASE_DEF, BASE_MDEF, BASE_SPD, BASE_LUK);

        //load starting skills into skill list
        //this.Skills.Add(null);
    }

    public override void UseSkill(GenericSkill skill)
    {
        
    }

    public override int StandardAttack()
    {
        throw new System.NotImplementedException();
    }
}