using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance;
    [SerializeField] private GameObject _playerPrefab;
    private Vector2 _startPosition;

    public Transform[] spawnPoints;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;

        //_startPosition = new Vector3(Random.Range(-5f, 5f),0, Random.Range(-5f, 5f));
        int pointIndex = Random.Range(0, spawnPoints.Length);
        Vector2 offset = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        _startPosition = new Vector2(spawnPoints[pointIndex].position.x , spawnPoints[pointIndex].position.y) + offset;

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(_playerPrefab.name, _startPosition, Quaternion.identity);
        }
    }

    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Lobby");
    }


    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.LogFormat("Player {0} enterred room", newPlayer.NickName);
    }

    public override void OnJoinedRoom()
    {
      
        Debug.Log("Guest Player Joined a room.");
        _startPosition = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
        PhotonNetwork.Instantiate(_playerPrefab.name, _startPosition, Quaternion.identity);
    }
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        Debug.LogFormat("Player {0} left room", otherPlayer.NickName);
    }
}
