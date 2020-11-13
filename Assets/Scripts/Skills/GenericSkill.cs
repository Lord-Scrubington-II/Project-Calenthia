
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericSkill : ScriptableObject
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private int baseDamage;
    [SerializeField] private int baseAccuracy;
    [SerializeField] protected string skillName;
    private int numHits;
    protected DamageTypes damageType;
    
    public enum DamageTypes
    {
        Fire,
        Water,
        Wind,
        Lightning,
        Light,
        Earth,
        TypelessMagic,
        Physical,
        Healing
    }

    public DamageTypes DamageType { get => damageType; protected set => damageType = value; }
    public int NumHits { get => numHits; protected set => numHits = value; }
    public int BaseDamage { get => baseDamage; protected set => baseDamage = value; }
    public int BaseAccuracy { get => baseAccuracy; protected set => baseAccuracy = value; }

    public abstract void InvokeSkill();
}
