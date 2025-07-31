using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public TMP_Text parentText;
    public Image parentIcon;
    public TMP_Text messageText;
    public Slider satisfySlider;
    public Transform handContainer;
    public GameObject cardPrefab;

    [Header("Hari ke")]
    public TMP_Text dayText; // ← referensi TMP text "Hari ke-X"
    //public GameObject dayUI;

    // Referensi ikon emoticon di Inspector
    public Sprite encourageIcon;
    public Sprite empathyIcon;
    public Sprite rudeIcon;

    public void ShowDayPopup(int day)
    {
        //dayUI.SetActive(true);
        dayText.gameObject.SetActive(true);
        dayText.text = "Hari ke-" + day;
        StartCoroutine(HideDayTextAfterDelay());
        Debug.Log("Menampilkan Hari ke-" + day);

    }

    IEnumerator HideDayTextAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        dayText.gameObject.SetActive(false);
    }

    public void UpdateParentDialog(PertanyaanSO p)
    {
        parentText.text = p.dialogText;
        switch (p.requiredIcon)
        {
            case JenisIcon.Encourage:
                parentIcon.sprite = encourageIcon;
                break;
            case JenisIcon.Empathy:
                parentIcon.sprite = empathyIcon;
                break;
            case JenisIcon.Rude:
                parentIcon.sprite = rudeIcon;
                break;
        }
    }

    public void ShowChildDialog(string text)
    {
        // TODO: tampilkan teks dialog anak
    }

    public void UpdateSatisfyBar(int current, int max)
    {
        satisfySlider.maxValue = max;
        satisfySlider.value = current;
    }

    public void AddCardToHand(KartuSO cardSO)
    {
        if (cardPrefab == null || handContainer == null)
        {
            Debug.LogError("Card prefab atau handContainer belum diset di Inspector.");
            return;
        }

        var go = Instantiate(cardPrefab, handContainer);
        var cardUI = go.GetComponent<CardView>();

        if (cardUI != null)
        {
            cardUI.Setup(cardSO);
        }
        else
        {
            Debug.LogWarning("Prefab tidak memiliki komponen CardView.");
        }
    }


    public void ShowWin()
    {
        // TODO: tampilkan window win
    }

    public void ShowGameOver()
    {
        // TODO: tampilkan window game over
    }

    public void ShowNextDay()
    {
        // TODO: panggil GameController untuk start day berikutnya
    }

    public void ShowMessage(string msg)
    {
        // TODO: tampilkan pesan singkat ke pemain
    }
}