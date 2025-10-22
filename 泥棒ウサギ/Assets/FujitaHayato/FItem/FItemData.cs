using UnityEngine;

//アイテムの種類
public enum ItemType
{
    kyuuri, //きゅうり
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
            if (type == ItemType.kyuuri)
            {
                //きゅうり
                ItemKeeper.haskyuuri += count;
            }

            //アイテム取得演出
            //当たりを消す
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
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