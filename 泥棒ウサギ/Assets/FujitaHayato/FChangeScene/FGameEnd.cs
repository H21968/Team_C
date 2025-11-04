using UnityEngine;

public class FGameEnd : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Escキーが押されたらゲームを終了する
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
    void QuitGame()
    {
        // アプリを終了
        Application.Quit();

        // Unityエディタ上では再生を止める
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

}
