
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

    private damageTypes DamageType { get => damageType;}

    private enum damageTypes
    {
        Fire,
        Water,
        Wind,
        Lightning,
        Light,
        Earth
    }

    public abstract void InvokeSkill();
}
