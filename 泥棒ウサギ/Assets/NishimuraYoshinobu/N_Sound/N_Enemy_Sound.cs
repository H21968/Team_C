using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵エネミー接敵時に鳴る曲を管理する
/// </summary>
public class N_Enemy_Sound : MonoBehaviour
{
    public float rectionDistance = 6.0f;    // 敵エネミーが接近していることを決める距離

    bool isActive = false;                  // アクティブフラグ

    // +++サウンド追加+++

    /// <summary>
    /// 敵が接近している時のBGM
    /// </summary>
    public AudioClip enemy_access;       
    /// <summary>
    /// BGM再生のAudioSource
    /// </summary>
    public AudioSource enemyAudioSource;    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isActive = false;
        if (enemyAudioSource != null)
        {
            enemyAudioSource.clip = enemy_access;
            enemyAudioSource.loop = true; //ループ設定
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Enemyのゲームオブジェクトを得る
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        isActive = false;


        foreach (GameObject enemy in Enemies)
        {
            //プレイヤーをの距離チェックとアクティブ化
            float dist = Vector2.Distance(transform.position, enemy.transform.position);

            if (dist < rectionDistance)
            {
                isActive = true; //アクティブにする
                Sound_Enemy_Access();
                break;
            }
        }
        if (!isActive)
        {
            Sound_Stop(); // BGMを止める
        }


    }
    void Sound_Enemy_Access()
    {
        if (enemyAudioSource != null && !enemyAudioSource.isPlaying)
        {
            if (!enemyAudioSource.isPlaying)// 再生中でなければ鳴らす
            {
                // サウンドを鳴らす
               
                // bgmSource.PlayOneShot(enemy_access);
                enemyAudioSource.Play();
            }

        }

    }

    void Sound_Stop()
    {
        if (enemyAudioSource != null && enemyAudioSource.isPlaying)
        {
            // サウンドを止める
            enemyAudioSource.Stop();
        }
    }
}
