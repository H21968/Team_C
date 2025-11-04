using UnityEngine;

public class FOri : MonoBehaviour
{
    public Sprite openImage;        //開いた画像
    public GameObject itemPrefab;   //出てくるアイテムのプレハブ
    public bool isClosed = true;    //ture=閉まっている false=開いている
    public int arrangeId = 0;       //配置の識別に使う

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isClosed && collision.gameObject.tag == "player")
        {
            if (ItemKeeper.haskagi >= 1)
            {
                //箱が閉まっている状態でプレイヤーに接触
                GetComponent<SpriteRenderer>().sprite = openImage;
                isClosed = false;//開いている状態にする
                if (itemPrefab != null)
                {
                    //アイテムをプレハブから作る
                    Instantiate(itemPrefab, transform.position, Quaternion.identity);
                }
            }
        }
    }

}
