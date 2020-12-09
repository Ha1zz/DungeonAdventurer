using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    //[SerializeField]
    //List<AnimationClip> clips;

    [SerializeField]
    public List<Effect> effects;

    public virtual void ApplyEffects(ICharacter caster, ICharacter target)
    {
        foreach (Effect effect in effects)
        {
            effect.Apply(caster, target);
        }
    }
}
