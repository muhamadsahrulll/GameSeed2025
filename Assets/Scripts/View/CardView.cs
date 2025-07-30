using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour
{
    public Image iconImage;
    public TMP_Text dialogText;

    private KartuSO kartuData;

    public void Setup(KartuSO data)
    {
        kartuData = data;
        iconImage.sprite = data.kartuSprite;
        dialogText.text = data.dialogText;
    }

    public void OnClick()
    {
        // Kirim data ke GameController (misal: untuk validasi cocok/tidak)
        GameController.Instance.OnPlayCard(kartuData);
        Destroy(gameObject); // Hapus kartu dari tangan setelah dimainkan
    }
}
