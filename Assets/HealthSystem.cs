using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float health = 100;
    public float healthMax = 100;
    public Image HPBar;
    public void ChangeHealthUi()
    {
        float xscale = health / healthMax;
        HPBar.transform.localScale  = new Vector3 (xscale, 1, 1);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Death();
        }
        ChangeHealthUi();
    }
    private void Death()
    {
        Invoke("Respawn", 2);
        gameObject.SetActive(false);
    }
    private void Respawn()
    {
        gameObject.SetActive(true);
        health = healthMax;
        transform.position += new Vector3(Random.Range(-2f, 2f),Random.Range(-2f, 2f));
    }

}
