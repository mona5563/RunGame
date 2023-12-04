/*TextMesh Proアニメーション
 * 2023/12/04
 * https://note.com/logic_magic/n/ncef582c3a454
 * こちらの記事からコードをお借りしました
 */
using UnityEngine;
using TMPro;

[ExecuteInEditMode, RequireComponent(typeof(TMP_Text))]
public class TMP_wave : MonoBehaviour
{
    [SerializeField] private float amp;
    [SerializeField] private float speed;
    [SerializeField] private int length;

    private TMP_Text tmpText;
    private TMP_TextInfo tmpInfo;

    private void Start()
    {
        tmpText = this.GetComponent<TMP_Text>();
    }

    private void Update()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        tmpText.ForceMeshUpdate(true);
        tmpInfo = tmpText.textInfo;

        var count = Mathf.Min(tmpInfo.characterCount, tmpInfo.characterInfo.Length);
        for (int i = 0; i < count; i++)
        {
            var charInfo = tmpInfo.characterInfo[i];
            if (!charInfo.isVisible)
                continue;

            int matIndex = charInfo.materialReferenceIndex;
            int vertIndex = charInfo.vertexIndex;

            Vector3[] verts = tmpInfo.meshInfo[matIndex].vertices;

            float ofs = 0.5f * i;
            float sinWave = Mathf.Sin((ofs + Time.realtimeSinceStartup * Mathf.PI * speed) / length) * amp;
            verts[vertIndex + 0].y += sinWave;
            verts[vertIndex + 1].y += sinWave;
            verts[vertIndex + 2].y += sinWave;
            verts[vertIndex + 3].y += sinWave;
        }

        for (int i = 0; i < tmpInfo.materialCount; i++)
        {
            if (tmpInfo.meshInfo[i].mesh == null) { continue; }

            tmpInfo.meshInfo[i].mesh.vertices = tmpInfo.meshInfo[i].vertices;
            tmpText.UpdateGeometry(tmpInfo.meshInfo[i].mesh, i);
        }
    }
}