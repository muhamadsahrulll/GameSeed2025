using UnityEngine;
[CreateAssetMenu(menuName = "SO/Pertanyaan")]
public class PertanyaanSO : ScriptableObject
{
    public JenisIcon requiredIcon;
    [TextArea] public string dialogText;
}