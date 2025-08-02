using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<KartuSO> drawPile;
    public List<KartuSO> giftPile;
    public List<KartuSO> discardPile;

    public void SetupDeck(DeckAndDiscardSO deckSO)
    {
            drawPile = new List<KartuSO>(deckSO.kartuList);
            giftPile = new List<KartuSO>(deckSO.kartuList);
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

    public KartuSO DrawGift()
    {
                if (drawPile.Count == 0) return null;
        KartuSO card = drawPile[0];
        drawPile.RemoveAt(0);
        drawPile.Add(card);
        return card;

    }
}