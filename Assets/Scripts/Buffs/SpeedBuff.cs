using System.Collections;
using UnityEngine;

public class SpeedBuff : Buff
{
    public float speedUpAmount = 2f;

    protected override IEnumerator Apply(GameObject target)
    {
        TankMovement movement = target.GetComponent<TankMovement>();
        if (movement != null)
        {
            movement.moveSpeed += speedUpAmount;
            yield return new WaitForSeconds(duration);
            movement.moveSpeed -= speedUpAmount;
        }
    }
}
