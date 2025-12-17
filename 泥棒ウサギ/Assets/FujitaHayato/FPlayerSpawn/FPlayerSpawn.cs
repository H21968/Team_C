using UnityEngine;

public class FPlayerSpawn : MonoBehaviour
{
    public GameObject spawnPlayer;  // プレイヤー
    public GameObject spawnPoint;   // スポーンポイント

    void Start()
    {
        // 初回スポーン
        Spawn();
    }

    void Update()
    {
        // 仮：Zキーでゲームオーバー → リスポーン
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameOver();
        }
    }

    void Spawn()
    {
        // スポーンポイントを一時的に有効化（必要なら）
        spawnPoint.SetActive(true);

        // プレイヤーを移動
        spawnPlayer.transform.SetPositionAndRotation(
            spawnPoint.transform.position,
            spawnPoint.transform.rotation
        );

        // スポーン後に非表示
        spawnPoint.SetActive(false);

        GameStatus.player_spawn = true;
    }

    void GameOver()
    {
        GameStatus.player_spawn = false;

        // 再スポーン
        Spawn();
    }
}

//using UnityEngine;

//public class FPlayerSpawn : MonoBehaviour
//{
//    public GameObject spawnPlayer;  //プレイヤー
//    public GameObject spawnPoint;  //出現場所
//    //public Transform spawnPoint;    //出現場所

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {

//        if (GameStatus.active_task == false)
//            spawnPoint.SetActive(false);

//        // スポーンポイントの Transform を使って移動
//        //スポーンポイントへプレイヤーを移動させる用
//        spawnPlayer.transform.position = spawnPoint.transform.position;
//        spawnPlayer.transform.rotation = spawnPoint.transform.rotation;

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Z))
//        {
//            GameStatus.player_spawn = false;
//        }
//    }


//    void InactiveImage()
//    {
//        spawnPoint.SetActive(false);
//    }

//}
