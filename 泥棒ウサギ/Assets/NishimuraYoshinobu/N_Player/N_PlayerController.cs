//N_PlayerController
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
using UnityEngine;

public class N_PlayerController : MonoBehaviour
{
    public float speed = 3.0f;    // 移動スピード
    int direction = 0;            // 移動方向
    float axisH;                  // 横軸
    float axisV;                  // 縦軸
    public float angleZ = -90.0f; // 回転角度 プレイヤーの向き
    Rigidbody2D rbody;            // Rigid body2
    Animator animator;            // Animator
    bool isMoving = false;        // 移動中フラグ

    // p1����p2�̊p�x��Ԃ�
    float GetAngle(Vector2 p1, Vector2 p2) 
    { 
        float angle;
        if(axisH != 0 || axisV != 0)
        {
            // �ړ����ł���Ίp�x���X�V����
            // p1 ���� p2 �ւ̍����i���_��0�ɂ��邽�߁j
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;
            //�A�[�N�^���W�F���g2�֐��Ŋp�x�����߂�
            float rad =Mathf.Atan2(dy, dx);
            //���W�A����x�ɕϊ����ĕԂ�
            angle = rad * Mathf.Rad2Deg;
        }
        else
        {
            //��~���ł���ΈȑO�̊p�x���ێ�
            angle = angleZ;
        }
        return angle;   
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // Rigid body2D�𓾂�
        animator = GetComponent<Animator>(); // Animator�𓾂�
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal"); //���E���L�[����
            axisV = Input.GetAxisRaw("Vertical");   //�㉺�̃L�[����
        }
        //�L�[���͂���ړ��p�x�����߂�
        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
        //�ړ���������Ă�������ƃA�j���[�V�����̍X�V
        int dir;
        if (angleZ >= -45 &&  angleZ < 45)
        {
            //�E����
            dir = 3;
        }
        else if (angleZ >= 45 && angleZ <= 135)
        {
            //�����
            dir = 2;
        }
        else if (angleZ >= 135 && angleZ <= -45)
        {
            //������
            dir = 0;
        }
        else
        {
            //������
            dir = 1;
        }
        if(dir != direction)
        {
            direction = dir;
            animator.SetInteger("Distinct", direction);
        }
    }
    void FixedUpdate()
    {
        //�ړ����x���X�V����
        rbody.linearVelocity = new Vector2(axisH, axisV).normalized * speed;
    }

    public void SetAxis(float h, float v)
    {
        axisH = h;
        axisV = v;
        if(axisH == 0 && axisV == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }
}
