using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_Z_key : MonoBehaviour
{
    public string Z_key;
    public float Z_Delay;//Z�L�[��������Ԋu
    bool inLnvestigate = false;//���ׂ邽�߂̃t���O
    //public GameObject Z_keyPrefab;//Z�L�[�̃v���n�u
    GameObject Z_keyOBJ;//Z�L�[�̃Q�[���I�u�W�F�N�g

    //���ׂ�
    public void Lnvestigate()
    {
        if (inLnvestigate == false)
        {
            inLnvestigate = true;//���ׂ�t���O�𗧂Ă�

            Invoke("StopLnvestigate",Z_Delay);//���ׂ�̒�~�ƁA�Ԋu�ǉ�
        }
    }
    public void StopLnvestigate()
    {
        inLnvestigate = false;//���ׂ�t���O���~�낷
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //���ׂ邽�߂̃I�u�W�F�N�g���v���C���[�̑O�ɔz�u
        Vector3 pos = transform.position;
        Z_keyOBJ.transform.SetParent(transform);//���ׂ邽�߂̃I�u�W�F�N�g�̐e���v���C���[�ɐݒ�
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Fire3"))
        {
            //���ׂ�L�[�������ꂽ
            Lnvestigate();
        }
        //���ׂ�L�[�̉�]�ƗD�揇��
        float inLnvestigate_Point_Z = -1;//���ׂ�L�[���v���C���[�̑O�ɂ���
    }
}
