using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   //UIを使うのに必要

public class FMise1ClearManager : MonoBehaviour
{
    public GameObject mainImage;    //画像を持つGameObject
    public Sprite gameClearSpr;     //GAMECLEAR画像
    public Sprite gameOverSpr;      //GAMEOVER画像

    public GameObject ufo;          //ufoのオブジェクトを触る用

    Image titleImage;               //画像を表示しているImageコンポーネント

    bool situation = true;          //ゲームクリアorゲームオーバーの処理を一回だけ通す用

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(GameStatus.active_task==false)
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
        //さくらんぼの数が6の時ufoが現れる用
        if (ItemKeeper.hassakuranbo >= 6 && ItemKeeper.hasnakama >= 1)
        {
            ufo.SetActive(true);    //ufoが出てくる
        }


        //ゲームクリアした時
        if (PlayerControll.gameState == "gameclear")
        {
            if(situation==true)
            {
                FRoomManager.doorNumber = 0;

                mainImage.SetActive(true);      //画像を表示する

                mainImage.GetComponent<Image>().sprite = gameClearSpr;    //画像を設定する

                //StageClearManagerをtureにした
                StageClearManager.mise1 = true;

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
                situation = false;
            }
          
        }
        //ゲームオーバーになった時
        else if (PlayerControll.gameState == "gameover")
        {
            if(situation==true)
            {
                FRoomManager.doorNumber = 0;

                mainImage.SetActive(true);      //画像を表示する

                mainImage.GetComponent<Image>().sprite = gameOverSpr;    //画像を設定する


                //SE再生
                FSoundManager.soundManager.SEPlay(SEType.GameOver);
                situation = false;
            }

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
