using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torabasami : MonoBehaviour//クラス
{
    //ヒットポイント
    public int torabasami_hp = 10;//このエネミーの㏋ 10
    public float damage;//プレイヤーに与えるダメージ量

    public float rectionDistance = 3.0f;

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
        
        //playerのゲームオブジェクトを得る
        GameObject player = GameObject.FindGameObjectWithTag("player");

        if (player != null )
        {
            //プレイヤーをの距離チェックとアクティブ化
            float dist = Vector2.Distance(transform.position, player.transform.position);
            if (dist < rectionDistance)
            {
                isActive = true; //アクティブにする
            }
            else
            {
                isActive = false;//非アクティブにする
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
            Player_HP player_hp = collision.gameObject.GetComponent<Player_HP>();

            if (player_hp != null)
            {
                player_hp.TakeDamage((int)damage);
                Debug.Log("プレイヤーがダメージを受ける");
            }
        }
    }
    public void TakeDamage(int amount)
    {
        torabasami_hp -= amount;

        Debug.Log("トラバサミ解除");
        if(torabasami_hp <= 0)
        {
            //破壊処理
            //あたりを消す
            GetComponent<CircleCollider2D>().enabled = false;
            //0.5秒後に消す
            Destroy(gameObject, 0.5f);
        }
    }
}
