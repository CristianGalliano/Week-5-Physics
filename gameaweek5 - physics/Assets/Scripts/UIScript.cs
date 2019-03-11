using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartLevel()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void returnToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void play()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
