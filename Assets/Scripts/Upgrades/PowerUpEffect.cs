using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public abstract class PowerUpEffect : ScriptableObject
{
    public abstract void Apply(GameObject target);
}
