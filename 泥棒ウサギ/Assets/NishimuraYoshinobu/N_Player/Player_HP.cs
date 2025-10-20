using UnityEngine;

public class Player_HP : MonoBehaviour
{
    public static int player_hp = 3;           //Player HP

    public void TakeDamage(int damage)
    {
        player_hp -= damage;
        Debug.Log("プレイヤーダメージ残りHP:" + player_hp);

        if (player_hp <= 0)
        {
            Debug.Log("プレイヤー死亡");
        }
        
    }
}
