using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class N_Human_Behavior : MonoBehaviour
{
    public float Human_speed = 2.2f;//速度
    public int N_Human_HP = 2;//HP
    bool Human_isActive = false;//アクティブ
    float Human_rectionDistance = 5.0f;//プレイヤーの感知
    Rigidbody2D rbody;            // Rigid body2
    Animator animator;            // Animator
    bool isActive = false;        // 移動中フラグ
    public float Human1_damage = 3;//プレイヤーに与えるダメージ量

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

        //playerのゲームオブジェクトを得る
        GameObject player = GameObject.FindGameObjectWithTag("player");

        if (player != null)
        {
            //プレイヤーをの距離チェックとアクティブ化
            float dist = Vector2.Distance(transform.position, player.transform.position);
            if (dist < Human_rectionDistance)
            {
                isActive = true; //アクティブにする
                animator.SetBool("isActive", isActive);
               
                //プレイヤーの方向に向かう
                Vector2 dir = (player.transform.position-transform.position).normalized; 
                move = dir * Human_speed; 

                float rad  = Mathf.Atan2(dir.y, dir.x);
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
            }
        }
        else
        {
            isActive = false;
        }
        rbody.linearVelocity = move;
    }
}
