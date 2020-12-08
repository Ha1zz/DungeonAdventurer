using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

[CreateAssetMenu(fileName = "EffectDamage", menuName = "Effects/Damage")]

public class EffectDamage : Effect
{
    [SerializeField]
    TargetAndEffectType targetAndEffectType;

    [SerializeField]
    int power;

    public override void Apply(ICharacter caster,ICharacter target)
    {
        switch(targetAndEffectType)
        {
            case (TargetAndEffectType.SelfAttack):
                {
                    caster.TakeDamage(power);
                    caster.GetHit();
                    target.AttackLight();
                    break;
                }
            case (TargetAndEffectType.SelfHeavyAttack):
                {
                    caster.TakeDamage(power);
                    caster.GetHit();
                    target.AttackLight();
                    break;
                }
            case (TargetAndEffectType.OpponentAttack):
                {
                    target.TakeDamage(power);
                    target.GetHit();
                    caster.AttackLight();
                    break;
                }
            case (TargetAndEffectType.OpponentMediumAttack):
                {
                    target.TakeDamage(power);
                    target.GetHit();
                    caster.AttackMedium();
                    break;
                }
            case (TargetAndEffectType.OpponentHeavyAttack):
                {
                    target.TakeDamage(power);
                    target.GetHit();
                    caster.AttackHeavy();
                    break;
                }
            case (TargetAndEffectType.AllAttack):
                {
                    caster.TakeDamage(power);
                    caster.GetHit();
                    caster.AttackHeavy();

                    target.TakeDamage(power);
                    target.GetHit();
                    target.AttackLight();
                    break;
                }
        }
    }
}

//[CreateAssetMenu(fileName = "EffectHeal", menuName = "Effects/Heal")]
//public class EffectHeal : Effect
//{
//    [SerializeField]
//    TargetAndEffectType targetAndEffectType;

//    [SerializeField]
//    int healthAmount;

//    public override void Apply(ICharacter caster, ICharacter target)
//    {
//        switch (targetAndEffectType)
//        {
//            case (TargetAndEffectType.OpponentHeal):
//                {
//                    target.Heal(healthAmount);
//                    target.HealAnimation();
//                    break;
//                }
//        }
//    }
//}