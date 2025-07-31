using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public HariSO[] hariData;
    public DeckAndDiscardSO startingDeck;
    public PertanyaanSO[] pertanyaanPool;
    public DeckManager deckManager;
    public UIManager ui;

    int currentDay;
    int satisfyBar;
    int requiredSatisfy;
    PertanyaanSO currentPertanyaan;

    public static GameController Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        StartDay(0);
    }

    void StartDay(int dayIndex)
    {
        StartCoroutine(StartDayCoroutine(dayIndex));
    }

    IEnumerator StartDayCoroutine(int dayIndex)
    {
        // 1) Inisialisasi data hari
        if (hariData == null || hariData.Length <= dayIndex || hariData[dayIndex] == null)
        {
            Debug.LogError("HariSO tidak ada untuk index " + dayIndex);
            yield break;
        }
        currentDay = dayIndex;
        satisfyBar = 0;
        requiredSatisfy = hariData[dayIndex].satisfyPointNeed;

        // 2) Setup deck
        if (startingDeck == null)
        {
            Debug.LogError("Starting Deck belum di-assign!");
            yield break;
        }
        deckManager.SetupDeck(startingDeck);

        // 3) Tampilkan "Hari ke-X"
        ui.ShowDayPopup(currentDay + 1);
        yield return new WaitForSeconds(2f);

        // 4) Bersihkan hand, spawn 4 kartu
        foreach (Transform child in ui.handContainer)
            Destroy(child.gameObject);

        for (int i = 0; i < 4; i++)
            DealCardToHand();

        // 5) Tampilkan dialog orangtua pertama
        NextParentDialog();
    }

    void NextParentDialog()
    {
        // Jika deck habis → win
        if (deckManager.DrawCount == 0)
        {
            ui.ShowWin();
            return;
        }

        // Pilih pertanyaan random dan update UI
        currentPertanyaan = pertanyaanPool[Random.Range(0, pertanyaanPool.Length)];
        ui.UpdateParentDialog(currentPertanyaan);
    }

    void DealCardToHand()
    {
        var card = deckManager.Draw();
        if (card != null)
            ui.AddCardToHand(card);
    }

    // Dipanggil saat user klik prefab kartu
    public void OnPlayCard(KartuSO card)
    {
        if (currentPertanyaan == null)
        {
            ui.ShowMessage("Belum ada pertanyaan orangtua");
            return;
        }

        if (card.iconType == currentPertanyaan.requiredIcon)
        {
            // Jawaban benar
            satisfyBar += card.satisfyPoint;
            ui.UpdateSatisfyBar(satisfyBar, requiredSatisfy);
            ui.ShowChildDialog(card.dialogText);
            deckManager.Discard(card);

            if (satisfyBar >= requiredSatisfy)
            {
                // Selesai hari, langsung start hari berikutnya
                StartDay(currentDay + 1);
            }
            else
            {
                NextParentDialog();
            }
        }
        else
        {
            ui.ShowMessage("Tidak bisa memainkan kartu ini");
        }
    }

    public void OnDrawPressed()
    {
        if (satisfyBar > 0)
        {
            satisfyBar--;
            DealCardToHand();
            ui.UpdateSatisfyBar(satisfyBar, requiredSatisfy);
        }
        else ui.ShowMessage("Memerlukan 1 satisfy point");
    }

    public void OnEndTurnPressed()
    {
        if (satisfyBar > 0)
        {
            satisfyBar--;
            ui.UpdateSatisfyBar(satisfyBar, requiredSatisfy);
            NextParentDialog();
        }
        else ui.ShowMessage("Memerlukan 1 satisfy point");
    }

    public void OnSurrenderPressed()
    {
        ui.ShowGameOver();
    }
}
