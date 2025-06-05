using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HealthSystem : MonoBehaviourPun
{
    public float health = 100f;
    public float healthMax = 100f;
    public Image HPBar;

    private bool isDead = false;

    void Start()
    {
        ChangeHealthUi();
    }

    public void TakeDamage(float damage)
    {
        if (!photonView.IsMine) return;

        health -= damage;
        if (health <= 0 && !isDead)
        {
            health = 0;
            isDead = true;

            photonView.RPC("RPC_Death", RpcTarget.All); // всі бачать смерть
        }

        photonView.RPC("RPC_UpdateHealthUI", RpcTarget.All, health);
    }

    [PunRPC]
    void RPC_UpdateHealthUI(float newHealth)
    {
        health = newHealth;
        ChangeHealthUi();
    }

    public void ChangeHealthUi()
    {
        float xscale = health / healthMax;
        HPBar.transform.localScale = new Vector3(xscale, 1, 1);
    }

    [PunRPC]
    void RPC_Death()
    {
        StopAllCoroutines(); // щоб не було повторних викликів
        StartCoroutine(DeathAndRespawn());
    }

    IEnumerator DeathAndRespawn()
    {
        gameObject.SetActive(false); // тимчасово вимикаємо
        yield return new WaitForSeconds(2f);

        health = healthMax;
        isDead = false;

        ChangeHealthUi();

        // Переміщаємо об’єкт трохи, і вмикаємо знову
        transform.position += new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
        gameObject.SetActive(true);

        photonView.RPC("RPC_UpdateHealthUI", RpcTarget.All, health);
    }
}