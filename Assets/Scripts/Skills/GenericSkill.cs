
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
