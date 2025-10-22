using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_Z_key : MonoBehaviour
{
    public string Z_key;
    public float Z_Delay;//Zキーを押せる間隔
    bool inLnvestigate = false;//調べるためのフラグ
    //public GameObject Z_keyPrefab;//Zキーのプレハブ
    GameObject Z_keyOBJ;//Zキーのゲームオブジェクト

    //調べる
    public void Lnvestigate()
    {
        if (inLnvestigate == false)
        {
            inLnvestigate = true;//調べるフラグを立てる

            Invoke("StopLnvestigate",Z_Delay);//調べるの停止と、間隔追加
        }
    }
    public void StopLnvestigate()
    {
        inLnvestigate = false;//調べるフラグを降ろす
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //調べるためのオブジェクトをプレイヤーの前に配置
        Vector3 pos = transform.position;
        Z_keyOBJ.transform.SetParent(transform);//調べるためのオブジェクトの親をプレイヤーに設定
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Fire3"))
        {
            //調べるキーが押された
            Lnvestigate();
        }
        //調べるキーの回転と優先順位
        float inLnvestigate_Point_Z = -1;//調べるキーをプレイヤーの前にする
    }
}
