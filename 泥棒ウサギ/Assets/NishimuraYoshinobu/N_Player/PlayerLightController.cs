using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; //Light2Dを使うのに必要

//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

public class PlayerLightController : MonoBehaviour
{
    Light2D light2d;            // Light2D
    PlayerControll playerCnt; //PlayerControllerスクリプト
    float lightTimer = 0.0f;    //ライトの消費タイマー

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light2d = GetComponent<Light2D>(); //Light2Dを取得
        light2d.pointLightOuterRadius = (float)ItemKeeper.hasLights; //アイテムの数でライト距離を変更
        playerCnt = GameObject.FindObjectOfType<PlayerControll>(); //PlayerController取得
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCnt == null)
        {
            playerCnt = GameObject.FindObjectOfType<PlayerControll>();
            if (playerCnt == null)
            {
                Debug.Log("PlayerControllが見つかりません");
                return;
            }
        }
        //ライトをプレイヤーに合わせて回転させる
        transform.position = playerCnt.transform.position;
        light2d.transform.localRotation = Quaternion.Euler(0, 0, playerCnt.angleZ + 90);
        if (ItemKeeper.hasLights > 0)//ライトを持っている
        {
            lightTimer += Time.deltaTime;//フレーム時間を加算
            if (lightTimer > 10.0f ) //10秒経過
            {
                lightTimer = 0.0f; //タイマーリセット
                ItemKeeper.hasLights--; //ライトアイテムを減らす
                light2d.pointLightOuterRadius = ItemKeeper.hasLights; //アイテムの数でライト距離を変更
            }
        }
    }
    public void LightUpdate()
    {
        light2d.pointLightOuterRadius = ItemKeeper.hasLights;//アイテムの数でライト距離を変更
    }
}
