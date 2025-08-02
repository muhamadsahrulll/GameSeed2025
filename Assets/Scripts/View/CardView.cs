using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    public Image kartuVisual;
    public KartuSO currentKartu;

    public bool isGifted = false;

    public void Setup(KartuSO kartu)
    {
        kartuVisual.sprite = kartu.kartuSprite;
        currentKartu = kartu;
    }

    public void PlayThisCard()
    {
        if (isGifted == false)
        {
            GameController.Instance.OnPlayCard(currentKartu);
        }
    }

    public void DestroyKartu()
    {
        if(GameController.Instance.currentPertanyaan != null & isGifted == false)
        {
            if (currentKartu.iconType == GameController.Instance.currentPertanyaan.requiredIcon)
            {
                Destroy(gameObject);
            }
        }
    }

    public void GetCard()
    {
        if (isGifted == true)
        {
            GameController.Instance.OnGetPressed(currentKartu);
        }
    }
}
