using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : PlayerActor
{
    [SerializeField] private readonly uint BASE_HP = 80;
    [SerializeField] private readonly uint BASE_MP = 35;

    [SerializeField] private readonly uint BASE_ATK = 10;
    [SerializeField] private readonly uint BASE_MATK = 23;
    [SerializeField] private readonly uint BASE_DEF = 15;
    [SerializeField] private readonly uint BASE_MDEF = 20;
    [SerializeField] private readonly uint BASE_SPD = 18;
    [SerializeField] private readonly uint BASE_LUK = 14;

    [SerializeField] private readonly uint HPG = 9;
    [SerializeField] private readonly uint MPG = 6;

    [SerializeField] private readonly uint ATKG = 2;
    [SerializeField] private readonly uint MATKG = 9;
    [SerializeField] private readonly uint DEFG = 4;
    [SerializeField] private readonly uint MDEFG = 8;
    [SerializeField] private readonly uint SPDG = 6;
    [SerializeField] private readonly uint LUKG = 4;

    private void Awake()
    {
        //load from json all mutable fields

        //if no json, load base lv.1 stats
        this.name = "Dietrich";

        this.isMartial = false;

        //stats declaration
        this.HPMax = this.CurrentHP = BASE_HP;
        this.MPMax = this.CurrentMP = BASE_MP;
        this.AllGrowthRates = new GrowthRateMatrix(ATKG, MATKG, DEFG, MDEFG, SPDG, LUKG);
        this.AllStats = new StatisticsBlock(BASE_ATK, BASE_MATK, BASE_DEF, BASE_MDEF, BASE_SPD, BASE_LUK);

        //load starting skills into skill list
        this.Skills.Add(null);
    }
}
