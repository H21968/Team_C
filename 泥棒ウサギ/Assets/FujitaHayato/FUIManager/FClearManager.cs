using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UI���g���̂ɕK�v

public class FClearManager : MonoBehaviour
{
    public GameObject mainImage;    //�摜������GameObject
    public Sprite gameClearSpr;     //GAMECLEAR�摜

    Image titleImage;               //�摜��\�����Ă���Image�R���|�[�l���g

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�摜���\���ɂ���
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
