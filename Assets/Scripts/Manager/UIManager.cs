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
    public TMP_Text dayTextNavbar;
    public Animator DayAnim;

    [Header("Hand & Kartu")]
    public Transform handContainer;
    public GameObject cardPrefab;
    public Animator cardImpactAnim;    
    
    [Header("Gift Kartu")]
    public Transform giftContainer;
    public GameObject giftPanel;
    public Animator giftCardImpactAnim;

    [Header("Satisfy Bar")]
    public Animator barImpactAnim;
    public Slider satisfySlider;
    public TMP_Text satisfyPointText;

    [Header("Message Popup")]
    public TMP_Text messageText;

    [Header("Game Over")]
    public GameObject GameOver;
    public TMP_Text Days;
    public TMP_Text Cards;
    public TMP_Text Points;
    public TMP_Text Total;
    public int totalInt;
    public DeckManager deckManager;

    [Header("Deck")]
    public TMP_Text deckCounter;



    public void ShowDayPopup(int day)
    {
        giftPanel.gameObject.SetActive(false);
        foreach (Transform child in giftContainer)
        {
            Destroy(child.gameObject);
        }
        DayAnim.Play("fadein", 0, 0f);
        dayText.gameObject.SetActive(true);
        dayText.text = $"Hari ke-{day}";
        dayTextNavbar.text = $"Hari ke-{day}";
        StartCoroutine(HideDayPopup());
    }

    IEnumerator HideDayPopup()
    {
        yield return new WaitForSeconds(2f);
        dayText.gameObject.SetActive(false);
    }

    public void UpdateParentDialog(PertanyaanSO p)
    {
        dialogBoxParent.gameObject.SetActive(true);

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
        barImpactAnim.Play("Impact", 0, 0f);
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

        deckCounter.text = deckManager.drawPile.Count.ToString();
        var go = Instantiate(cardPrefab, handContainer);
        var cardUI = go.GetComponent<CardView>();
        if (cardUI != null)
        {
            cardImpactAnim.Play("Impact", 0, 0f);
            cardUI.currentKartu = cardSO;
            cardUI.Setup(cardSO);
        }    
    }


    public void CardDisplay(KartuSO cardSO)
    {
        if (cardPrefab == null || handContainer == null)
        {
            Debug.LogError("CardPrefab atau handContainer belum diset!");
            return;
        }

        var go = Instantiate(cardPrefab, giftContainer);
        var cardUI = go.GetComponent<CardView>();
        if (cardUI != null)
        {
            giftCardImpactAnim.Play("Impact", 0, 0f);
            cardUI.currentKartu = cardSO;
            cardUI.Setup(cardSO);
            cardUI.isGifted = true;
        }
    }

    public void ShowWin()
    {
        Debug.Log("You Win!");
        // Tampilkan panel win
        giftPanel.SetActive(true);
        GameController.Instance.GiftDays();
    }

    public void ShowGameOver()
    {
        Debug.Log("Game Over!");
        // Tampilkan panel lose
        GameOver.SetActive(true);
        Days.text = $"{GameController.Instance.currentDay}({(GameController.Instance.currentDay / 2)})";
        Cards.text = $"{deckManager.discardPile.Count}({(deckManager.discardPile.Count/2)})";
        Points.text = $"{GameController.Instance.satisfyBarTotal}({(GameController.Instance.satisfyBarTotal / 20)})";
        totalInt = (GameController.Instance.currentDay / 2) + (deckManager.discardPile.Count / 2) + (GameController.Instance.satisfyBarTotal / 20);
        Total.text = totalInt.ToString();
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
