using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PereshkodaHealth : MonoBehaviour
{
    public float health = 30;
   
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Death();
        }
       
    }
    private void Death()
    {
       PhotonNetwork.Destroy(gameObject);
    }

}
