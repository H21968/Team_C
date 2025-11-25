 using UnityEngine;
using UnityEngine.UI;

public class StageClearUI : MonoBehaviour
{
    [Header("UI 参照")]
    public GameObject resultPanel;
    public Text titleText;
    public Text timeText;
    public Text rescueText;
    public Text veggieText;
    public Image[] starImages;   // 星アイコン3つ（Star1?3）
    public Sprite starOn;        // 光ってる星
    public Sprite starOff;       // 消えてる星

    [Header("ノルマ設定")]
    public int totalFriends = 3;
    public int veggieTarget = 10;

    void Start()
    {
        resultPanel.SetActive(false);
    }

    public void ShowResult(float clearTime, int rescuedFriends, int collectedVeggies)
    {
        resultPanel.SetActive(true);

        titleText.text = "ステージクリア！??";
        timeText.text = $"クリアタイム：{clearTime:F2} 秒";

        bool rescueOK = rescuedFriends >= totalFriends;
        bool veggieOK = collectedVeggies >= veggieTarget;

        rescueText.text = $"仲間救出：{rescuedFriends}/{totalFriends} → {(rescueOK ? "達成！" : "未達成")}";
        rescueText.color = rescueOK ? Color.green : Color.gray;

        veggieText.text = $"野菜収集：{collectedVeggies}/{veggieTarget} → {(veggieOK ? "達成！" : "未達成")}";
        veggieText.color = veggieOK ? Color.green : Color.gray;

        // ★ 星の数を計算
        int stars = 0;
        if (rescueOK) stars++;
        if (veggieOK) stars++;
        if (clearTime <= 120f) stars++; // 例：2分以内で+1

        // 星表示更新
        UpdateStars(stars);
    }

    void UpdateStars(int count)
    {
        for (int i = 0; i < starImages.Length; i++)
        {
            starImages[i].sprite = (i < count) ? starOn : starOff;
        }
    }
}
