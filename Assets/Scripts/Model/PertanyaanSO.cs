using UnityEngine;
[CreateAssetMenu(menuName = "SO/Pertanyaan")]
public class PertanyaanSO : ScriptableObject
{
    public JenisIcon requiredIcon;
    public Sprite Icon;
    public Sprite ibuReaction;
    public Sprite dialogBox;
    [TextArea] public string dialogText;
    
}