using System.Collections.Generic;
using UnityEngine;

public class FPlayerInventory : MonoBehaviour
{

    // 所持しているアイテムのIDリスト
    private List<int> ownedItemIds = new List<int>();

    // 所持アイテムを取得（読み取り専用）
    public List<int> OwnedItemIds => ownedItemIds;

    // アイテムを所持に追加
    public void AddItem(int itemId)
    {
        if (!ownedItemIds.Contains(itemId))
        {
            ownedItemIds.Add(itemId);
            Debug.Log($"アイテム {itemId} を取得しました。");
        }
    }

    // アイテムを所持から削除
    public void RemoveItem(int itemId)
    {
        if (ownedItemIds.Contains(itemId))
        {
            ownedItemIds.Remove(itemId);
            Debug.Log($"アイテム {itemId} を削除しました。");
        }
    }

    // 所持しているかチェック
    public bool HasItem(int itemId)
    {
        return ownedItemIds.Contains(itemId);
    }

    //プレイヤーが2体出ないようにする用
    void Awake()
    {
        // すでに存在するインスタンスがあるか調べる
        var objs = FindObjectsOfType<FPlayerInventory>();

        if (objs.Length > 1)
        {
            Destroy(gameObject); // 重複を消す
            return;
        }

        DontDestroyOnLoad(gameObject); // 最初の1つだけ残す
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
