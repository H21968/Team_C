using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_Z_key : MonoBehaviour
{
    public float Z_Delay = 2f;//Z�L�[��������Ԋu
    bool inLnvestigate = false;//���ׂ邽�߂̃t���O
   
    //���ׂ�
    public void Lnvestigate()
    {
        if (inLnvestigate == false)
        {
            inLnvestigate = true;//���ׂ�t���O�𗧂Ă�
            Debug.Log("���ׂ�");
            Invoke("StopLnvestigate",Z_Delay);//���ׂ�̒�~�ƁA�Ԋu�ǉ�
        }
    }
    public void StopLnvestigate()
    {
        inLnvestigate = false;//���ׂ�t���O���~�낷
    }
    
    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Fire3") || Input.GetMouseButtonDown(0))
        {

            Lnvestigate();
        }

        //bool isActive = false;//�A�N�e�B�u

        //float rectionDistance = 2.0f;

        //Update�ɓ����

        //player�̃Q�[���I�u�W�F�N�g�𓾂�
        //GameObject player = GameObject.FindGameObjectWithTag("player");

        //if (player != null)
        //{
        //    //�v���C���[���̋����`�F�b�N�ƃA�N�e�B�u��
        //    float dist = Vector2.Distance(transform.position, player.transform.position);
        //    if (dist < rectionDistance)
        //    {
        //        isActive = true; //�A�N�e�B�u�ɂ���

        //        if (isActive && (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0)))
        //        {
        //               // �����Ƀ{�^������������̏���������
        //        }
        //    }
        //}
        //else
        //{
        //    isActive = false;
        //}




    }

}
