using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class N_Human_Behavior : MonoBehaviour
{
    public float Human_speed = 1000.0f;//速度
    public int N_Human_HP = 2;//HP
    bool Human_isActive = false;//アクティブ
    float Human_rectionDistance = 5.0f;//プレイヤーの感知
    Rigidbody2D rbody;            // Rigid body2
    Animator animator;            // Animator
    //bool isMoving = false;        // 移動中フラグ
    float axisH;//横
    float axisV;//縦
    public float damage;//プレイヤーに与えるダメージ量

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // Rigid body2Dを得る
        animator = GetComponent<Animator>(); // Animatorを得る
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = Vector2.zero; 

        axisH = 0;
        axisV = 0;
        //playerのゲームオブジェクトを得る
        GameObject player = GameObject.FindGameObjectWithTag("player");

        if (player != null)
        {
            //プレイヤーをの距離チェックとアクティブ化
            float dist = Vector2.Distance(transform.position, player.transform.position);
            if (dist < Human_rectionDistance)
            {
                Human_isActive = true; //アクティブにする
              
               // animator.SetBool("isActive", Human_isActive);
                float dx = player.transform.position.x - transform.position.x;
                float dy = player.transform.position.y - transform.position.y;

                Vector2 dir = (player.transform.position-transform.position).normalized; 
                move = dir * Human_speed; 

                float rad  = Mathf.Atan2(axisV, axisH);
                float angle = rad* Mathf.Deg2Rad;

                     //移動角度でアニメーションを変更する
                     int  direction ;
                     if (angle >= -45 && angle < 45)
                    {
                        //右向き
                        direction = 3;
                    }
                    else if (angle >= 45 && angle <= 135)
                    {
                        //上向き
                        direction = 2;
                    }
                    else if (angle >= -135 && angle <= -45)
                    {
                        //下向き
                        direction = 0;
                    }
                    else
                    {
                        //左向き
                        direction = 1;
                    }
                   // animator.SetInteger("Direction", direction);
                    //ベクトル
                    axisH = Mathf.Cos(rad)*Human_speed;
            }
        }
        else
        {
            Human_isActive = false;
        }
        rbody.linearVelocity = move;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーダメージ
        if (collision.gameObject.tag == "player")
        {

            PlayerControll player = collision.gameObject.GetComponent<PlayerControll>();
            if (player != null)
            {
                PlayerControll.player_hp -= ((int)damage);
                Debug.Log("プレイヤーがダメージを受ける");

                if (PlayerControll.player_hp <= 0)

                {
                    player.GameOver();
                    Debug.Log("プレイヤー死亡");
                }
            }
        }
    }
}
