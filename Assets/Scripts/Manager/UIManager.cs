using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text parentText;
    public Image parentIcon;
    public TMP_Text messageText;
    public Slider satisfySlider;
    public Transform handContainer;
    public GameObject cardPrefab;

    // Referensi ikon emoticon di Inspector
    public Sprite encourageIcon;
    public Sprite empathyIcon;
    public Sprite rudeIcon;

    public void ShowDayPopup(int day)
    {
        // TODO: tampilkan popup "Hari ke-" + day
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
        var go = Instantiate(cardPrefab, handContainer);
        var cardUI = go.GetComponent<CardView>();
        cardUI.Setup(cardSO);
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