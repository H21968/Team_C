using UnityEngine;

public class Player_HP : MonoBehaviour
{
    public static int player_hp = 3;           //Player HP

    public void TakeDamage(int damage)
    {
        player_hp -= damage;
        Debug.Log("�v���C���[�_���[�W�c��HP:" + player_hp);

        if (player_hp <= 0)
        {
            Debug.Log("�v���C���[���S");
        }
        
    }
}
