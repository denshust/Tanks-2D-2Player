using System.Collections;
using UnityEngine;

public class BuletSpeedBuf : Buff
{
    public float bulletBufSpeed = 2f;

    protected override IEnumerator Apply(GameObject target)
    {
        TankShot shot = target.GetComponent<TankShot>();
        if (shot != null)
        {
            shot.bulletSpeed *= bulletBufSpeed;
            yield return new WaitForSeconds(duration);
            shot.bulletSpeed /= bulletBufSpeed;
        }
    }
}
