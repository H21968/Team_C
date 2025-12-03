using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
//using UnityEditor.VersionControl;
using UnityEngine;
public class N_Human_Behavior : MonoBehaviour
{
    public float Human_speed = 2.2f;//速度
    public int N_Human_HP = 2;//HP
    bool Human_isActive = false;//アクティブ
    float Human_rectionDistance = 5.0f;//プレイヤーの感知
    float N_Human_interval = 1f; //うろつく時の間隔
    float wabder_Radius = 5f;    //うろつく範囲
    float Human_Stop_Timer = 0;//止まる時間
    float Human_Move_Timer = 0;//動く時間
    Rigidbody2D rbody;            // Rigid body2
    Animator animator;            // Animator
    bool isActive = false;        // 移動中フラグ
    bool isRunning = false;       //戻るフラグ
    public float Human1_damage = 1;//プレイヤーに与えるダメージ量

    bool isbgm = false;//人間停止

    float TargetReachDistance = 0.3f;   // 目的地に到達したとみなす距離
    float WanderMoveDuration = 1.5f;    // 動き続ける最大時間

    Vector3 target_Position;//ランダム移動目的地
    Vector3 Move_restriction;//移動制限

    public AudioClip Player_Sound_Enemy_Approach;       //敵に接近した時のBGM

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // Rigid body2Dを得る
        animator = GetComponent<Animator>(); // Animatorを得る
        Move_restriction = transform.position;//出現位置を記録

        SetNewTarget();//最初に向かう位置
        isbgm = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = Vector2.zero; 
        //playerのゲームオブジェクトを得る
        GameObject player = GameObject.FindGameObjectWithTag("player"); 
        if (player == null)
        {
          return; 
        }
        if (player != null)
        {
            //プレイヤーをの距離チェックとアクティブ化
            float dist = Vector2.Distance(transform.position, player.transform.position);
            if (dist < Human_rectionDistance)
            {
                
                if (isbgm == true)
                {
                    // +++サウンド
                    N_SoundManager.N_Instance.N_Play_BGM(Player_Sound_Enemy_Approach);
                    isbgm = false;
                }
                Human_isActive = true;
               isActive = true; //アクティブにする
                animator.SetBool("isActive", isActive);

                //プレイヤーの方向に向かう
                Vector2 dir = (player.transform.position - transform.position).normalized;
                move = dir * Human_speed;

                rbody.linearVelocity = move;

                float rad = Mathf.Atan2(dir.y, dir.x);
                float angle = rad * Mathf.Rad2Deg;

                //移動角度でアニメーションを変更する
                int Distinct;
                if (angle >= -45 && angle < 45)
                {
                    //右向き
                    Distinct = 3;
                }
                else if (angle >= 45 && angle <= 135)
                {
                    //上向き
                    Distinct = 2;
                }
                else if (angle >= -135 && angle <= -45)
                {
                    //下向き
                    Distinct = 0;
                }
                else
                {
                    //左向き
                    Distinct = 1;
                }
                animator.SetInteger("Distinct", Distinct);
                return;
            }
            if (Human_isActive && dist >= Human_rectionDistance && !isRunning) 
            {
                Human_isActive = false;
                isActive = false;
                // 帰還モード開始
                isRunning = true;
                animator.SetBool("isActive", false);
            }
        }
        //うろつき処理
        Wander();
    }
    void Wander()
    {
        // 元の位置へ戻る
        if (isRunning)
        {   //戻るとき
            //アニメーション戻るときに移動を反映----------------
            // 元の位置の方向
            Vector2 dir = (Move_restriction - transform.position).normalized;
            // 元の位置に向けて移動
            rbody.linearVelocity = dir * Human_speed;
            // 移動中はアニメON
            isActive = true;
            animator.SetBool("isActive", isActive);
            // 移動方向のアニメ更新
            Move_Animation(dir);
            //-------------------------------------------------
            if (Vector3.Distance(transform.position, Move_restriction) < 0.5f)
            {
                // 帰還完了
                isRunning = false;
                // 停止
                rbody.linearVelocity = Vector2.zero;
                N_BGM();
                isActive = false;
                animator.SetBool("isActive", false);
                // 次のうろつき目標を設定
                SetNewTarget();
            }
            return;
        }
        if (Human_Stop_Timer > 0)//止まる時間
        {
            //アニメOFF
            isActive = false;
            animator.SetBool("isActive", false);
            //停止時間カウント
            Human_Stop_Timer -= Time.deltaTime;
            //完全停止
            rbody.linearVelocity = Vector2.zero;
            
            return;
        }
        //------------目的地に向かう うろつき------------------

        // 動いている時間のカウント
        Human_Move_Timer += Time.deltaTime;
        //目標への移動ベクトル
        Vector2 NewTargetdir = (target_Position - transform.position).normalized;

        // 移動中はアニメON
        isActive = true;
        animator.SetBool("isActive", isActive);

        // 移動方向のアニメ更新
        Move_Animation(NewTargetdir);

        //現在位置から目標位置へ向けて移動
        rbody.linearVelocity = NewTargetdir * Human_speed;
        //現在位置がターゲット位置が近いなら新しい位置を設定
        if (Vector3.Distance(transform.position, target_Position) < TargetReachDistance || Human_Move_Timer >= WanderMoveDuration)
        {
            
            // 移動時間リセット
            Human_Move_Timer = 0;
            //ランダム停止時間セット
           Human_Stop_Timer = Random.Range(0.5f, N_Human_interval);
            // 新ターゲット決定
            SetNewTarget();
        }
    }

    void SetNewTarget()
    {
       //ランダムな方向を求める、範囲内を動く
        Vector2 randomDirection = Random.insideUnitCircle * wabder_Radius;
       //新しい場所へ
       target_Position = Move_restriction + (Vector3)randomDirection;

    }
    void Move_Animation(Vector2 dir)
    {
        //このキャラクターが動いた方向にアニメーションを再生するための角度を取得するのとアニメションの再生
        float rad = Mathf.Atan2(dir.y, dir.x);
        float angle2 = rad * Mathf.Rad2Deg;

        int Distinct2;
        if (angle2 >= -45 && angle2 < 45)
        {
            //右向き
            Distinct2 = 3;
        }
        else if (angle2 >= 45 && angle2 <= 135)
        {
            //上向き
            Distinct2 = 2;
        }
        else if (angle2 >= -135 && angle2 <= -45)
        {
            //下向き
            Distinct2 = 0;
        }
        else
        {
            //左向き
            Distinct2 = 1;
        }
        animator.SetInteger("Distinct", Distinct2);
    }
    void N_BGM()
    {
        // +++サウンド停止
        N_SoundManager.N_Instance.N_BGM_Stop();
        isbgm = true;
    }
}
