using System.Collections;
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
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void Start()
    {
        StartDay(0);
    }

    void StartDay(int dayIndex)
    {
        StartCoroutine(StartDayCoroutine(dayIndex));
    }

    IEnumerator StartDayCoroutine(int dayIndex)
    {
        currentDay = dayIndex;
        satisfyBar = 0;
        requiredSatisfy = hariData[dayIndex].satisfyPointNeed;

        deckManager.SetupDeck(startingDeck);

        ui.ShowDayPopup(currentDay + 1);

        yield return new WaitForSeconds(2f); // Tunggu popup selesai
                                             // Bersihkan kartu lama
        foreach (Transform child in ui.handContainer)
        {
            GameObject.Destroy(child.gameObject);
        }
        for (int i = 0; i < 4; i++) DealCardToHand();
        //NextParentDialog();
    }

    void NextParentDialog()
    {
        if (deckManager.DrawCount == 0) { ui.ShowWin(); return; }
        currentPertanyaan = pertanyaanPool[Random.Range(0, pertanyaanPool.Length)];
        ui.UpdateParentDialog(currentPertanyaan);
        DealCardToHand();
    }

    void DealCardToHand()
    {
        var card = deckManager.Draw();
        if (card != null) ui.AddCardToHand(card);
    }

    public void OnPlayCard(KartuSO card)
    {
        if (card.iconType == currentPertanyaan.requiredIcon)
        {
            satisfyBar += card.satisfyPoint;
            ui.UpdateSatisfyBar(satisfyBar, requiredSatisfy);
            ui.ShowChildDialog(card.dialogText);
            deckManager.Discard(card);
            if (satisfyBar >= requiredSatisfy) ui.ShowNextDay();
            else NextParentDialog();
        }
        else ui.ShowMessage("Tidak bisa memainkan kartu");
    }

    public void OnDrawPressed()
    {
        if (satisfyBar > 0) { satisfyBar--; DealCardToHand(); ui.UpdateSatisfyBar(satisfyBar, requiredSatisfy); }
        else ui.ShowMessage("Memerlukan 1 satisfy point");
    }

    public void OnEndTurnPressed()
    {
        if (satisfyBar > 0) { satisfyBar--; ui.UpdateSatisfyBar(satisfyBar, requiredSatisfy); NextParentDialog(); }
        else ui.ShowMessage("Memerlukan 1 satisfy point");
    }

    public void OnSurrenderPressed()
    {
        ui.ShowGameOver();
    }
}