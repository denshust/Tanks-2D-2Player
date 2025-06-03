using Photon.Pun;
using UnityEngine;
public class TankShot : MonoBehaviour
{
    public PhotonView photonView;
    public GameObject bulletPrefab;
    public Transform gunShotPoint;
    public float bulletSpeed = 20f;
    public float bulletDamage = 10f; ///////////
    public KeyCode ShotBullet;
    public Animator tankAnimator;
    public void SpawnBullet()
    {
        GameObject patron = PhotonNetwork. Instantiate(bulletPrefab.name, gunShotPoint.position, gunShotPoint.rotation);
        Rigidbody2D fizikaPuli = patron.GetComponent<Rigidbody2D>();
        patron.GetComponent<Bullet>().damage = bulletDamage; ///////////
        fizikaPuli.AddForce(gunShotPoint.up * bulletSpeed, ForceMode2D.Impulse);
        tankAnimator.SetTrigger("Shot");
    }
    //Instantiate = Spawn, Input = perevirka na knopku
    public void Update()
    {
        if (Input.GetKeyDown(ShotBullet)&& photonView.IsMine)
        {         
                SpawnBullet();
        }
    }

}
