using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   //UIを使うのに必要

public static class StageClearManager
{
    public static bool hatake1 = false;
    public static bool hatake2 = false;
    public static bool mise1 = false;
    public static bool mise2 = false;
    public static bool allclear = false;

    public static bool stage1 = false;     //クリアしてるかどうか用1
    public static bool stage2 = false;     //クリアしてるかどうか用2
    public static bool stage3 = false;     //クリアしてるかどうか用3
    public static bool stage4 = false;     //クリアしてるかどうか用4
}


public class FStageClearManager : MonoBehaviour
{
    public GameObject gameClearSpr1;     //GAMECLEAR画像
    public GameObject gameClearSpr2;     //GAMECLEAR画像
    public GameObject gameClearSpr3;     //GAMECLEAR画像
    public GameObject gameClearSpr4;     //GAMECLEAR画像
    public GameObject allStageClearSpr;  //すべてのステージクリアしたときの画像

    //public bool stage1 = false;     //クリアしてるかどうか用1
    //public bool stage2 = false;     //クリアしてるかどうか用2
    //public bool stage3 = false;     //クリアしてるかどうか用3
    //public bool stage4 = false;     //クリアしてるかどうか用4


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //クリアの画像を非表示にしている
        if (StageClearManager.hatake1 == false)
        {
            gameClearSpr1.SetActive(false);
        }
        if (StageClearManager.hatake2 == false)
        {
            gameClearSpr2.SetActive(false);
        }
        if (StageClearManager.mise1 == false)
        {
            gameClearSpr3.SetActive(false);
        }
        if (StageClearManager.mise2 == false)
        {
            gameClearSpr4.SetActive(false);
        }
        //すべてのステージクリアしたときの画像を非表示にしている
        if (StageClearManager.allclear == false)
        {
            allStageClearSpr.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        //すべてクリア画像を表示する
        StageClearManager.allclear = StageClearManager.allclear;
        //ゲームクリア画像を表示する
        StageClearManager.hatake1 = StageClearManager.hatake1;
        StageClearManager.hatake2 = StageClearManager.hatake2;
        StageClearManager.mise1 = StageClearManager.mise1;
        StageClearManager.mise2 = StageClearManager.mise2;

    }

    //画像を非表示にする
    void InactiveImage()
    {
        gameClearSpr1.SetActive(false);
        gameClearSpr2.SetActive(false);
        gameClearSpr3.SetActive(false);
        gameClearSpr4.SetActive(false);
        allStageClearSpr.SetActive(false);
    }
}
