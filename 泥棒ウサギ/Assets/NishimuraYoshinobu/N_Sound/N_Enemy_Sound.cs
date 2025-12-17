using System.Collections.Generic;
using UnityEngine;

public class N_Enemy_Sound : MonoBehaviour
{
    public float rectionDistance = 2.0f;

    bool isActive = false;//アクティブフラグ

    // +++ サウンド追加
    public AudioClip enemy_access;          //敵が接近している

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Enemyのゲームオブジェクトを得る
        GameObject Enemy = GameObject.FindGameObjectWithTag("Enemy");
       

           
        if (Enemy != null)
        {
            //プレイヤーをの距離チェックとアクティブ化
            float dist = Vector2.Distance(transform.position, Enemy.transform.position);
           
            if (dist < rectionDistance)
            {
                isActive = true; //アクティブにする
                Sound_Enemy_Access();
            }
          
        }
        else
        {
            Sound_Stop();
            isActive = false;

        }


    }
    void Sound_Enemy_Access()
    {
        AudioSource soundPlayer = GetComponent<AudioSource>();
        if (soundPlayer != null)
        {
            if (!soundPlayer.isPlaying)// 再生中でなければ鳴らす
            {
                //サウンドを鳴らす
                soundPlayer.PlayOneShot(enemy_access);
            }

        }
    }

    void Sound_Stop()
    {
        AudioSource soundPlayer = GetComponent<AudioSource>();
        if (soundPlayer != null)
        {
            //サウンドを止める
            soundPlayer.Stop();
        }
    }
}
