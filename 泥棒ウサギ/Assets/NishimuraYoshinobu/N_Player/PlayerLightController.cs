using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; //Light2D���g���̂ɕK�v

//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

public class PlayerLightController : MonoBehaviour
{
    Light2D light2d;            // Light2D
    PlayerControll playerCnt; //PlayerController�X�N���v�g
    float lightTimer = 0.0f;    //���C�g�̏���^�C�}�[

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light2d = GetComponent<Light2D>(); //Light2D���擾
        light2d.pointLightOuterRadius = (float)ItemKeeper.hasLights; //�A�C�e���̐��Ń��C�g������ύX
        playerCnt = GameObject.FindObjectOfType<PlayerControll>(); //PlayerController�擾
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCnt == null)
        {
            playerCnt = GameObject.FindObjectOfType<PlayerControll>();
            if (playerCnt == null)
            {
                Debug.Log("PlayerControll��������܂���");
                return;
            }
        }
        //���C�g���v���C���[�ɍ��킹�ĉ�]������
        transform.position = playerCnt.transform.position;
        light2d.transform.localRotation = Quaternion.Euler(0, 0, playerCnt.angleZ + 90);
        if (ItemKeeper.hasLights > 0)//���C�g�������Ă���
        {
            lightTimer += Time.deltaTime;//�t���[�����Ԃ����Z
            if (lightTimer > 10.0f ) //10�b�o��
            {
                lightTimer = 0.0f; //�^�C�}�[���Z�b�g
                ItemKeeper.hasLights--; //���C�g�A�C�e�������炷
                light2d.pointLightOuterRadius = ItemKeeper.hasLights; //�A�C�e���̐��Ń��C�g������ύX
            }
        }
    }
    public void LightUpdate()
    {
        light2d.pointLightOuterRadius = ItemKeeper.hasLights;//�A�C�e���̐��Ń��C�g������ύX
    }
}
