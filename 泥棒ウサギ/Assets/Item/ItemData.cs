using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテムの種類
public enum ItemType
{
    arrow,        //矢
    GoldKey,      //金の鍵
    SilverKey,    //銀の鍵
    Life,         //ライフ 
    Light,        //ライト
}

public class ItemData : MonoBehaviour
{
    public ItemType type;
    public int count = 1;
    public int arrangeId = 0;

    //
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //接触
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            if(type==ItemType.GoldKey)
            {
                //金の鍵
                ItemKeeper.hasGoldKeys += count;
            }
            else if(type==ItemType.SilverKey)
            {
                //銀の鍵
                ItemKeeper.hasSilverKeys += count;
            }
            else if (type == ItemType.arrow)
            {
                //矢
               // ArrowShoot shoot = collision.gameObject.GetComponent<ArrowShoot>();
                //ItemKeeper.hasArrows += count;
            }
            else if(type==ItemType.Life)
            {
                //ライフ
                if (PlayerControll.player_hp<3)
                {
                    //HPが3以下の場合加算する
                    PlayerControll.player_hp++;
                }
            }
            else if (type == ItemType.Light)
            {
                //ライト
                ItemKeeper.hasLights += count;
                GameObject.FindObjectOfType<PlayerLightController>().LightUpdate();
            }
            //アイテム取得演出
            //あたりを消す
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            //アイテムのRigidbody2Dを取ってくる
            Rigidbody2D itemBody = GetComponent<Rigidbody2D>();
            //重力を戻す
            itemBody.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
            //0.5秒後に削除
            Destroy(gameObject, 0.5f);
        }
    }
}
