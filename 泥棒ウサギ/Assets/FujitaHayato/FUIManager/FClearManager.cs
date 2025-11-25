using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   //UIを使うのに必要

public class FClearManager : MonoBehaviour
{
    public GameObject mainImage;    //画像を持つGameObject
    public Sprite gameClearSpr;     //GAMECLEAR画像
    public Sprite gameOverSpr;      //GAMEOVER画像

    public GameObject ufo;          //ufoのオブジェクトを触る用

    Image titleImage;               //画像を表示しているImageコンポーネント

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //画像を非表示にする
        Invoke("InactiveImage", 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        //きゅうりを取った時ufoが出現する処理
        //最初ufoを非表示にする用
        ufo.SetActive(false);
        //きゅうりの数が１の時ufoが現れる用
        if(ItemKeeper.haskyuuri>=2&&ItemKeeper.hasnakama>=1)
        {
            ufo.SetActive(true);    //ufoが出てくる
        }


        //ゲームクリアした時
        if (PlayerControll.gameState=="gameclear")
        {
            mainImage.SetActive(true);      //画像を表示する

            mainImage.GetComponent<Image>().sprite = gameClearSpr;    //画像を設定する
        }
        //ゲームオーバーになった時
        else if (PlayerControll.gameState == "gameover")
        {
            mainImage.SetActive(true);      //画像を表示する

            mainImage.GetComponent<Image>().sprite = gameOverSpr;    //画像を設定する
        }

        else if(PlayerControll.gameState=="playing")
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
