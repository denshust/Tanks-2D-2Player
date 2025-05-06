using System.Collections;
using UnityEngine;

public class DamageBuff : Buff
{
    public float damageMultiplier = 1.5f;

    protected override IEnumerator Apply(GameObject target)
    {
        TankShot shot = target.GetComponent<TankShot>();
        if (shot != null)
        {
            shot.bulletDamage *= damageMultiplier;
            yield return new WaitForSeconds(duration);
            shot.bulletDamage /= damageMultiplier;
        }
    }
}
