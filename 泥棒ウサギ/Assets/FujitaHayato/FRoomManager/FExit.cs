using UnityEngine;

//出入口の位置
public enum ExitDirection
{
    right,  //右方向
    left,   //左方向
    down,   //下方向
    up,     //上方向
}

public class FExit : MonoBehaviour
{
    public string sceneName = "";   //移動シーン
    public int doorNumber = 0;      //ドア番号
    public ExitDirection direction = ExitDirection.down;    //ドアの位置
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="player")
        {
            FRoomManager.ChangeScene(sceneName, doorNumber);
        }
    }

}
