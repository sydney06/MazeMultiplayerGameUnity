using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject loseUI;
    [SerializeField] private TextMeshProUGUI timerText;

    private PlayerMovement player;
    private GlowEffect _glowEffect;
    private float timeLeft = 10f;
    private bool canBeginOp = false;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;


    private void Start()
    {
        _glowEffect = Object.FindObjectOfType<GlowEffect>();

        StartCoroutine(DelayedOperation());
        SpawnPlayer();
    }

    private void Update()
    {
        if (canBeginOp)
        {
            if (player.isPlayerCaught)
            {
                loseUI.SetActive(true);
                RespawnTimer();
                Debug.Log("Player caught");
            } 
        }

        timerText.text = timeLeft.ToString("0");
    }

    IEnumerator DelayedOperation()
    {
        yield return new WaitForSeconds(1);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        canBeginOp = true;
    }

    private void RespawnTimer()
    {
        timeLeft -= Time.deltaTime;

        if(timeLeft < 0)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void SpawnPlayer()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
    }
}
