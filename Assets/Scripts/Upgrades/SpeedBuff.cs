using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Powerups/SpeedBuff")]
public class SpeedBuff : PowerUpEffect
{
    public float amount;
    //public float otherAmount; //if you want to change each independently
    public override void Apply(GameObject target)
    {
        target.GetComponent<Player>().horizontalSpeed += amount;//Increment amount can be changed here
        target.GetComponent<Player>().verticalSpeed += amount;
    }
}
