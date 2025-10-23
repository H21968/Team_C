using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_Z_key : MonoBehaviour
{
    public string Z_key;
    public float Z_Delay = 1f;//Zキーを押せる間隔
    bool inLnvestigate = false;//調べるためのフラグ
    public GameObject Z_keyPrefab;//Zキーのプレハブ
    GameObject Z_keyOBJ;//Zキーのゲームオブジェクト

    //オブジェクトの感知
    public string Z_Perception;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Z_keyPrefab)
        {
            Z_keyOBJ = Instantiate(Z_keyPrefab);
            
        }
        else
        {
            Z_keyOBJ = new GameObject("Z_keyOBJ");
        }
        //調べるためのオブジェクトをプレイヤーの前に配置
        //Vector3 pos = transform.position;
        Z_keyOBJ.transform.SetParent(transform);//調べるためのオブジェクトの親をプレイヤーに設定
        Z_keyOBJ.transform.localPosition = new Vector3(0,0,-1);
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Fire3") || Input.GetMouseButtonDown(0))
        {
            Debug.Log("a");
            //調べるキーが押された
            Lnvestigate();
        }
        //調べるキーの回転と優先順位
        float inLnvestigate_Point_Z = -1;//調べるキーをプレイヤーの前にする
        PlayerControll plmv = GetComponent<PlayerControll>();
        if (plmv.angleZ > 30 && plmv.angleZ < 150)
        {
            //上向き
            inLnvestigate_Point_Z = 1;//キャラクタの後ろにする
        }
        Z_keyOBJ.transform.position = 
            new Vector3(transform.position.x, transform.position.y, inLnvestigate_Point_Z);
    }
}
