using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektSpawner : MonoBehaviour
{
    public GameObject objektprefab;
    
    public void SpawnObjekt()
    {
        Vector3 spawnposishion = new Vector3 (Random.Range(-20, 20), Random.Range(-15, 15), 0);
        Instantiate(objektprefab, spawnposishion, Quaternion.identity);
    }
    void Start()
    {
        Debug.Log("Start");
        for (int i = 0; i < 20; i++)
        {
            SpawnObjekt();
        } 
    }

}
