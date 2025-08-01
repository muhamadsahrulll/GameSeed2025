using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Dialog Orangtua")]
    public Image ibuReaction;
    public Image dialogBoxParent;
    public TMP_Text parentText;
    public Image parentIcon;

    [Header("Dialog Anak")]
    public GameObject dialogPanelAnak;
    public Image dialogBoxAnak;
    public TMP_Text anakText;

    [Header("Day Popup")]
    public TMP_Text dayText;

    [Header("Hand & Kartu")]
    public Transform handContainer;
    public GameObject cardPrefab;

    [Header("Satisfy Bar")]
    public Slider satisfySlider;
    public TMP_Text satisfyPointText;

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
                ibuReaction.sprite = GameController.Instance.currentPertanyaan.ibuReaction;
                parentIcon.sprite = GameController.Instance.currentPertanyaan.Icon;
                dialogBoxParent.sprite = GameController.Instance.currentPertanyaan.dialogBox;
                break;
            case JenisIcon.Empathy:
                ibuReaction.sprite = GameController.Instance.currentPertanyaan.ibuReaction;
                parentIcon.sprite = GameController.Instance.currentPertanyaan.Icon;
                dialogBoxParent.sprite = GameController.Instance.currentPertanyaan.dialogBox;
                break;
            case JenisIcon.Rude:
                ibuReaction.sprite = GameController.Instance.currentPertanyaan.ibuReaction;
                parentIcon.sprite = GameController.Instance.currentPertanyaan.Icon;
                dialogBoxParent.sprite = GameController.Instance.currentPertanyaan.dialogBox;
                break;
        }
    }

    public void UpdateSatisfyBar(int current, int max)
    {
        satisfySlider.maxValue = max;
        satisfySlider.value = current;
        satisfyPointText.text = current.ToString() + " / " + max.ToString();

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
        if (cardUI != null)
        {
            cardUI.currentKartu = cardSO;
            cardUI.Setup(cardSO);
        }
            
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
