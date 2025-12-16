using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
//using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class N_Dog1 : MonoBehaviour
{
    public float Dog_speed = 1.3f;//速度
    public int N_Dog_HP = 2;//HP
    // bool Human_isActive = false;//アクティブ
    float Human_rectionDistance = 4.0f;//プレイヤーの感知
    float N_Player_Separated = 10.0f;//プレイヤーが離れた
    float N_Human_interval = 5f; //うろつく時の間隔
    float wabder_Radius = 7f;    //うろつく範囲
    float Dog_Stop_Timer = 0;//止まる時間
    float Dog_Move_Timer = 0;//動く時間
    Rigidbody2D rbody;            // Rigid body2
    Animator animator;            // Animator
    bool Dog_isActive = false;       // 移動中フラグ
    bool isSleep = false;         // 睡眠中のフラグ
    bool isActive = false;        // 移動中フラグ
    bool isRunning = false;       //戻るフラグ
    public float Dog1_damage = 1;//プレイヤーに与えるダメージ量

    float TargetReachDistance = 0.3f;   // 目的地に到達したとみなす距離
    float WanderMoveDuration = 1.5f;    // 動き続ける最大時間

    Vector3 target_Position;//ランダム移動目的地
    Vector3 Move_restriction;//移動制限

    //public AudioClip Player_Sound_Enemy_Approach;       //敵に接近した時のBGM

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // Rigid body2Dを得る
        animator = GetComponent<Animator>(); // Animatorを得る
        Move_restriction = transform.position;//出現位置を記録

        SetNewTarget();//最初に向かう位置

        //最初は寝ていて動かない
        rbody.linearVelocity = Vector2.zero;
        isSleep = true;
        animator.SetBool("Sleep", isSleep);
        Sleeping();
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
            //プレイヤーが近づけば起きる
            if (isSleep == true)
            {
                if (dist < Human_rectionDistance)
                {
                    // +++サウンド

                    isSleep = false;
                    animator.SetBool("Sleep", isSleep);
                    return;
                }
                Sleeping();
                return;
            }
            //プレイヤーが離れれば眠る&&戻るときは眠らない
            if (isSleep == false && isRunning == false)
            {
                if (dist > N_Player_Separated)
                {
                    isSleep = true;
                    Sleeping();
                    return;
                }
            }
            if (dist < Human_rectionDistance)
            {

                isSleep = false;
                animator.SetBool("Sleep", isSleep);
                Dog_isActive = true;
                isActive = true; //アクティブにする
                animator.SetBool("isActive", isActive);
                //プレイヤーの方向に向かう
                Vector2 dir = (player.transform.position - transform.position).normalized;
                move = dir * Dog_speed;

                rbody.linearVelocity = move;

                float rad = Mathf.Atan2(dir.y, dir.x);
                float angle = rad * Mathf.Rad2Deg;

                angle = Mathf.Round(angle);

                //移動角度でアニメーションを変更する
                int Distinct;
                if (angle >= -45 && angle <= 45)
                {
                    //右向き
                    Distinct = 3;
                }
                else if (angle >= 45 && angle < 135)
                {
                    //上向き
                    Distinct = 2;
                }
                else if (angle >= -135 && angle < -45)
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
            if (Dog_isActive && dist >= Human_rectionDistance && !isRunning)
            {
                // 帰還モード開始
                Dog_isActive = false;
                isActive = false;
                isRunning = true;
                animator.SetBool("isActive", false);
            }
        }
        //うろつき処理
        Wander();
    }

    void Wander()
    {
        if (isRunning)
        {

            // 移動中はアニメON
            isActive = true;
            animator.SetBool("isActive", isActive);

            // 元の位置の方向
            Vector2 dir = (Move_restriction - transform.position).normalized;

            // 元の位置に向けて移動
            rbody.linearVelocity = dir * Dog_speed;

            // 移動方向のアニメ更新
            Move_Animation(dir);

            if (Vector3.Distance(transform.position, Move_restriction) < 0.5f)
            {
                // 帰還完了
                isRunning = false;
                //戻るとき

                // 停止
                rbody.linearVelocity = Vector2.zero;

                //アニメOFF
                isActive = false;
                animator.SetBool("isActive", false);

                // 次のうろつき目標を設定
                SetNewTarget();
            }
            return;
        }

        {
            if (!isRunning && Dog_Stop_Timer > 0)//止まる時間
            {
                //停止時間カウント
                Dog_Stop_Timer -= Time.deltaTime;

                //完全停止
                rbody.linearVelocity = Vector2.zero;

                //アニメOFF
                isActive = false;
                animator.SetBool("isActive", false);
                return;
            }
        }
        //目的地に向かう うろつき

        // 動いている時間のカウント
        Dog_Move_Timer += Time.deltaTime;

        //目標への移動ベクトル
        Vector2 dirWander = (target_Position - transform.position).normalized;

        // 移動中はアニメON
        isActive = true;
        animator.SetBool("isActive", isActive);

        // 移動方向のアニメ更新
        Move_Animation(dirWander);

        //現在位置から目標位置へ向けて移動
        transform.position = Vector3.MoveTowards(transform.position, target_Position, Dog_speed * Time.deltaTime);
        //rbody.linearVelocity = dirWander * Dog_speed;

        //現在位置がターゲット位置が近いなら新しい位置を設定
        if (Vector3.Distance(transform.position, target_Position) < TargetReachDistance || Dog_Move_Timer >= WanderMoveDuration)
        {
            // 移動時間リセット
            Dog_Move_Timer = 0;
            //ランダム停止時間セット
            Dog_Stop_Timer = Random.Range(0.5f, N_Human_interval);
            // 新ターゲット決定
            SetNewTarget();

        }
    }

    void SetNewTarget()
    {
        //ランダム方向生成
        {
            //ランダムな方向を求める、範囲内を動く
            Vector2 randomDirection = Random.insideUnitCircle * wabder_Radius;
            //新しい場所へ
            target_Position = Move_restriction + (Vector3)randomDirection;
        }
    }
    void Sleeping()
    {
        //寝ているときは動かない
        if (isSleep == true)
        {
            rbody.linearVelocity = Vector2.zero;
            animator.SetBool("Sleep", isSleep);
            // +++サウンド停止



            return;
        }
    }
    void Move_Animation(Vector2 dir)
    {

        float rad = Mathf.Atan2(dir.y, dir.x);
        float angle2 = rad * Mathf.Rad2Deg;

        angle2 = Mathf.Round(angle2);

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

}
