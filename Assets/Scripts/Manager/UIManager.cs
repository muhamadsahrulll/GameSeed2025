using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Dialog Orangtua")]
    public TMP_Text parentText;
    public Image parentIcon;

    [Header("Day Popup")]
    public TMP_Text dayText;

    [Header("Hand & Kartu")]
    public Transform handContainer;
    public GameObject cardPrefab;

    [Header("Emoticon Icons")]
    public Sprite encourageIcon;
    public Sprite empathyIcon;
    public Sprite rudeIcon;

    [Header("Satisfy Bar")]
    public Slider satisfySlider;

    [Header("Message Popup")]
    public TMP_Text messageText;

    public void ShowDayPopup(int day)
    {
        dayText.gameObject.SetActive(true);
        dayText.text = $"Hari ke-{day}";
        StartCoroutine(HideDayPopup());
    }

    IEnumerator HideDayPopup()
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

    public void ShowChildDialog(string childText)
    {
        // Implementasikan popup dialog anak jika perlu
        Debug.Log("Dialog anak: " + childText);
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
            Debug.LogError("CardPrefab atau handContainer belum diset!");
            return;
        }

        var go = Instantiate(cardPrefab, handContainer);
        var cardUI = go.GetComponent<CardView>();
        if (cardUI != null) cardUI.Setup(cardSO);
    }

    public void ShowWin()
    {
        Debug.Log("You Win!");
        // Tampilkan panel win
    }

    public void ShowGameOver()
    {
        Debug.Log("Game Over!");
        // Tampilkan panel lose
    }

    public void ShowMessage(string msg)
    {
        messageText.text = msg;
        // Tampilkan sementara lalu sembunyikan kembali
        StartCoroutine(HideMessage());
    }

    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(1.5f);
        messageText.text = "";
    }
}
