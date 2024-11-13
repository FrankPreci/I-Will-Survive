using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/GainExp")]
public class ExpDrop : PowerUpEffect
{

    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<Player>().currentEXP += amount;
    }
}
