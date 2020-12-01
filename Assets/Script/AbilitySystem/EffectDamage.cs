using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    break;
                }
            case (TargetAndEffectType.OpponentAttack):
                {
                    target.TakeDamage(power);
                    break;
                }
            case (TargetAndEffectType.AllAttack):
                {
                    caster.TakeDamage(power);
                    target.TakeDamage(power);
                    break;
                }
        }
    }
}
