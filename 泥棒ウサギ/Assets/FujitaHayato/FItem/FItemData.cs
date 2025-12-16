using UnityEngine;

//アイテムの種類
public enum ItemType
{
    kyuuri,     //きゅうり  ＝何もなし
    kyabetu,    //キャベツ  ＝体力回復
    ninjin,     //にんじん  ＝スピードアップ
    tamanegi,   //玉ねぎ    ＝スピードダウン

    sakuranbo,  //さくらんぼ＝何もなし
    ringo,      //リンゴ    ＝体力回復
    nashi,      //ナシ      ＝スピードアップ
    orange,     //オレンジ  ＝スピードダウン

    kagi,       //鍵
    nakama,     //仲間
}

public class FItemData : MonoBehaviour
{
    public ItemType type;
    public int count = 1;
    public int arrangeId = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //接触
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            //野菜---------------------------------
            if (type == ItemType.kyuuri)
            {
                //きゅうり
                ItemKeeper.haskyuuri += count;
            }
            if (type == ItemType.kyabetu)
            {
                //キャベツ
                ItemKeeper.haskyabetu += count;
            }
            if (type == ItemType.ninjin)
            {
                //にんじん
                ItemKeeper.hasninjin += count;
            }
            if (type == ItemType.tamanegi)
            {
                //玉ねぎ
                ItemKeeper.hastamanegi += count;
            }
            //果物---------------------------------
            if (type == ItemType.sakuranbo)
            {
                //さくらんぼ
                ItemKeeper.hassakuranbo += count;
            }
            if (type == ItemType.ringo)
            {
                //リンゴ
                ItemKeeper.hasringo += count;
            }
            if (type == ItemType.nashi)
            {
                //ナシ
                ItemKeeper.hasnashi += count;
            }
            //アイテム-----------------------------
            if (type == ItemType.kagi)
            {
                //鍵
                ItemKeeper.haskagi += count;
                PlayerControll player = GameObject.FindWithTag("player").GetComponent<PlayerControll>();
                player.Touch_Sound_Item();
            }
            if (type == ItemType.nakama)
            {
                //仲間
                ItemKeeper.hasnakama += count;
                PlayerControll player = GameObject.FindWithTag("player").GetComponent<PlayerControll>();
                player.Touch_Sound_Item();
            }

            gameObject.GetComponent<CircleCollider2D>().isTrigger = false;

            //アイテム取得演出
            //当たりを消す
            //gameObject.GetComponent<CircleCollider2D>().enabled = false;
            
            //アイテムのRigidbody2Dを取ってくる
            Rigidbody2D itemBody = GetComponent<Rigidbody2D>();
            //重力を戻す
            itemBody.gravityScale = 2.5f;
            //上に跳ね上げる演出
            itemBody.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
            //0.5秒後に削除
            Destroy(gameObject, 0.5f);

        }
    }
}