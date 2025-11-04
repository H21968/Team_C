using UnityEngine;
using UnityEngine.SceneManagement;

public class FRoomManager : MonoBehaviour
{
    //static変数
    public static int doorNumber = 0;   //ドア番号

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //プレイヤーキャラクター位置
        //出入口を配列で得る
        GameObject[] enters = GameObject.FindGameObjectsWithTag("Exit");
        for(int i=0;i<enters.Length;i++)
        {
            GameObject doorobj = enters[i];   //配列から取り出す
            FExit exit = doorobj.GetComponent<FExit>();    //Exitクラス取得
            if(doorNumber==exit.doorNumber)
            {
                //====ドア番号同じ====
                //プレイヤーキャラクター出入口に移動
                float x = doorobj.transform.position.x;
                float y = doorobj.transform.position.y;
                if (exit.direction==ExitDirection.up)
                {
                    y += 1;
                }
                else if(exit.direction==ExitDirection.right)
                {
                    x += 1;
                }
                else if(exit.direction==ExitDirection.down)
                {
                    y -= 1;
                }
                else if(exit.direction==ExitDirection.left)
                {
                    x -= 1;
                }
                // プレイヤーを移動させる
                GameObject player = GameObject.FindGameObjectWithTag("player");
                if (player != null)
                {
                    player.transform.position = new Vector3(x, y, player.transform.position.z);
                }

                break; //ループを抜ける
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //シーン移動
    public static void ChangeScene(string scenename,int doornum)
    {
        doorNumber = doornum;   //ドア番号をstatic変数に保存
        SceneManager.LoadScene(scenename);  //シーン移動
    }
}
