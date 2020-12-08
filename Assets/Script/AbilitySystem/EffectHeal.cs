using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectHeal", menuName = "Effects/Heal")]

public class EffectHeal : Effect
{
    [SerializeField]
    TargetAndEffectType targetAndEffectType;

    [SerializeField]
    int healthAmount;

    public override void Apply(ICharacter caster, ICharacter target)
    {
        switch (targetAndEffectType)
        {
            case (TargetAndEffectType.OpponentHeal):
                {
                    target.Heal(healthAmount);
                    target.HealAnimation();
                    break;
                }
            case (TargetAndEffectType.SelfHeal):
                {
                    caster.Heal(healthAmount);
                    caster.HealAnimation();
                    break;
                }
        }
    }
}
