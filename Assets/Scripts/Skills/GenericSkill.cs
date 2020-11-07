using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericSkill : ScriptableObject
{
    private ParticleSystem particles;
    private int baseDamage;
    private int baseAccuracy;
    private enum damageType
    {
        Fire,
        Water,
        Wind,
        Lightning,
        Light,
        Earth
    }

    invokeSkill();
}
