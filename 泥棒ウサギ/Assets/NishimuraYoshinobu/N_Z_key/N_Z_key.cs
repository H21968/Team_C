using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_Z_key : MonoBehaviour
{
    public string Z_key;
    public float Z_Delay = 1f;//Z�L�[��������Ԋu
    bool inLnvestigate = false;//���ׂ邽�߂̃t���O
    public GameObject Z_keyPrefab;//Z�L�[�̃v���n�u
    GameObject Z_keyOBJ;//Z�L�[�̃Q�[���I�u�W�F�N�g

    //�I�u�W�F�N�g�̊��m
    public string Z_Perception;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Z_keyPrefab)
        {
            Z_keyOBJ = Instantiate(Z_keyPrefab);
            
        }
        else
        {
            Z_keyOBJ = new GameObject("Z_keyOBJ");
        }
        //���ׂ邽�߂̃I�u�W�F�N�g���v���C���[�̑O�ɔz�u
        //Vector3 pos = transform.position;
        Z_keyOBJ.transform.SetParent(transform);//���ׂ邽�߂̃I�u�W�F�N�g�̐e���v���C���[�ɐݒ�
        Z_keyOBJ.transform.localPosition = new Vector3(0,0,-1);
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Fire3") || Input.GetMouseButtonDown(0))
        {
            Debug.Log("a");
            //���ׂ�L�[�������ꂽ
            Lnvestigate();
        }
        //���ׂ�L�[�̉�]�ƗD�揇��
        float inLnvestigate_Point_Z = -1;//���ׂ�L�[���v���C���[�̑O�ɂ���
        PlayerControll plmv = GetComponent<PlayerControll>();
        if (plmv.angleZ > 30 && plmv.angleZ < 150)
        {
            //�����
            inLnvestigate_Point_Z = 1;//�L�����N�^�̌��ɂ���
        }
        Z_keyOBJ.transform.position = 
            new Vector3(transform.position.x, transform.position.y, inLnvestigate_Point_Z);
    }
}
