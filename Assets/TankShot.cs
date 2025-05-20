using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
public class TankShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunShotPoint;
    public float bulletSpeed = 20f;
    public float bulletDamage = 10f; ///////////
    public KeyCode ShotBullet;
    private PhotonView photonView;
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }
    public void SpawnBullet()
    {
        GameObject patron = PhotonNetwork.Instantiate(bulletPrefab.name, gunShotPoint.position, gunShotPoint.rotation);
        Rigidbody2D fizikaPuli = patron.GetComponent<Rigidbody2D>();
        patron.GetComponent<Bullet>().damage = bulletDamage; ///////////
        fizikaPuli.AddForce(gunShotPoint.up * bulletSpeed, ForceMode2D.Impulse);
    }
    //Instantiate = Spawn, Input = perevirka na knopku
    public void Update()
    {

        if (photonView.IsMine && Input.GetKeyDown(ShotBullet))
        {         
                SpawnBullet();
        }
    }
}
