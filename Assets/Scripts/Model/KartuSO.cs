using UnityEngine;
public enum JenisIcon { Encourage, Empathy, Rude }
[CreateAssetMenu(menuName = "SO/Kartu")]
public class KartuSO : ScriptableObject
{
    public JenisIcon iconType;
    public int satisfyPoint;
    public Sprite dialogBoxAnak;
    public Sprite kartuSprite;
    [TextArea] public string dialogText;
    public int knowledgePoint;
    public int hargaKartu;
}