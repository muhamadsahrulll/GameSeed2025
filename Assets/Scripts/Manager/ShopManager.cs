using UnityEngine;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    public ShopCardView[] slots;       // drag ShopCardView dari 3 slot
    public KartuSO[] allKartuSO;       // assign semua KartuSO di Project
    public int startIndex = 4, endIndex = 9; // range SO yang dipakai

    void Start()
    {
        // filter SO index 4–9:
        List<KartuSO> pool = new List<KartuSO>();
        for (int i = startIndex; i <= endIndex && i < allKartuSO.Length; i++)
            pool.Add(allKartuSO[i]);

        // random unique pick sesuai jumlah slot
        for (int i = 0; i < slots.Length; i++)
        {
            int r = Random.Range(0, pool.Count);
            slots[i].Setup(pool[r]);
            pool.RemoveAt(r);
        }
    }
}
