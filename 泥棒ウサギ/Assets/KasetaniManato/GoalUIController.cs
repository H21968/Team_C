using UnityEngine;

public class GoalUIController : MonoBehaviour
{
    [SerializeField] private GameObject goalPanel; // 目標達成画面 (Canvas 内の Panel)

    // ゲーム開始時に非表示にしておく
    void Start()
    {
        if (goalPanel != null)
            goalPanel.SetActive(false);
    }

    // 目標達成時に呼び出す関数
    public void ShowGoalAchieved()
    {
        if (goalPanel != null)
            goalPanel.SetActive(true);
    }
}
