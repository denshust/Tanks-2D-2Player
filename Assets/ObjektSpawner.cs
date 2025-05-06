using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektSpawner : MonoBehaviour
{
    public GameObject[] objektprefabs;
    public int amount = 20;
    public void SpawnObjekt()
    {
        Vector3 spawnposishion = new Vector3(Random.Range(-20, 20), Random.Range(-15, 15), 0);
        GameObject objektprefab = objektprefabs[Random.Range( 0, objektprefabs.Length)];
        Instantiate(objektprefab, spawnposishion, Quaternion.identity);
    }
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnObjekt();
        }
        StartCoroutine(SpawnWithDelay());
    }

    IEnumerator SpawnWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            SpawnObjekt();
        }
    }

}
