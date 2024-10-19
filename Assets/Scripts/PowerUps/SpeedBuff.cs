using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "powerups/speedBuff")]
public class SpeedBuff : PowerupEffect
{
    public float amount; 
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerMovement>().speed += amount;
    }
}

