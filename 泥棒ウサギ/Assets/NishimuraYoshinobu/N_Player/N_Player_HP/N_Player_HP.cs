using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.LightAnchor;

public class N_Player_HP : MonoBehaviour
{
    int HP;
    Rigidbody2D rbody;            // Rigid body2
    Animator animator;            // Animator
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // Rigid body2D‚ð“¾‚é
        animator = GetComponent<Animator>(); // Animator‚ð“¾‚é
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");
        if (GameStatus.player_hp == 3)
        {
            HP = 3;
            Debug.Log(HP);
        }
        if (GameStatus.player_hp == 2)
        {
            HP = 2;
            Debug.Log(HP);
        }
        if (GameStatus.player_hp == 1)
        {
            HP = 1;
            Debug.Log(HP);
        }
        if (GameStatus.player_hp <= 0)
        {
            HP = 0;
            Debug.Log(HP);
        }

            animator.SetInteger("HP_Down", HP);

    }
}
