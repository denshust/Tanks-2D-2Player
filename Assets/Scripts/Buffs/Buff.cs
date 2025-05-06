using System.Collections;
using UnityEngine;

public abstract class Buff : MonoBehaviour
{
    public float duration = 5f;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<TankBuffManager>(out TankBuffManager manager))
        {
            
            manager.ApplyBuff(Apply(other.gameObject));
            Destroy(gameObject);
        }
    }

    protected abstract IEnumerator Apply(GameObject target);
}
