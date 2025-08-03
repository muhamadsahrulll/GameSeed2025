using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopCardView : MonoBehaviour
{
    public Image kartuImage;
    public TMP_Text priceText;
    public Button buyButton;

    KartuSO kartuSO;

    void Awake()
    {
        buyButton.onClick.AddListener(OnBuyPressed);
    }

    public void Setup(KartuSO so)
    {
        kartuSO = so;
        kartuImage.sprite = so.kartuSprite;
        priceText.text = so.hargaKartu.ToString();
    }

    void OnBuyPressed()
    {
        // panggil GameController untuk beli
        GameController.Instance.TryBuyCard(kartuSO, this);
    }

    public void MarkSold()
    {
        buyButton.interactable = false;
        // misal tampilkan overlay SOLD
    }
}
