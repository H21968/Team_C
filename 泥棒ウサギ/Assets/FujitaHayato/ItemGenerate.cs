using UnityEngine;

public class ItemGenerate : MonoBehaviour
{
    public GameObject[] itemPrefabs;   // アイテム本体
    public Transform[] popPoints;      // 生成位置

    // プレイヤーの所持状態管理スクリプト
    private FPlayerInventory playerInventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // プレイヤーのアイテム所持状況を取得
        playerInventory = GameObject.FindWithTag("player").GetComponent<FPlayerInventory>();

        if (playerInventory == null)
        {
            Debug.LogError("FPlayerInventory が見つかりません。Player タグを確認してください。");
            return;
        }
        //// 所持状況をチェックして生成するか判断する、生成位置はアイテムポップ位置

        // 所持状況をチェックして生成するループに置き換え
        for (int i = 0; i < popPoints.Length; i++)
        {
            int itemIndex = i % itemPrefabs.Length;

            // アイテムの Item スクリプトを取得
            FItemID item = itemPrefabs[itemIndex].GetComponent<FItemID>();
            if (item == null)
            {
                Debug.LogError(itemPrefabs[itemIndex].name + " に Item スクリプトが付いていません。");
                continue;
            }

            // プレイヤーがそのアイテムを持っていない場合のみ生成
            if (!playerInventory.HasItem(item.itemId))
            {
                Instantiate(itemPrefabs[itemIndex], popPoints[i].position, Quaternion.identity);
            }
            else
            {
                Debug.Log("プレイヤーはアイテム " + item.itemId + " を既に持っています。生成スキップ。");
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
