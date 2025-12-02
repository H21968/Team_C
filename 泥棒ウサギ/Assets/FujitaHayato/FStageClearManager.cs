using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   //UIを使うのに必要

public static class StageClearManager
{
    public static bool stage1 = false;
    public static int stage2 = 0;
    public static int stage3 = 0;
    public static int stage4 = 0;
}


public class FStageClearManager : MonoBehaviour
{
    public GameObject gameClearSpr1;     //GAMECLEAR画像
    public GameObject gameClearSpr2;     //GAMECLEAR画像
    public GameObject gameClearSpr3;     //GAMECLEAR画像
    public GameObject gameClearSpr4;     //GAMECLEAR画像


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //if(StageClearManager.stage1==)
        //{
        //    gameClearSpr1.SetActive(false);
        //}
       
        //gameClearSpr2.SetActive(false);
        //gameClearSpr3.SetActive(false);
        //gameClearSpr4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //画像を非表示にする
    void InactiveImage()
    {
        gameClearSpr1.SetActive(false);
    }
}
