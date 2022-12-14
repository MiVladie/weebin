using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class MenuController : MonoBehaviourPunCallbacks
{
    public InputField input;
    
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(input.text);
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(input.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

}
