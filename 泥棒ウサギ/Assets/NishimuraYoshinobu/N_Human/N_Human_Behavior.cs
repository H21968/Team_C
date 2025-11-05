using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
public class N_Human_Behavior : MonoBehaviour
{
    public float Human_speed = 2.2f;//速度
    public int N_Human_HP = 2;//HP
   // bool Human_isActive = false;//アクティブ
    float Human_rectionDistance = 5.0f;//プレイヤーの感知
    float N_Human_interval = 1f; //うろつく時の間隔
    float wabder_Radius = 5f;    //うろつく範囲
    float Human_Stop_Timer = 0;//止まる時間
    float Human_Move_Timer = 0;//動く時間
    Rigidbody2D rbody;            // Rigid body2
    Animator animator;            // Animator
    bool isActive = false;        // 移動中フラグ
    bool isRunning = false;       //戻るフラグ
    public float Human1_damage = 3;//プレイヤーに与えるダメージ量

    Vector3 target_Position;//ランダム移動目的地
    Vector3 Move_restriction;//移動制限

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // Rigid body2Dを得る
        animator = GetComponent<Animator>(); // Animatorを得る
        Move_restriction = transform.position;//出現位置を記録

        SetNewTarget();//最初に向かう位置
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
            if (isActive && dist >= Human_rectionDistance && !isRunning) 
            {
                isActive = false;
                isRunning = true;
                animator.SetBool("isActive", false);
            }
        }
        isActive = false;
        animator.SetBool("isActive", false);
        Wander();
    }
    void Wander()
    {
        if (isRunning)
        {//戻るとき
            rbody.linearVelocity = (Move_restriction - transform.position).normalized * Human_speed;
            if (Vector3.Distance(transform.position, Move_restriction) < 0.1f)
            {
                isRunning = false;
                rbody.linearVelocity = Vector2.zero;
                SetNewTarget();
            }
            return;
        }
        if (Human_Stop_Timer > 0)//止まる時間
        {
            Human_Stop_Timer -= Time.deltaTime;
            rbody.linearVelocity = Vector2.zero;
            return;
        }


        //目的地に向かう うろつき
        Human_Move_Timer += Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target_Position, Human_speed * Time.deltaTime);
        
        //現在位置がターゲット位置が近いなら新しい位置を設定
        if (Vector3.Distance(transform.position, target_Position) < N_Human_interval || Human_Move_Timer >= N_Human_interval)
        {
            Human_Move_Timer = 0;
            Human_Stop_Timer = Random.Range(0.5f, N_Human_interval);
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
}
