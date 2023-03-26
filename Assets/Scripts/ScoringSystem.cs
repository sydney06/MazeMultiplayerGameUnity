using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject winScreen;

    public static int score;

    private void Start()
    {
        score = 0;
        winScreen.SetActive(false);
    }

    private void Update()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Keys: " + score + "/3";

        if (score == 3)
        {
            winScreen.SetActive(true);
        }
    }

    public void ToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
