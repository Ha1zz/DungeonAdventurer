using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    [SerializeField]
    AnimationClip clip;

    [SerializeField]
    AnimationClip clip2;

    [SerializeField]
    List<Effect> effects;

    public virtual void ApplyEffects(ICharacter caster, ICharacter target)
    {
        foreach(Effect effect in effects)
        {
            effect.Apply(caster, target);
        }
    }
}
