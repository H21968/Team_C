using UnityEngine;

using TMPro;

public class StopwatchDisplay : MonoBehaviour

{

    public TextMeshProUGUI timeText;  // 表示するテキスト

    private float elapsedTime = 0f;   // 経過時間（秒）

    private bool isRunning = true;    // 動作中かどうか

    void Update()

    {

        if (isRunning)

        {

            // 経過時間を増やす

            elapsedTime += Time.deltaTime;

            // 分・秒・ミリ秒に分ける

            int minutes = (int)(elapsedTime / 60);

            int seconds = (int)(elapsedTime % 60);

            int milliseconds = (int)((elapsedTime * 100) % 100);

            // 表示更新（例：02:34.56）

            timeText.text = $"{minutes:00}:{seconds:00}.{milliseconds:00}";

        }

    }

    // 一時停止・再開用

    public void ToggleStopwatch()

    {

        isRunning = false;

    }



}