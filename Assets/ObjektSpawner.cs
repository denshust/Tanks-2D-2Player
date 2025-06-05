using System.Collections;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ObjektSpawner : MonoBehaviourPunCallbacks
{
    public GameObject[] objektprefabs;
    public int amount = 20;

    private Coroutine spawnCoroutine;
    private const string InitialSpawnDoneKey = "InitialSpawnDone";

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (!HasInitialSpawnHappened())
            {
                InitialSpawn();
                MarkInitialSpawnDone();
            }

            TakeOwnershipOfOrphanedObjects();
            StartSpawningLoop();
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        Debug.Log("Master Client змінився: " + newMasterClient.NickName);

        if (PhotonNetwork.IsMasterClient)
        {
            TakeOwnershipOfOrphanedObjects();
            StartSpawningLoop();
        }
    }

    private bool HasInitialSpawnHappened()
    {
        return PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(InitialSpawnDoneKey);
    }

    private void MarkInitialSpawnDone()
    {
        ExitGames.Client.Photon.Hashtable props = new ExitGames.Client.Photon.Hashtable();
        props[InitialSpawnDoneKey] = true;
        PhotonNetwork.CurrentRoom.SetCustomProperties(props);
    }

    private void InitialSpawn()
    {
        Debug.Log("Виконується ПЕРШИЙ спавн...");

        for (int i = 0; i < amount; i++)
        {
            SpawnObjekt();
        }
    }

    private void StartSpawningLoop()
    {
        if (spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(SpawnWithDelay());
        }
    }

    private void TakeOwnershipOfOrphanedObjects()
    {
        PhotonView[] views = FindObjectsOfType<PhotonView>();

        foreach (PhotonView view in views)
        {
            if (view.Owner == null && view.OwnershipTransfer == OwnershipOption.Takeover)
            {
                view.TransferOwnership(PhotonNetwork.LocalPlayer);
            }
        }
    }

    public void SpawnObjekt()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-20, 20), Random.Range(-15, 15), 0);
        GameObject objektPrefab = objektprefabs[Random.Range(0, objektprefabs.Length)];

        PhotonNetwork.Instantiate(objektPrefab.name, spawnPosition, Quaternion.identity);
    }

    IEnumerator SpawnWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            SpawnObjekt();
        }
    }
}