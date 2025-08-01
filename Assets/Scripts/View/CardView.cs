using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    public Image kartuVisual;
    public KartuSO currentKartu;

    public void Setup(KartuSO kartu)
    {
        kartuVisual.sprite = kartu.kartuSprite;
        currentKartu = kartu;
    }

    public void PlayThisCard()
    {
        GameController.Instance.OnPlayCard(currentKartu);
    }
}
