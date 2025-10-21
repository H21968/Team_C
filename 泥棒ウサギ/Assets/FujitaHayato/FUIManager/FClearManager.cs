using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UIを使うのに必要

public class FClearManager : MonoBehaviour
{
    public GameObject mainImage;    //画像を持つGameObject
    public Sprite gameClearSpr;     //GAMECLEAR画像

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
        if(PlayerControll.gameState=="gameclear")
        {

        }

    }
}
