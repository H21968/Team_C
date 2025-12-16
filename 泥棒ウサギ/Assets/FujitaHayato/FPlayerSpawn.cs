using UnityEngine;

public class FPlayerSpawn : MonoBehaviour
{
    public GameObject spawnPlayer;  //プレイヤー
    public Transform spawnPoint;    //出現場所

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameStatus.player_spawn == false)
        {
            //spawnPoint(Destroy)
        }

        ////// プレイヤーをスポーンポイントの位置へ移動
        ////spawnPlayer.transform.position = spawnPoint.position;
        ////spawnPlayer.transform.rotation = spawnPoint.rotation;
        //GameObject player = GameObject.FindWithTag("player");  // Playerタグを持つプレイヤー取得
        //if (player != null)
        //{
        //    player.transform.position = spawnPoint.position;
        //    player.transform.rotation = spawnPoint.rotation;
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }

}
