using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks
{

    public TMP_InputField roomNameField;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        int num = Random.Range(0, 10000);
        PhotonNetwork.NickName = $"Player_{num}";
        Debug.Log("Player: " + PhotonNetwork.NickName + "створився");

    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = "1";
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Master");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("OnDisconnected() : " + cause);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined the room");

        PhotonNetwork.LoadLevel("Game"); 
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogWarningFormat(" NOT JOINED THE ROOM : " + message + "   " + returnCode);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room creatd successfully.");
    }

    public override void OnCreateRoomFailed(short reternCode, string msg)
    {
        Debug.LogError("Failed to create room: " + msg);
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 20,
            IsOpen = true,
            IsVisible = true,
        };

        PhotonNetwork.CreateRoom(roomNameField.text, roomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomNameField.text);
    }
}