using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Creates a scriptable object that can be attached to a gameobject to change its maxHealth
[CreateAssetMenu(menuName ="Powerups/MagnetBuff")]
public class MagnetUpgrade : PowerUpEffect
{
    public int range;
    public override void Apply(GameObject target)
    {
        target.GetComponent<MagnetAura>().pullRange += range;
    }
}
