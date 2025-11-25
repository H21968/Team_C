using UnityEngine;
using UnityEngine.SceneManagement;  //シーンの切り替えに必要
using UnityEngine.UI;   //UIを使うのに必要


public class FRetryButton : MonoBehaviour
{
    public GameObject retryButton;  //リトライボタン
    public GameObject titleButton;  //タイトルボタン
    public GameObject stageSelect;  //ステージセレクト

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //リトライボタンを非表示にする
        retryButton.SetActive(false);
        //タイトルボタンを非表示にする
        titleButton.SetActive(false);
        //ステージセレクトボタンを非表示にする
        stageSelect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームクリアした時
        if (PlayerControll.gameState == "gameclear")
        {
            retryButton.SetActive(true);    //リトライボタン表示
            titleButton.SetActive(true);   //タイトルボタンを表示
            stageSelect.SetActive(true);   //ステージセレクトボタンを表示
        }
        //ゲームオーバーになった時
        else if (PlayerControll.gameState == "gameover")
        {
            retryButton.SetActive(true);    //リトライボタン表示
            titleButton.SetActive(true);   //タイトルボタンを表示
            stageSelect.SetActive(true);   //ステージセレクトボタンを表示
        }

        else if (PlayerControll.gameState == "playing")
        {
            //ゲーム中
        }
    }
}
