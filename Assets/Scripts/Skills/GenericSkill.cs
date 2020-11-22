﻿
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
    [SerializeField] private List<BuffDebuff> statusInflictedToTarget = new List<BuffDebuff>();
    [SerializeField] private List<BuffDebuff> statusAppliedToSelf = new List<BuffDebuff>();

    [Header("Skill Text")]
    [SerializeField] protected string skillName;
    [SerializeField] protected string skillDescription;

    private int numHits;
    private bool isPercentSkill;
    private bool targetsSelfOnly;
    private bool cannotTargetSelf;//for ovbious reasons, targetsSelfOnly and cannotTargetSelf cannot both be true
    private DamageTypes damageType;
    private TargetGroup targetsGroup;
    private TargetType targetsType;


    public enum DamageTypes
    {
        Physical,
        TypelessMagic,
        Fire,
        Water,
        Wind,
        Earth,
        Lightning,
        Light,
        Chaos,
        Healing //negate effect number if healing
    }
    public enum TargetGroup
    {
        Single,
        Row,
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
    //if true, the skill is unable to target self even if otherwise a valid AOE target
    public bool CannotTargetSelf { get => cannotTargetSelf; protected set => cannotTargetSelf = value; }
    //if true, calculate effect based on the effectPercent int
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
    public int EffectPercent { get => effectPercent; protected set => effectPercent = value; }
    public List<BuffDebuff> StatusInflictedToTarget { get => statusInflictedToTarget; protected set => statusInflictedToTarget = value; }
    public List<BuffDebuff> StatusAppliedToSelf { get => statusAppliedToSelf; protected set => statusAppliedToSelf = value; }

    public abstract int InvokeSkill();
}
