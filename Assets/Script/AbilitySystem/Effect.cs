using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    //public abstract void Apply(ICharacter caster, ICharacter target, AnimationClip casterClip, AnimationClip targetClip);

    public abstract void Apply(ICharacter caster, ICharacter target);

    //public abstract void PlayAnimation();
}
