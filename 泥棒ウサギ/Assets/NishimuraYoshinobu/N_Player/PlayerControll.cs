//N_PlayerController
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
using UnityEngine;

//どのシーンからでもアクセスできるクラス
public static class GameStatus
{
    //どのシーンからでもアクセスできる変数
    public static int player_hp = 3;
    public static float speed = 3.0f;
    public static bool active_task = true;
    public static bool player_spawn = true;
}

public class PlayerControll : MonoBehaviour
{
    public static bool axis = false;//プレイヤーの移動に制限
    public float speed = 3.0f;    // 移動スピード
    int direction = 0;            // 移動方向
    float axisH;                  // 横軸
    float axisV;                  // 縦軸
    public float angleZ = -90.0f; // 回転角度 プレイヤーの向き
    Rigidbody2D rbody;            // Rigid body2
    Animator animator;            // Animator
    bool isMoving = false;        // 移動中フラグ

    public int player_hp = 3;           //Player HP
    public static string gameState;     //gameの状態
    bool inDamage = false;              //ダメージ中フラグ
    public int destroy_time = 1;        //プレイヤーの破壊までの時間
    public float destroy_vector_x = 0;  //プレイヤー破壊前に付与されるX軸ベクトル
    public float destroy_vector_y = 5;  //プレイヤー破壊前に付与されるY軸ベクトル
    public float zero_speed = 0;         //プレイヤーの移動停止

    // +++ サウンド追加
    public AudioClip Player_Sound_Item_Get;          //アイテムに触れたときのSE
    public AudioClip Player_Sound_Item_Speed_Down;   //アイテムに触れたときのSE
    public AudioClip Player_Sound_Item_Speed_UP;     //アイテムに触れたときのSE
    public AudioClip Player_Sound_Item_HP_UP;        //アイテムに触れたときのSE
    public AudioClip Player_Sound_Enemy_Touch;       //敵に触れたときのSE
    public AudioClip Player_Sound_MOVE;       //動く時のSE

    // +++  オーディオ
    //public AudioSource Player_Sound_MOVE_Audio;
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

            angle = Mathf.Round(angle);
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
        //playerの中に静的を入れる
        speed = GameStatus.speed;
        player_hp = GameStatus.player_hp;



        rbody = GetComponent<Rigidbody2D>(); // Rigid body2Dを得る
        animator = GetComponent<Animator>(); // Animatorを得る

        //ゲームの状態をプレイ中にする
        gameState = "playing";

        Debug.Log("start");
        //if (Player_Sound_MOVE_Audio != null)
        //{
        //    Player_Sound_MOVE_Audio.clip = Player_Sound_MOVE;
        //    Player_Sound_MOVE_Audio.loop = true; //ループ設定

        //}
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム中以外とダメージ中は何もしない
        if (gameState != "playing" || inDamage)
        {
            return;
        }
        //if (axis == true)
        {
            axisH = Input.GetAxisRaw("Horizontal");  // 左右キー入力
            axisV = Input.GetAxisRaw("Vertical");   // 上下キー入力
        }
        isMoving = axisH != 0 || axisV != 0;
        animator.SetBool("IsMoving", axisH != 0 || axisV != 0);

        if (isMoving)
        {
            Player_Sound_Moving();
        }
       
        //キー入力から移動角度を求める
        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
        //移動方向から向いている方向とアニメーションを更新
        angleZ = GetAngle(fromPt, toPt);
        int dir= direction;

        if (angleZ >= -45 && angleZ < 45)
        {

            //右向き
            dir = 3;
        }
        else if (angleZ >= 45 && angleZ <= 135)
        {
            //上向き
            dir = 2;

        }
        else if (angleZ >= -135 && angleZ <= -45)
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


        //if(gameState=="gameclear"&&gameState=="gameover")
        //{

        //}
       
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
        //Debug.Log(rbody.linearVelocity);
    }

    //public void SetAxis(float h, float v)
    //{
    //    axisH = h;
    //    axisV = v;
    //    if (axisH == 0 && axisV == 0)
    //    {
    //        isMoving = false;
    //    }
    //    else
    //    {
    //        isMoving = true;
    //    }
    //}

    //接触
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Item")//アイテムに触れた場合の判定
        {
           
            ItemGet(collision.gameObject);          //何もなし
            Destroy(collision.gameObject);
         }
        if (collision.gameObject.tag == "SpeedUP")
        {
            ItemGetSpeedUP(collision.gameObject);   //スピードアップ
           Destroy(collision.gameObject);
         }
        if (collision.gameObject.tag == "SpeedDown")
        {
            ItemGetSpeedDown(collision.gameObject); //スピードダウン
            Destroy(collision.gameObject);
       }
        if (collision.gameObject.tag == "ItemHpUP")
        {
            ItemGetHP(collision.gameObject);   //HP回復
            Destroy(collision.gameObject);
         }

        if (collision.gameObject.tag == "Clear")//クリアに触れた場合の判定
        {
            GameClear(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")//敵に触れた場合のダメージ判定
        {
            GetDamage2(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy2")//トラップに触れた場合のダメージ判定
        {
            GetDamage(collision.gameObject);
        }
        if (collision.gameObject.tag == "Untagged")
        {
            //Touch_Sound_Item();
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("SpeedUP"))
    //    {
    //        ItemGetSpeedUP(collision.gameObject);
    //        Destroy(collision.gameObject);
    //    }
    //}

    //ダメージ
    void GetDamage(GameObject enemy)
    {
        if (gameState == "playing")
        {
            player_hp--; //HPを減らす
            GameStatus.player_hp = player_hp;
            Touch_Sound_Enemy();//ダメージサウンド
            if (player_hp > 0)
            {
                //ダメージフラグ ON
                inDamage = true;
                //rbody.simulated = false;
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

    void GetDamage2(GameObject enemy2)
    {
        if (gameState == "playing")
        {
            player_hp--; //HPを減らす
            GameStatus.player_hp = player_hp;
            Touch_Sound_Enemy();//ダメージサウンド
            if (player_hp > 0)
            {
                //ダメージフラグ ON
                inDamage = true;
                //rbody.simulated = false;
                //移動停止
                rbody.linearVelocity = Vector2.zero;
                //敵キャラの反対方向にヒットバックさせる
                Vector2 hit = (transform.position - enemy2.transform.position).normalized * 4f;

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

    //ダメージ終了
    void DamageEnd()
    {
        inDamage = false;//ダメージフラグOFF
        //rbody.simulated = true;
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

        Destroy(gameObject, 0.5f);
    }

    ////アイテムゲット
    //public void ItemGet(GameObject Item)
    //{
    //    gameState = "itemget";

    //    gameState = "playing";
    //}

    public void ItemGet(GameObject item)
    {
        // itemを取った 処理
        Touch_Sound_Item();      //アイテムに触れたときSEを再生
        Debug.Log("アイテムを取った");

        // FItemID を取得
        FItemID itemData = item.GetComponent<FItemID>();
        if (itemData == null)
        {
            Debug.LogError("FItemID がありません。");
            return;
        }

        // プレイヤーのインベントリへ追加
        FPlayerInventory inventory = GameObject.FindWithTag("player").GetComponent<FPlayerInventory>();
        inventory.AddItem(itemData.itemId);


        // アイテムを消す
        Destroy(item);

        // 状態変更など（任意）
        gameState = "itemget";
        gameState = "playing";
    }

    //HP回復
    public void ItemGetHP(GameObject item)
    {
   // HP UP
    player_hp += 1;
        Touch_Sound_Item_HP_UP();                     //アイテムに触れたときSEを再生
        GameStatus.player_hp = player_hp;
        Debug.Log("HP UP! 現在のHP：" + player_hp);

    // アイテムID取得
    FItemID itemData = item.GetComponent<FItemID>();
    if (itemData == null)
    {
        Debug.LogError("FItemID がありません。");
        return;
    }

    // インベントリに記録（超重要）
    FPlayerInventory inventory = GameObject.FindWithTag("player").GetComponent<FPlayerInventory>();
    inventory.AddItem(itemData.itemId);

    // アイテムを消す
    Destroy(item);
    }
    ////スピードアップ
    //public void ItemGetSpeedUP(GameObject Item)
    //{
    //    speed += 1;
    //    Debug.Log("Speed UP! 現在のスピード：" + speed);
    //}

    public void ItemGetSpeedUP(GameObject item)
    {
        // Speed UP 処理
        speed += 1;
        Debug.Log("Speed UP! 現在のスピード：" + speed);
        Touch_Sound_Item_Speed_UP();                     //アイテムに触れたときSEを再生
        // FItemID を取得
        FItemID itemData = item.GetComponent<FItemID>();
        if (itemData == null)
        {
            Debug.LogError("FItemID がありません。");
            return;
        }

        // プレイヤーのインベントリへ追加
        FPlayerInventory inventory = GameObject.FindWithTag("player").GetComponent<FPlayerInventory>();
        inventory.AddItem(itemData.itemId);

        // アイテムを消す
        Destroy(item);
    }

    //スピードダウン
    public void ItemGetSpeedDown(GameObject item)
    {
        // Speed UP 処理
        speed -= 1;
        Touch_Sound_Item_Speed_Down();                     //アイテムに触れたときSEを再生
        Debug.Log("Speed DOWN! 現在のスピード：" + speed);

        // FItemID を取得
        FItemID itemData = item.GetComponent<FItemID>();
        if (itemData == null)
        {
            Debug.LogError("FItemID がありません。");
            return;
        }

        // プレイヤーのインベントリへ追加
        FPlayerInventory inventory = GameObject.FindWithTag("player").GetComponent<FPlayerInventory>();
        inventory.AddItem(itemData.itemId);

        // アイテムを消す
        Destroy(item);
    }
    public void Touch_Sound_Item()
    {
        // +++サウンド
        AudioSource soundPlayer = GetComponent<AudioSource>();
        if (soundPlayer != null)
        {
            //サウンドを止める
            soundPlayer.Stop();

            //サウンドを鳴らす
            soundPlayer.PlayOneShot(Player_Sound_Item_Get);
        }
    }

    void Touch_Sound_Enemy()
    {
        AudioSource soundPlayer = GetComponent<AudioSource>();
        if (soundPlayer != null)
        {
            //サウンドを止める
            soundPlayer.Stop();

            //サウンドを鳴らす
            soundPlayer.PlayOneShot(Player_Sound_Enemy_Touch);
        }
    }
    void Touch_Sound_Item_Speed_UP()
    {
        AudioSource soundPlayer = GetComponent<AudioSource>();
        if (soundPlayer != null)
        {
            //サウンドを止める
            soundPlayer.Stop();

            //サウンドを鳴らす
            soundPlayer.PlayOneShot(Player_Sound_Item_Speed_UP);
        }
    }
    void Touch_Sound_Item_Speed_Down()
    {
        AudioSource soundPlayer = GetComponent<AudioSource>();
        if (soundPlayer != null)
        {
            //サウンドを止める
            soundPlayer.Stop();

            //サウンドを鳴らす
            soundPlayer.PlayOneShot(Player_Sound_Item_Speed_Down);
        }
    }
    void Touch_Sound_Item_HP_UP()
    {
        AudioSource soundPlayer = GetComponent<AudioSource>();
        if (soundPlayer != null)
        {
            //サウンドを止める
            soundPlayer.Stop();

            //サウンドを鳴らす
            soundPlayer.PlayOneShot(Player_Sound_Item_HP_UP);
        }
    }
    void Player_Sound_Moving()
    {
        AudioSource soundPlayer = GetComponent<AudioSource>();
        if (soundPlayer != null)
        {
            if (!soundPlayer.isPlaying)// 再生中でなければ鳴らす
            {
                //サウンドを鳴らす
                soundPlayer.PlayOneShot(Player_Sound_MOVE);
            }        
        }
    }
  
}
