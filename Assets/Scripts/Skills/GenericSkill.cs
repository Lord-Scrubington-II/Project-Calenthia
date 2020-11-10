
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericSkill : ScriptableObject
{
    private ParticleSystem particles;
    private int baseDamage;
    private int baseAccuracy;
    protected string skillName;
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

    

    public abstract void InvokeSkill();
}
