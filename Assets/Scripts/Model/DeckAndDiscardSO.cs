using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(menuName = "SO/DeckAndDiscard")]
public class DeckAndDiscardSO : ScriptableObject
{
    public string deckName;
    public List<KartuSO> kartuList;
}