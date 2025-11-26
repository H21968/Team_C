using Unity.VisualScripting;
using UnityEngine;

public class N_fellow_Back : MonoBehaviour
{
    public float speed = 3.0f;    // 移動スピード
    public float Player_Direction;// プレイヤーの向き

    Rigidbody2D rbody;            // Rigid body2
    Animator animator;            // Animator

    public PlayerControll Player_Ctrl;   // PlayerControll

    public float Back_target_Position;//プレイヤーの後ろの位置
    public Transform Playes;//プレイヤーの位置

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // Rigid body2Dを得る
        animator = GetComponent<Animator>(); // Animatorを得る
    }

    // Update is called once per frame
    void Update()
    {
        Target_Pos();
    }
    void Direction_Back(Vector2 dir)
    {
        float rad = Mathf.Atan2(dir.y, dir.x);
        float angle2 = rad * Mathf.Rad2Deg;

        int Distinct2;
        if (angle2 >= -45 && angle2 < 45)
        {
            //右向き
            Distinct2 = 3;
            Player_Direction = 3;
        }
        else if (angle2 >= 45 && angle2 <= 135)
        {
            //上向き
            Distinct2 = 2;
            Player_Direction = 2;
        }
        else if (angle2 >= -135 && angle2 <= -45)
        {
            //下向き
            Distinct2 = 0;
            Player_Direction = 0;
        }
        else
        {
            //左向き
            Distinct2 = 1;
            Player_Direction = 1;
        }
        animator.SetInteger("Distinct", Distinct2);
    }
    void Target_Pos()
    {
        if (Player_Ctrl == null || Playes == null)
        { return; }
        //プレイヤーの後ろの位置を求める
        Vector2 target = Playes.position;

       if (Player_Direction == 0)
        {
            target += new Vector2(0, Back_target_Position);
        }
        else if (Player_Direction == 1)
        {
            target += new Vector2(Back_target_Position,0);
        }
        else if (Player_Direction == 2)
        {
            target += new Vector2(0, -Back_target_Position);
        }
        else if(Player_Direction == 3)
        {
            target += new Vector2(-Back_target_Position,0);
        }

        //そこへ移動
        Vector2 newPos = Vector2.MoveTowards(transform.position, target,speed*Time.deltaTime);
        rbody.MovePosition(newPos);

        //キャラの向きを更新
        Direction_Back(target - (Vector2)transform.position);
    }
}

