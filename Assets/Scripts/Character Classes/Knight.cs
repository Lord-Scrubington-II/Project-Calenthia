using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : PlayerActor
{
    [SerializeField] private readonly uint BASE_HP = 100;
    [SerializeField] private readonly uint BASE_MP = 20;

    [SerializeField] private readonly uint BASE_ATK = 20;
    [SerializeField] private readonly uint BASE_MATK = 10;
    [SerializeField] private readonly uint BASE_DEF = 20;
    [SerializeField] private readonly uint BASE_MDEF = 17;
    [SerializeField] private readonly uint BASE_SPD = 12;
    [SerializeField] private readonly uint BASE_LUK = 16;

    [SerializeField] private readonly uint HPG = 12;
    [SerializeField] private readonly uint MPG = 3;

    [SerializeField] private readonly uint ATKG = 8;
    [SerializeField] private readonly uint MATKG = 2;
    [SerializeField] private readonly uint DEFG = 8;
    [SerializeField] private readonly uint MDEFG = 5;
    [SerializeField] private readonly uint SPDG = 4;
    [SerializeField] private readonly uint LUKG = 4;

    private void Awake()
    {
        //load from json all fields

        //if no json, load base lv.1 stats
        this.name = "Talezar";

        this.isMartial = true;

        //stats declaration
        this.HPMax = this.CurrentHP = BASE_HP;
        this.MPMax = this.CurrentMP = BASE_MP;
        this.AllGrowthRates = new GrowthRateMatrix(ATKG, MATKG, DEFG, MDEFG, SPDG, LUKG);
        this.AllStats = new StatisticsBlock(BASE_ATK, BASE_MATK, BASE_DEF, BASE_MDEF, BASE_SPD, BASE_LUK);

        //load starting skills into skill list
        this.Skills.Add(null);
    }

    public override void UseSkill(GenericSkill skill)
    {
        
    }
}