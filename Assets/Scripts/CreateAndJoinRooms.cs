using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;


public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI inviteCode;
    public TMP_InputField joinInput;

    private string authCode;
    private const string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const int stringLength = 6;


    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(authCode);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join room");
    }

    public void CreateRandomCode()
    {
        StartCoroutine(CreateRandomCodeCoroutine());
    }

    IEnumerator CreateRandomCodeCoroutine()
    {
        inviteCode.text = "Generating...";
        yield return new WaitForSeconds(1);
        inviteCode.text = GenerateRandomString();
    }

    private string GenerateRandomString()
    {
        char[] result = new char[stringLength];
        System.Random random = new System.Random();

        for (int i = 0; i < stringLength; i++)
        {
            result[i] = characters[random.Next(characters.Length)];
        }

        authCode = new string(result);
        Debug.Log("Unique Code = " + authCode);

        return new string(result);
    }
}
