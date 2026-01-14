using UnityEngine;

public class FGameOverManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GameStatus.player_spawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        // 仮：Zキーでゲームオーバー → リスポーン
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        GameStatus.player_spawn = false;

    }
}
