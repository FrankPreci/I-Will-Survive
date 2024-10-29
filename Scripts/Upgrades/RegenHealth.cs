using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creates a scriptable object that can be attached to a gameobject to change its currentHealth
[CreateAssetMenu(menuName = "Powerups/RegenBuff")]
public class RegenHealth : PowerUpEffect //instant health
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<Health>().currentHealth += amount;
    }
}
