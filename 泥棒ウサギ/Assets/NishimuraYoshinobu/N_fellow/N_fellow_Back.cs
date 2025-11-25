using UnityEngine;

public class N_fellow_Back : MonoBehaviour
{
    public float speed = 3.0f;    // 移動スピード
    int direction = 0;            // 移動方向
    public float angleZ = -90.0f; // 回転角度 プレイヤーの向き
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
        //Vector2  di r=  (target_Position - transform.position).normalized; ;
        //Direction_Back(dir);
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
        }
        else if (angle2 >= 45 && angle2 <= 135)
        {
            //上向き
            Distinct2 = 2;
        }
        else if (angle2 >= -135 && angle2 <= -45)
        {
            //下向き
            Distinct2 = 0;
        }
        else
        {
            //左向き
            Distinct2 = 1;
        }
        animator.SetInteger("Distinct", Distinct2);
    }
}

