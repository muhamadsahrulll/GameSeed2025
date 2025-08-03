using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    public int C = 0;
    public List<Sprite> tutorialSpr;
    public Image tutorialContainer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractTutorialNext()
    {
        if(tutorialSpr != null & C < tutorialSpr.Count - 1)
        {
            C++;
            tutorialContainer.sprite = tutorialSpr[C];
        }
    }
    
    public void InteractTutorialPrevious()
    {
        if(tutorialSpr != null & C > 0)
        {
            C--;
            tutorialContainer.sprite = tutorialSpr[C];
        }
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
