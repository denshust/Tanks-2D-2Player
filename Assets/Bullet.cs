using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
   public float damage = 10;
   private void OnCollisionEnter2D(Collision2D collision)
   {
     if(collision.collider.gameObject.TryGetComponent<HealthSystem>(out HealthSystem healhtobjekt))
        {
           healhtobjekt.TakeDamage(damage);
        }
        if (collision.collider.gameObject.TryGetComponent<PereshkodaHealth>(out  PereshkodaHealth pereshkoda))
        {
            pereshkoda.TakeDamage(damage);
        }
        Destroy(gameObject);
   }
}
