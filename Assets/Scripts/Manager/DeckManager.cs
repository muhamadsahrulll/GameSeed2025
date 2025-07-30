using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    private List<KartuSO> drawPile;
    private List<KartuSO> discardPile;

    public void SetupDeck(DeckAndDiscardSO deckSO)
    {
        drawPile = new List<KartuSO>(deckSO.kartuList);
        discardPile = new List<KartuSO>();
        Shuffle(drawPile);
    }

    public void Shuffle(List<KartuSO> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var tmp = list[i];
            int rnd = Random.Range(i, list.Count);
            list[i] = list[rnd]; list[rnd] = tmp;
        }
    }

    public KartuSO Draw()
    {
        if (drawPile.Count == 0) return null;
        var card = drawPile[0];
        drawPile.RemoveAt(0);
        return card;
    }

    public void Discard(KartuSO card)
    {
        discardPile.Add(card);
    }

    public int DrawCount => drawPile.Count;
}