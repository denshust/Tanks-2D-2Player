using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public float damage = 20f;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<HealthSystem>(out HealthSystem healhtobjekt))
        {
            healhtobjekt.TakeDamage(damage);
        }
        
    }

}
