using System.Collections;
using UnityEngine;

public class HealthRegenBuff : Buff
{
    public float healAmountPerSecond = 5f;

    protected override IEnumerator Apply(GameObject target)
    {
        HealthSystem hp = target.GetComponent<HealthSystem>();
        float time = 0f;

        while (time < duration && hp != null)
        {
            hp.health = Mathf.Min(hp.health + healAmountPerSecond * Time.deltaTime, hp.healthMax);
            time += Time.deltaTime;
            hp.ChangeHealthUi();
            yield return null;
        }
    }
}
