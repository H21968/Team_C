//N_PlayerController
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float speed = 3.0f;    // 移動スピード
    int direction = 0;            // 移動方向
    float axisH;                  // 横軸
    float axisV;                  // 縦軸
    public float angleZ = -90.0f; // 回転角度 プレイヤーの向き
    Rigidbody2D rbody;            // Rigid body2
    Animator animator;            // Animator
    bool isMoving = false;        // 移動中フラグ


    public static int player_hp = 3;           //Player HP
    public static string gameState;     //gameの状態
    bool inDamage = false;              //ダメージ中フラグ
    public int destroy_time = 1;        //プレイヤーの破壊までの時間
    public float destroy_vector_x = 0;  //プレイヤー破壊前に付与されるX軸ベクトル
    public float destroy_vector_y = 5;  //プレイヤー破壊前に付与されるY軸ベクトル
    public float zero_speed = 0;         //プレイヤーの移動停止

    // p1からp2の角度を返す
    float GetAngle(Vector2 p1, Vector2 p2)
    {
        float angle;
        if (axisH != 0 || axisV != 0)
        {
            // 移動中であれば角度を更新する
            // p1 から p2 への差分（原点を0にするため）
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;
            //アークタンジェント2関数で角度を求める
            float rad = Mathf.Atan2(dy, dx);
            //ラジアンを度に変換して返す
            angle = rad * Mathf.Rad2Deg;
        }
        else
        {
            //停止中であれば以前の角度を維持
            angle = angleZ;
        }
        return angle;
    }

  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // Rigid body2Dを得る
        animator = GetComponent<Animator>(); // Animatorを得る

        //ゲームの状態をプレイ中にする
        gameState = "playing";

        Debug.Log("start");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isMoving);

        //ゲーム中以外とダメージ中は何もしない
        if (gameState != "playing" || inDamage)
        {
            return;
        }

        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal"); // 左右キー入力
            axisV = Input.GetAxisRaw("Vertical");   // 上下キー入力
        }
        //キー入力から移動角度を求める
        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
        //移動方向から向いている方向とアニメーションを更新
        
        int dir;
        if (angleZ >= -45 && angleZ < 45)
        {
           
            //右向き
            dir = 3;
        }
        else if (angleZ >= 45 && angleZ <= 135)
        {
            //上向き
            dir = 2;
            animator.SetInteger("Direction", direction);
        }
        else if (angleZ >= 135 && angleZ <= -45)
        {
            //下向き
            dir = 0;
        }
        else
        {
            //左向き
            dir = 1;
        }
        if (dir != direction)
        {
            direction = dir;
           animator.SetInteger("Distinct", direction);
        }

    }

    void FixedUpdate()
    {

        //ゲーム中以外は何もしない
        if (gameState != "playing")
        {
            return;
        }
        if (inDamage)
        {
            //ダメージ中点滅させる
            float val = Mathf.Sin(Time.time * 50);
            if (val > 0)
            {
                //スプライトを表示
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                //スプライトを非表示
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            return; //ダメージ中は操作による移動させない
        }


        //移動速度を更新する
        rbody.linearVelocity = new Vector2(axisH, axisV).normalized * speed;
        Debug.Log(rbody.linearVelocity);
    }

    public void SetAxis(float h, float v)
    {
        axisH = h;
        axisV = v;
        if (axisH == 0 && axisV == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

    //接触
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Item")//アイテムに触れた場合の判定
        {
            ItemGet(collision.gameObject);
        }

        if (collision.gameObject.tag == "Clear")//クリアに触れた場合の判定
        {
            GameClear(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")//敵に触れた場合のダメージ判定
        {
            GetDamage(collision.gameObject);
        }
    }
    //ダメージ
   void GetDamage(GameObject enemy)
    {
        if (gameState == "playing")
        {
            player_hp--; //HPを減らす

            if (player_hp > 0)
            {
                //ダメージフラグ ON
                inDamage = true;

                //移動停止
                rbody.linearVelocity =  Vector2.zero;
                //敵キャラの反対方向にヒットバックさせる
                Vector2 hit = (transform.position - enemy.transform.position).normalized * 4f;
              
                rbody.linearVelocity = hit;
                


                axisH = 0;
                axisV = 0;

               
               
                Invoke("DamageEnd", 0.25f);
               

            }
            else
            {
                //ゲームオーバー
                GameOver();
            }
        }
    }

    void StopMove()
    {
        rbody.linearVelocity = new Vector2(zero_speed, zero_speed);//移動停止
    }
    //ダメージ終了
    void DamageEnd()
    {
        inDamage = false;//ダメージフラグOFF
        gameObject.GetComponent<SpriteRenderer>().enabled = true;//スプライトを元に戻す
        rbody.linearVelocity = new Vector2(zero_speed, zero_speed);//移動停止
    }
    //ゲームオーバー
    public  void GameOver()
    {
        gameState = "gameover";
        //ゲームオーバー演出
        GetComponent<BoxCollider2D>().enabled = false;//プレイヤーのあたりを消す
        rbody.linearVelocity = new Vector2(zero_speed, zero_speed);//移動停止
        rbody.gravityScale = 2;                   //重力を戻す 2
        rbody.linearVelocity = new Vector2(destroy_vector_x, destroy_vector_y);//(x,y)ゲームオーバー時にプレイヤーにベクトルを加える
        animator.SetBool("IsDead", true);//アニメーションの切り替え
        Destroy(gameObject, destroy_time);       //プレイヤーの破壊とそれまでの時間

    }

    //ゲームクリア 
    public void GameClear(GameObject Clear)
    {
        gameState = "gameclear";
        

        GetComponent<BoxCollider2D>().enabled = false;//プレイヤーのあたりを消す
        rbody.linearVelocity = new Vector2(zero_speed, zero_speed);//移動停止

        Destroy(gameObject, 3.0f);
    }

    //アイテムゲット
    public void ItemGet(GameObject Item)
    {
        gameState = "itemget";

        gameState = "playing";
    }


}
