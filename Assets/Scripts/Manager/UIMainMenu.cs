using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractMusicButton()
    {
        MusicManager.Instance.MusicOnOff();
    }
    public void Begin()
    {
        SceneManager.LoadScene("ingame");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
