//N_PlayerController
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float speed = 3.0f;    // �ړ��X�s�[�h
    int direction = 0;            // �ړ�����
    float axisH;                  // ����
    float axisV;                  // �c��
    public float angleZ = -90.0f; // ��]�p�x �v���C���[�̌���
    Rigidbody2D rbody;            // Rigid body2
    Animator animator;            // Animator
    bool isMoving = false;        // �ړ����t���O


    public static int player_hp = 3;           //Player HP
    public static string gameState;     //game�̏��
    bool inDamage = false;              //�_���[�W���t���O
    public int destroy_time = 1;        //�v���C���[�̔j��܂ł̎���
    public float destroy_vector_x = 0;  //�v���C���[�j��O�ɕt�^�����X���x�N�g��
    public float destroy_vector_y = 5;  //�v���C���[�j��O�ɕt�^�����Y���x�N�g��
    public float zero_speed = 0;         //�v���C���[�̈ړ���~

    // p1����p2�̊p�x��Ԃ�
    float GetAngle(Vector2 p1, Vector2 p2)
    {
        float angle;
        if (axisH != 0 || axisV != 0)
        {
            // �ړ����ł���Ίp�x���X�V����
            // p1 ���� p2 �ւ̍����i���_��0�ɂ��邽�߁j
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;
            //�A�[�N�^���W�F���g2�֐��Ŋp�x�����߂�
            float rad = Mathf.Atan2(dy, dx);
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

        //�Q�[���̏�Ԃ��v���C���ɂ���
        gameState = "playing";

        Debug.Log("start");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isMoving);

        //�Q�[�����ȊO�ƃ_���[�W���͉������Ȃ�
        if (gameState != "playing" || inDamage)
        {
            return;
        }

        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal"); // ���E�L�[����
            axisV = Input.GetAxisRaw("Vertical");   // �㉺�L�[����
        }
        //�L�[���͂���ړ��p�x�����߂�
        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
        //�ړ�������������Ă�������ƃA�j���[�V�������X�V
        
        int dir;
        if (angleZ >= -45 && angleZ < 45)
        {
           
            //�E����
            dir = 3;
        }
        else if (angleZ >= 45 && angleZ <= 135)
        {
            //�����
            dir = 2;
            animator.SetInteger("Direction", direction);
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
        if (dir != direction)
        {
            direction = dir;
           animator.SetInteger("Distinct", direction);
        }

    }

    void FixedUpdate()
    {

        //�Q�[�����ȊO�͉������Ȃ�
        if (gameState != "playing")
        {
            return;
        }
        if (inDamage)
        {
            //�_���[�W���_�ł�����
            float val = Mathf.Sin(Time.time * 50);
            if (val > 0)
            {
                //�X�v���C�g��\��
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                //�X�v���C�g���\��
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            return; //�_���[�W���͑���ɂ��ړ������Ȃ�
        }


        //�ړ����x���X�V����
        rbody.linearVelocity = new Vector2(axisH, axisV).normalized * speed;
        Debug.Log(rbody.linearVelocity);
    }

    public void SetAxis(float h, float v)
    {
        axisH = h;
        axisV = v;
        if (axisH == 0 && axisV == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

    //�ڐG
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Item")//�A�C�e���ɐG�ꂽ�ꍇ�̔���
        {
            ItemGet(collision.gameObject);
        }

        if (collision.gameObject.tag == "Clear")//�N���A�ɐG�ꂽ�ꍇ�̔���
        {
            GameClear(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")//�G�ɐG�ꂽ�ꍇ�̃_���[�W����
        {
            GetDamage(collision.gameObject);
        }
    }
    //�_���[�W
   void GetDamage(GameObject enemy)
    {
        if (gameState == "playing")
        {
            player_hp--; //HP�����炷

            if (player_hp > 0)
            {
                //�_���[�W�t���O ON
                inDamage = true;

                //�ړ���~
                rbody.linearVelocity =  Vector2.zero;
                //�G�L�����̔��Ε����Ƀq�b�g�o�b�N������
                Vector2 hit = (transform.position - enemy.transform.position).normalized * 4f;
              
                rbody.linearVelocity = hit;
                


                axisH = 0;
                axisV = 0;

               
               
                Invoke("DamageEnd", 0.25f);
               

            }
            else
            {
                //�Q�[���I�[�o�[
                GameOver();
            }
        }
    }

    void StopMove()
    {
        rbody.linearVelocity = new Vector2(zero_speed, zero_speed);//�ړ���~
    }
    //�_���[�W�I��
    void DamageEnd()
    {
        inDamage = false;//�_���[�W�t���OOFF
        gameObject.GetComponent<SpriteRenderer>().enabled = true;//�X�v���C�g�����ɖ߂�
        rbody.linearVelocity = new Vector2(zero_speed, zero_speed);//�ړ���~
    }
    //�Q�[���I�[�o�[
    public  void GameOver()
    {
        gameState = "gameover";
        //�Q�[���I�[�o�[���o
        GetComponent<BoxCollider2D>().enabled = false;//�v���C���[�̂����������
        rbody.linearVelocity = new Vector2(zero_speed, zero_speed);//�ړ���~
        rbody.gravityScale = 2;                   //�d�͂�߂� 2
        rbody.linearVelocity = new Vector2(destroy_vector_x, destroy_vector_y);//(x,y)�Q�[���I�[�o�[���Ƀv���C���[�Ƀx�N�g����������
        animator.SetBool("IsDead", true);//�A�j���[�V�����̐؂�ւ�
        Destroy(gameObject, destroy_time);       //�v���C���[�̔j��Ƃ���܂ł̎���

    }

    //�Q�[���N���A 
    public void GameClear(GameObject Clear)
    {
        gameState = "gameclear";
        

        GetComponent<BoxCollider2D>().enabled = false;//�v���C���[�̂����������
        rbody.linearVelocity = new Vector2(zero_speed, zero_speed);//�ړ���~

        Destroy(gameObject, 3.0f);
    }

    //�A�C�e���Q�b�g
    public void ItemGet(GameObject Item)
    {
        gameState = "itemget";

        gameState = "playing";
    }


}
