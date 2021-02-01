
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericSkill : ScriptableObject
{
    [SerializeField] private ParticleSystem particles;

    [Header("Skill Data")]
    [SerializeField] private float baseEffectFactor;
    [SerializeField] private int effectPercent; //0 -> 100
    [SerializeField] private int baseBreakDamage;
    [SerializeField] private int baseAccuracy;
    [SerializeField] private Dictionary<BuffDebuff, float> statusInflictedToTarget = new Dictionary<BuffDebuff, float>();
    [SerializeField] private Dictionary<BuffDebuff, float> statusAppliedToSelf = new Dictionary<BuffDebuff, float>();

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
    public Dictionary<BuffDebuff, float> StatusInflictedToTarget { get => statusInflictedToTarget; protected set => statusInflictedToTarget = value; }
    public Dictionary<BuffDebuff, float> StatusAppliedToSelf { get => statusAppliedToSelf; protected set => statusAppliedToSelf = value; }


    /// <summary>
    /// Func: <c>InvokeSkill</c> (Virtual)
    /// <para>Default behaviour for skill casts. Handles basic healing, physical damage, and magic damage cases.</para>
    /// Params:
    /// <para>
    ///     <paramref name="caster"/>: the skill's caster. 
    ///     <paramref name="targets"/>: the skill's target(s).
    /// </para>
    /// </summary>
    public virtual void InvokeSkill(GenericActor caster, List<GenericActor> targets)
    {
        int atk;
        int def;
        int damage;
        if (damageType == DamageTypes.Healing)
        {
            //healing based on mdef
            int healing = (int)(baseEffectFactor * caster.GetTrueMagicDefense());
            foreach (GenericActor target in targets)
            {
                //healing based on percent
                if (isPercentSkill)
                {
                    healing = target.HPMax * effectPercent;
                }
                //heal the target
                target.CurrentHP += healing;

                //apply probabilistic buffs/debuffs
                foreach (KeyValuePair<BuffDebuff, float> status in StatusInflictedToTarget)
                {
                    float randf = Random.Range(0.0f, 1.0f);
                    if (randf <= status.Value)
                    {
                        target.attachStatusEffect(status.Key);
                    }
                }
            }
        }
        else
        {
            //damage based on atk if physical, matk otherwise
            atk = (damageType == DamageTypes.Physical) ? (int)(baseEffectFactor * caster.GetTrueAttack()) : (int)(baseEffectFactor * caster.GetTrueMagicAttack());
            float resistanceFactor;
            foreach (GenericActor target in targets)
            {
                //damage the target
                def = target.GetTrueDefense();
                damage = BattleElements.CombatManager.CalculateDamage(atk, def); //may be unnecessarily long.
                try
                {
                    //handle elemental resistances
                    resistanceFactor = (int)(target.WeakResist[this.damageType]);
                } catch (KeyNotFoundException) {
                    resistanceFactor = 1;
                }
                damage = (int)(damage * resistanceFactor);
                target.CurrentHP -= damage;

                //apply probabilistic buffs/debuffs
                foreach (KeyValuePair<BuffDebuff, float> status in StatusInflictedToTarget)
                {
                    float randf = Random.Range(0.0f, 1.0f);
                    if (randf <= status.Value)
                    {
                        target.attachStatusEffect(status.Key);
                    }
                }
            }
        }

        //apply probabilistic buffs/debuffs on self
        foreach (KeyValuePair<BuffDebuff, float> status in StatusAppliedToSelf)
        {
            float randf = Random.Range(0.0f, 1.0f);
            if (randf <= status.Value)
            {
                caster.attachStatusEffect(status.Key);
            }
        }
    }
}
