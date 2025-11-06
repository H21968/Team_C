using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FUIManager : MonoBehaviour
{
    int hp = 0;
    public GameObject lifeImage;         //HPの数を表示するImage
    public GameObject retryButton;       //リトライボタン
    public GameObject inputPanel;        //バーチャルパッドと攻撃ボタンを配置した操作パネル
    public Sprite life3Image;           //HP3画像
    public Sprite life2Image;　　　　　 //HP2画像　　
    public Sprite life1Image;           //HP1画像
    public Sprite life0Image;           //HP0画像
    public GameObject mainImage;        //画像を持つGameObject
    public Sprite gameOverSpr;          //GAME OVER画像
    public Sprite gameClearSpr;         //GAME CLEAR画像
    public string retrySceneName = "";  //リトライするシーン


    //HP更新
    void UpdateHP()
    {
        //Player取得
        if (PlayerControll.gameState != "gameend")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                if (PlayerControll.player_hp != hp)
                {
                    hp = PlayerControll.player_hp;
                    if (hp <= 0)
                    {
                        lifeImage.GetComponent<Image>().sprite = life0Image;
                        //プレイヤー死亡！
                        retryButton.SetActive(true);                           //ボタン表示
                        mainImage.SetActive(true);                             //画像表示
                                                                               //画像を設定する
                        mainImage.GetComponent<Image>().sprite = gameOverSpr;
                        inputPanel.SetActive(false);                           //操作UI非表示
                        PlayerControll.gameState = "gameend";                  //ゲーム終了
                    }
                }

            }
            else if (hp == 1)
            {
                lifeImage.GetComponent<Image>().sprite = life1Image;
            }
            else if (hp == 2)
            {
                lifeImage.GetComponent<Image>().sprite = life2Image;
            }
            else
            {
                lifeImage.GetComponent<Image>().sprite = life3Image;
            }
        }
    }

    //リトライ
    public void Retry()
    {
        //HPを戻す
        PlayerControll.player_hp = 3;
        //ゲーム中に戻す
        SceneManager.LoadScene(retrySceneName);//シーン移動
    }

    //画像を非表示にする
    void InactiveImage()
    {
        mainImage.SetActive(false);
    }


    //ゲームクリア
    public void GameClear()
    {
        //画像非表示
        mainImage.SetActive(true);
        mainImage.GetComponent<Image>().sprite = gameClearSpr;//「GAME CLEAR」を設定する
        //ゲームをクリアにする
        PlayerControll.gameState = "gameClear";
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateHP();//HP更新
        //画像を非表示にする
        Invoke("InactiveImage", 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHP();//HP更新

    }
}

