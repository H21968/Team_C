using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torabasami : MonoBehaviour
{
    //ヒットポイント
    public int torabasami_hp = 10;//このエネミーの㏋は10

    //移動スピード
    public float torabasami_speed = 0.0f;//反応距離
    public float torabasami_rectionDistance = 0.0f;

    float axisH;//横軸値(-1.0～0.0～1.0)
    float axisV;//縦軸値(-1.0～0.0～1.0)
    Rigidbody2D rbody;// Rigidbody2D
    Animation animator;//Animation
    bool isActive = false;//アクティブフラグ
    public int arrangeId = 0;//配置の識別に使う

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rbody = GetComponent<Rigidbody2D>();//Rigidbody2Dを得る
      animator = GetComponent<Animation>();//Animationを得る
    }

    // Update is called once per frame
    void Update()
    {
        //初期値初期化
        axisH = 0;
        axisV = 0;
        //playerのゲームオブジェクトを得る
        GameObject player = GameObject.FindGameObjectWithTag("player");
        if (player != null )
        {
            //プレイヤーをの距離チェック
            float dist = Vector2.Distance(transform.position, player.transform.position);
            if (dist < torabasami_rectionDistance)
            {
                isActive = true; //アクティブにする
            }
            else
            {
                isActive = false;//非アクティブにする
            }
            //アニメーションの切り替え
              //animator.SetBool("IsActive", isActive);
            if (isActive)
            {
               // animator.SetBool("IsActive", isActive);

                //プレイヤーへの角度を求める
                float dx = player.transform.position.x - transform.position.x;
                float dy = player.transform.position.y - transform.position.y;
                float rad = Mathf.Atan2(dy, dx);
                float angle = rad * Mathf.Rad2Deg;
                //移動角度でアニメーションを変える
                int direction;
                if (angle > -45.0f && angle <= 45.0f)
                {
                    direction = 3;//右向き
                }
                else if (angle > 45.0f && angle <= 135.0f)
                {
                    direction = 2;//上向き
                }
                else if (angle > -135.0f && angle <= -45.0f)
                {
                    direction = 2;//下向き
                }
                else
                {
                    direction = 1;//左向き
                }
              //  animator.SetInteger("direction)", direction);
                //移動するベクトルを作る
                axisH = Mathf.Cos(rad) * torabasami_speed;
                axisV = Mathf.Sin(rad) * torabasami_speed;
            }
        }
        else
        {
            isActive = false;
        }
    }
    private void FixedUpdate()
    {
        if (isActive && torabasami_hp > 0)
        {
            //移動
            rbody.linearVelocity = new Vector2(axisV, axisH).normalized; 
        }
        else
        {
            rbody.linearVelocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Arrow")
        {
            //ダメージ
            torabasami_hp--;
            if (torabasami_hp <= 0)
            {
                //死亡
                //あたりを消す
                GetComponent<CircleCollider2D>().enabled = false;
                //移動停止
                rbody.linearVelocity = Vector2.zero;
                //アニメーションを切り替える
             //   animator.SetBool("IsDead",true);
                //0.5秒後に消す
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
