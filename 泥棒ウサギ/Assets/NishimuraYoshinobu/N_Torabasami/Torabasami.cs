// N_Torabasami
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// トラップの制御
/// </summary>

public class Torabasami : MonoBehaviour// クラス
{
    //ヒットポイント
    public int torabasami_hp = 10;// このエネミーの? 10
    public float damage;          // プレイヤーのHPを減らす

    public float rectionDistance = 0.1f; //プレイヤーとの距離
    
    bool Anime_Bool = false;  // トラばさみのアニメーション
    bool Anime_Close = false; // トラばさみの閉じるアニメーション
    Rigidbody2D rbody;        // Rigidbody2D
    Animator animator;        // Animation

    bool isActive = false;    // アクティブフラグ
    public int arrangeId = 0; // 配置の識別に使う

    // +++ サウンド追加
    public AudioClip Trap_sound;   //トラばさみが閉じたのSE

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rbody = GetComponent<Rigidbody2D>();// Rigidbody2Dを得る
      animator = GetComponent<Animator>();// Animatorを得る
    }

    // Update is called once per frame
    void Update()
    {
        
        //playerのゲームオブジェクトを得る
        GameObject player = GameObject.FindGameObjectWithTag("player");

        if (player != null )
        {
            //プレイヤーをの距離チェックとアクティブ化
            float dist = Vector2.Distance(transform.position, player.transform.position);
            if (dist < rectionDistance)
            {
                isActive = true; //アクティブにする

                if (isActive && (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0)))
                {
                    //TakeDamage(10);
                }
            }
        }
        else
        {
            isActive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーダメージ
        if(collision.gameObject.tag == "player")
        {
            
            PlayerControll player = collision.gameObject.GetComponent<PlayerControll>();
            if (player != null)
            {

                GameStatus.player_hp -= ((int)damage);

                GameStatus.player_hp -= ((int)damage);
                Debug.Log("プレイヤーがダメージを受ける");
                // +++サウンド+++
                AudioSource soundPlayer = GetComponent<AudioSource>();
              

                if (GameStatus.player_hp <= 0)
                   
                {
                    player.GameOver();
                    Debug.Log("プレイヤー死亡");
                }
            }
        }
    }
    /// <summary>
    /// トラばさみが閉じるアニメーションの管理
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(int amount)
    {

        torabasami_hp -= amount;
        Anime_Bool = true;
        animator.SetBool("Anime_Bool", Anime_Bool);
        Debug.Log("トラバサミ解除");
        if(torabasami_hp <= 0)
        {

            Touch_Sound_Torabasami();
            Anime_Close = true;
            animator.SetBool("Anime_int", Anime_Close);
           
            // 破壊処理
            // あたりを消す
            GetComponent<CapsuleCollider2D>().enabled = false;
           
            // 0.5秒後に消す
            Destroy(gameObject, 0.5f);
        }
    }
    void Touch_Sound_Torabasami()
    {
        // +++サウンド+++
        AudioSource soundPlayer = GetComponent<AudioSource>();
        if (soundPlayer != null)
        {
            // サウンドを止める
            soundPlayer.Stop();

            // サウンドを鳴らす
            soundPlayer.PlayOneShot(Trap_sound);
        }
    }
}
