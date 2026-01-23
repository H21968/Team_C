using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Zキーの入力感知
/// </summary>

public class N_Z_key : MonoBehaviour
{
    public float Z_Delay = 2f;//Zキーを押せる間隔
    bool inLnvestigate = false;//調べるためのフラグ
   
    //調べる
    public void Lnvestigate()
    {
        if (inLnvestigate == false)
        {
            inLnvestigate = true;//調べるフラグを立てる
            Debug.Log("調べる");
            Invoke("StopLnvestigate",Z_Delay);//調べるの停止と、間隔追加
        }
    }
    public void StopLnvestigate()
    {
        inLnvestigate = false;//調べるフラグを降ろす
    }
    
    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Fire3") || Input.GetMouseButtonDown(0))
        {

            Lnvestigate();
        }

        //bool isActive_Z_key = false;//アクティブ

        //float rectionDistance = 2.0f;

        //Updateに入れる

        //playerのゲームオブジェクトを得る
        //GameObject player = GameObject.FindGameObjectWithTag("player");

        //if (player != null)
        //{
        //    //プレイヤーをの距離チェックとアクティブ化
        //    float dist = Vector2.Distance(transform.position, player.transform.position);
        //    if (dist < rectionDistance)
        //    {
        //        isActive = true; //アクティブにする

        //        if (isActive_Z_key && (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0)))
        //        {
        //               // ここにボタンををした後の処理を入れる
        //        }
        //    }
        //}
        //else
        //{
        //    isActive_Z_key = false;
        //}




    }

}
