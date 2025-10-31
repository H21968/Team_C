using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class N_Human_Behavior : MonoBehaviour
{
    public float Human_speed = 2.2f;//���x
    public int N_Human_HP = 2;//HP
    bool Human_isActive = false;//�A�N�e�B�u
    float Human_rectionDistance = 5.0f;//�v���C���[�̊��m
    Rigidbody2D rbody;            // Rigid body2
    Animator animator;            // Animator
    bool isActive = false;        // �ړ����t���O
    public float Human1_damage = 3;//�v���C���[�ɗ^����_���[�W��

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // Rigid body2D�𓾂�
        animator = GetComponent<Animator>(); // Animator�𓾂�
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = Vector2.zero; 

        //player�̃Q�[���I�u�W�F�N�g�𓾂�
        GameObject player = GameObject.FindGameObjectWithTag("player");

        if (player != null)
        {
            //�v���C���[���̋����`�F�b�N�ƃA�N�e�B�u��
            float dist = Vector2.Distance(transform.position, player.transform.position);
            if (dist < Human_rectionDistance)
            {
                isActive = true; //�A�N�e�B�u�ɂ���
                animator.SetBool("isActive", isActive);
               
                //�v���C���[�̕����Ɍ�����
                Vector2 dir = (player.transform.position-transform.position).normalized; 
                move = dir * Human_speed; 

                float rad  = Mathf.Atan2(dir.y, dir.x);
                float angle = rad * Mathf.Rad2Deg;

                //�ړ��p�x�ŃA�j���[�V������ύX����
                int Distinct;
                     if (angle >= -45 && angle < 45)
                    {
                    //�E����
                    Distinct = 3;
                    }
                    else if (angle >= 45 && angle <= 135)
                    {
                    //�����
                    Distinct = 2;
                    }
                    else if (angle >= -135 && angle <= -45)
                    {
                    //������
                    Distinct = 0;
                    }
                    else
                    {
                    //������
                    Distinct = 1;
                    }
                     animator.SetInteger("Distinct", Distinct);
            }
        }
        else
        {
            isActive = false;
        }
        rbody.linearVelocity = move;
    }
}
