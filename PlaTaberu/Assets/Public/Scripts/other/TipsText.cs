using UnityEngine;
using UnityEngine.UI;

public class TipsText : MonoBehaviour
{
    private GameObject parent;
    private Text tipsText;

    //tipsの文章
    private string[] tips =
    {
        /*全角9文字以内で改行
        "〇〇〇〇〇〇〇〇〇"←ここまで*/
        "海洋ゴミ問題は大変",
        "てすとてきすとです\nてすとです",
        "Test3\nデバッグめんどい",
        "プロコン健闘賞",
    };

    private void Start()
    {
        parent = this.transform.parent.gameObject;
        tipsText = GetComponent<Text>();

        //tipsをランダムに選択
        tipsText.text = tips[Random.Range(0,tips.Length)];
    }

    private void Update()
    {
        /*フェードイン*/
        Color color = tipsText.color;
        color.a = parent.GetComponent<Image>().color.a;
        tipsText.color = color;
    }
}
