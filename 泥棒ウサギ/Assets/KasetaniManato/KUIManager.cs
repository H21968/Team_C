using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KUIManager: MonoBehaviour
{

    int hp = 0;
    public GameObject lifeImage;         //HPの数を表示するImage
    public GameObject retryButton;       //リトライボタン
    public GameObject mainImage;         //画像を持つGameObject
    public GameObject inputPanel;        //バーチャルパッドと攻撃ボタンを配置した操作パネル
    public Sprite gameOverSpr;           //GAME OVER画像 
    public Sprite life3Image;           //HP3画像
    public Sprite life2Image;　　　　　 //HP2画像　　
    public Sprite life1Image;           //HP1画像
    public Sprite life0Image;           //HP0画像


    //HP更新
    void UpdateHP()
    {
        //Player取得
        if (PlayerControll.gameState!="gameend")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if(player!=null)
            {
                if(PlayerControll.player_hp!=hp )
                {
                    hp= PlayerControll.player_hp;
                    if(hp<=0)
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
            else if(hp==2)
            {
                lifeImage.GetComponent<Image>().sprite = life2Image;
            }
            else
            {
                lifeImage.GetComponent<Image>().sprite = life3Image;
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
