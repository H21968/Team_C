using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.LightAnchor;

/// <summary>
/// プレイヤーのHP
/// </summary>

public class N_Player_HP : MonoBehaviour
{
    int HP;                       // プレイヤーのHP
    Rigidbody2D rbody;            // Rigid body2
    Animator animator;            // Animator
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // Rigid body2Dを得る
        animator = GetComponent<Animator>(); // Animatorを得る
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");
       
        // プレイヤーのHPが4から上の場合の描写
        if (GameStatus.player_hp >= 4)
        {
            HP = 4;
            
        }
        // プレイヤーのHPが3の時の描写
        if (GameStatus.player_hp == 3)
        {
            HP = 3;
         
        }
        // プレイヤーのHPが2の時の描写
        if (GameStatus.player_hp == 2)
        {
            HP = 2;
            
        }
        //　プレイヤーのHPが1の時の描写
        if (GameStatus.player_hp == 1)
        {
            HP = 1;
            
        }
        // プレイヤーのHPが0の時の描写
        if (GameStatus.player_hp <= 0)
        {
            HP = 0;
     
        }

            animator.SetInteger("HP_Down", HP);

    }
}
