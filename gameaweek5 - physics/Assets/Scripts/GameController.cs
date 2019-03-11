using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] players;
    public bool gameOver = false;
    public GameObject endGamePanel, gamePanel;
    public Text endGameText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false)
        {
            checkList();
        }
    }

    private void checkList()
    {
        if (players[0] == null)
        {
            endGamePanel.SetActive(true);
            gamePanel.SetActive(false);
            gameOver = true;
            endGameText.text += "Player 2 Wins!";
            Time.timeScale = 0.0f;
        }
        else if (players[1] == null)
        {
            endGamePanel.SetActive(true);
            gamePanel.SetActive(false);
            gameOver = true;
            endGameText.text += "Player 1 Wins!";
            Time.timeScale = 0.0f;
        }
    }
}
