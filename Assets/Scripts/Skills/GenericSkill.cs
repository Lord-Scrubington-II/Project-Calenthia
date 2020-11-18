
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericSkill : ScriptableObject
{
    [SerializeField] private ParticleSystem particles;

    [Header("Skill Data")]
    [SerializeField] private float baseEffectFactor;
    [SerializeField] private int effectPercent;//0 -> 100
    [SerializeField] private int baseBreakDamage;
    [SerializeField] private int baseAccuracy;
    [SerializeField] private List<BuffDebuff> statusInflictedToTarget;
    [SerializeField] private List<BuffDebuff> statusAppliedToSelf;

    [Header("Skill Text")]
    [SerializeField] protected string skillName;
    [SerializeField] protected string skillDescription;

    private int numHits;
    private bool isPercentSkill;
    private DamageTypes damageType;
    private TargetGroup targetsGroup;
    private TargetType targetsType;
    private bool targetsSelfOnly;

    public enum DamageTypes
    {
        Fire,
        Water,
        Wind,
        Earth,
        Lightning,
        Light,
        Chaos,
        TypelessMagic,
        Physical,
        Healing
    }
    public enum TargetGroup
    {
        Single,
        All
    }

    public enum TargetType
    {
        Enemies,
        Allies,
        Actors,

    }

    //if true, disregard the 2-d target enum
    public bool TargetsSelfOnly { get => targetsSelfOnly; protected set => targetsSelfOnly = value; }
    //if true, calculate damage based on the effectPercent int
    public bool IsPercentSkill { get => isPercentSkill; protected set => isPercentSkill = value; }

    //target data
    public DamageTypes DamageType { get => damageType; protected set => damageType = value; }
    public TargetGroup TargetsGroup { get => targetsGroup; protected set => targetsGroup = value; }
    public TargetType TargetsType { get => targetsType; protected set => targetsType = value; }

    //effect data
    public int NumHits { get => numHits; protected set => numHits = value; }
    public float BaseEffectFactor { get => baseEffectFactor; protected set => baseEffectFactor = value; }
    public int BaseAccuracy { get => baseAccuracy; protected set => baseAccuracy = value; }
    public int BaseBreakDamage { get => baseBreakDamage; protected set => baseBreakDamage = value; }
    public int EffectPercent { get => effectPercent; set => effectPercent = value; }



    public abstract int InvokeSkill();
}
