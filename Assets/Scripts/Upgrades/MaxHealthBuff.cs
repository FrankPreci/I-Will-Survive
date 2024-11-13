using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Creates a scriptable object that can be attached to a gameobject to change its maxHealth
[CreateAssetMenu(menuName ="Powerups/HealthBuff")]
public class MaxHealthBuff : PowerUpEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<Health>().maxHealth += amount;
    }
}
