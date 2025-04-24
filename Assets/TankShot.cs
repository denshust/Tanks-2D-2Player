using UnityEngine;
public class TankShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunShotPoint;
    public float bulletSpeed = 20f;
    public KeyCode ShotBullet;
    public void SpawnBullet()
    {

        GameObject patron = Instantiate(bulletPrefab, gunShotPoint.position, gunShotPoint.rotation);
        Rigidbody2D fizikaPuli = patron.GetComponent<Rigidbody2D>();
        fizikaPuli.AddForce(gunShotPoint.up * bulletSpeed, ForceMode2D.Impulse);
    }
    //Instantiate = Spawn, Input = perevirka na knopku
    public void Update()
    {

        if (Input.GetKeyDown(ShotBullet))
        {         
                SpawnBullet();
        }
    }
}
