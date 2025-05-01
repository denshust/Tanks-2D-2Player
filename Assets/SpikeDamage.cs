using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<HealthSystem>(out HealthSystem healhtobjekt))
        {
            healhtobjekt.TakeDamage(0.1f);
        }
        
    }

}
