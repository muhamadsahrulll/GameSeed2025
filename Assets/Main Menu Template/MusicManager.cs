using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioClip clickSFX;
    public AudioSource audioSource; // bisa diisi dari inspector atau otomatis dicari

    public bool isMusicOn = true;
    public AudioSource audioSrc;
    public Button musicButton;
    public Sprite musicOn;
    public Sprite musicOff;
    ColorBlock cb;

    public static MusicManager Instance;

    public void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else Destroy(gameObject);
    }

    public void Start()
    {
        // Cari semua object yang memiliki tag "Button"
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");

        foreach (GameObject btnObj in buttons)
        {
            Button btn = btnObj.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(() => PlayClickSFX());
            }
        }
    }
    void PlayClickSFX()
    {
        if (clickSFX != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSFX);
        }
    }

    public void MusicOnOff()
    {
        if (isMusicOn == true)
        {
            cb = musicButton.colors;
            cb.normalColor = new Color(0.7f, 0.7f, 0.7f);
            isMusicOn = false;
            musicButton.image.sprite = musicOff;
            audioSrc.Pause();
        }
        else
        {
            cb = musicButton.colors;
            cb.normalColor = new Color(1f, 1f, 1f);
            isMusicOn = true;
            musicButton.image.sprite = musicOn;
            audioSrc.Play();
        }
    }
}
