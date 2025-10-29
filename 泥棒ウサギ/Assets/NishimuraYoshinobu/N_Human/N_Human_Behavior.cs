using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class N_Human_Behavior : MonoBehaviour
{
    public float Human_speed = 1000.0f;//���x
    public int N_Human_HP = 2;//HP
    bool Human_isActive = false;//�A�N�e�B�u
    float Human_rectionDistance = 5.0f;//�v���C���[�̊��m
    Rigidbody2D rbody;            // Rigid body2
    Animator animator;            // Animator
    //bool isMoving = false;        // �ړ����t���O
    float axisH;//��
    float axisV;//�c
    public float damage;//�v���C���[�ɗ^����_���[�W��

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

        axisH = 0;
        axisV = 0;
        //player�̃Q�[���I�u�W�F�N�g�𓾂�
        GameObject player = GameObject.FindGameObjectWithTag("player");

        if (player != null)
        {
            //�v���C���[���̋����`�F�b�N�ƃA�N�e�B�u��
            float dist = Vector2.Distance(transform.position, player.transform.position);
            if (dist < Human_rectionDistance)
            {
                Human_isActive = true; //�A�N�e�B�u�ɂ���
              
               // animator.SetBool("isActive", Human_isActive);
                float dx = player.transform.position.x - transform.position.x;
                float dy = player.transform.position.y - transform.position.y;

                Vector2 dir = (player.transform.position-transform.position).normalized; 
                move = dir * Human_speed; 

                float rad  = Mathf.Atan2(axisV, axisH);
                float angle = rad* Mathf.Deg2Rad;

                     //�ړ��p�x�ŃA�j���[�V������ύX����
                     int  direction ;
                     if (angle >= -45 && angle < 45)
                    {
                        //�E����
                        direction = 3;
                    }
                    else if (angle >= 45 && angle <= 135)
                    {
                        //�����
                        direction = 2;
                    }
                    else if (angle >= -135 && angle <= -45)
                    {
                        //������
                        direction = 0;
                    }
                    else
                    {
                        //������
                        direction = 1;
                    }
                   // animator.SetInteger("Direction", direction);
                    //�x�N�g��
                    axisH = Mathf.Cos(rad)*Human_speed;
            }
        }
        else
        {
            Human_isActive = false;
        }
        rbody.linearVelocity = move;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�v���C���[�_���[�W
        if (collision.gameObject.tag == "player")
        {

            PlayerControll player = collision.gameObject.GetComponent<PlayerControll>();
            if (player != null)
            {
                PlayerControll.player_hp -= ((int)damage);
                Debug.Log("�v���C���[���_���[�W���󂯂�");

                if (PlayerControll.player_hp <= 0)

                {
                    player.GameOver();
                    Debug.Log("�v���C���[���S");
                }
            }
        }
    }
}
