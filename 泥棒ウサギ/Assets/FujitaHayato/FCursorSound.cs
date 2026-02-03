using UnityEngine;

public class FCursorSound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // 上キーが押されたとき

            //SE再生
            FSoundManager.soundManager.SEPlay(SEType.IdowKey);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // 下キーが押されたとき

            //SE再生
            FSoundManager.soundManager.SEPlay(SEType.IdowKey);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // 左キーが押されたとき

            //SE再生
            FSoundManager.soundManager.SEPlay(SEType.IdowKey);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // 右キーが押されたとき

            //SE再生
            FSoundManager.soundManager.SEPlay(SEType.IdowKey);
        }
    }
}
