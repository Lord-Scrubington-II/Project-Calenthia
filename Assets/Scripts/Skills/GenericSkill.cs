
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericSkill : ScriptableObject
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private int baseDamage;
    [SerializeField] private int baseAccuracy;
    [SerializeField] protected string skillName;
    private damageTypes damageType;
    public enum damageTypes
    {
        Fire,
        Water,
        Wind,
        Lightning,
        Light,
        Earth
    }

    public damageTypes DamageType { get => damageType;}
    public int BaseDamage { get => baseDamage;}
    public int BaseAccuracy { get => baseAccuracy;}

    public abstract void InvokeSkill();
}
