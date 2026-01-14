using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   //UIを使うのに必要

public class FClearMise2 : MonoBehaviour
{
    public GameObject mainImage;    //画像を持つGameObject
    public Sprite gameClearSpr;     //GAMECLEAR画像
    public Sprite gameOverSpr;      //GAMEOVER画像

    public GameObject ufo;          //ufoのオブジェクトを触る用

    Image titleImage;               //画像を表示しているImageコンポーネント

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameStatus.active_task == false)
            mainImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Zキーで画像を非表示（1秒後）
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameStatus.active_task = false;
            Invoke("InactiveImage", 0.3f);

            //SE再生
            FSoundManager.soundManager.SEPlay(SEType.ZKey);
        }


        //きゅうりを取った時ufoが出現する処理
        //最初ufoを非表示にする用
        ufo.SetActive(false);
        //きゅうりの数が6の時ufoが現れる用
        if (ItemKeeper.hassakuranbo >= 7 && ItemKeeper.hasnakama >= 1)
        {
            ufo.SetActive(true);    //ufoが出てくる
        }


        //ゲームクリアした時
        if (PlayerControll.gameState == "gameclear")
        {
            FRoomManager.doorNumber = 0;

            mainImage.SetActive(true);      //画像を表示する

            mainImage.GetComponent<Image>().sprite = gameClearSpr;    //画像を設定する

            //StageClearManagerをtureにした
            StageClearManager.mise2 = true;

            //ステージクリアしてるか用
            if (StageClearManager.hatake1 == true)
            {
                StageClearManager.stage1 = true;

                if (StageClearManager.hatake2 == true)
                {
                    StageClearManager.stage2 = true;

                    if (StageClearManager.mise1 == true)
                    {
                        StageClearManager.stage3 = true;

                        if (StageClearManager.mise2 == true)
                        {
                            StageClearManager.stage4 = true;

                            StageClearManager.allclear = true;
                        }
                    }
                }
            }

            //SE再生
            FSoundManager.soundManager.SEPlay(SEType.GameClear);
        }
        //ゲームオーバーになった時
        else if (PlayerControll.gameState == "gameover")
        {
            FRoomManager.doorNumber = 0;

            mainImage.SetActive(true);      //画像を表示する

            mainImage.GetComponent<Image>().sprite = gameOverSpr;    //画像を設定する


            //SE再生
            FSoundManager.soundManager.SEPlay(SEType.GameOver);
        }

        else if (PlayerControll.gameState == "playing")
        {
            //ゲーム中
        }
    }
    //画像を非表示にする
    void InactiveImage()
    {
        mainImage.SetActive(false);

    }
}
