using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    public TMP_Text dialogText;
    public TMP_Text typeText;
    public TMP_Text satisfyPointText;
    public Image iconImage;

    // Icon sprite dari UIManager (bisa juga langsung isi di sini kalau ingin standalone)
    public Sprite encourageIcon;
    public Sprite empathyIcon;
    public Sprite rudeIcon;

    public void Setup(KartuSO kartu)
    {
        dialogText.text = kartu.dialogText;
        typeText.text = kartu.iconType.ToString();
        satisfyPointText.text = "+" + kartu.satisfyPoint;

        switch (kartu.iconType)
        {
            case JenisIcon.Encourage:
                iconImage.sprite = encourageIcon;
                break;
            case JenisIcon.Empathy:
                iconImage.sprite = empathyIcon;
                break;
            case JenisIcon.Rude:
                iconImage.sprite = rudeIcon;
                break;
        }
    }
}
