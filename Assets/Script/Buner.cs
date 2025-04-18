using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buner : MonoBehaviour
{
    //��Ă��������ڂ̑f��(�}�e���A��)��Inspector�Őݒ�ł���悤�Ɍ��J���Ă镨
    //unity�G�f�B�^�[��Ŏ��i���Ă����肷�鎞�ɕ\�����������}�e���A���������Ƀh���b�N���h���b�v���邾��
    public Material butnedMaterial;

    //�������o�[�i�[�ɂԂ����ė������Ɏ����ŌĂ΂��֐�
    //other�͂Ԃ����Ă�������Ⴆ�Ύ��i�Ƃ���\���Ă���
    public void OnTriggerEnter(Collider other)
    {
        //�G�ꂽ���肪���i���ǂ������^�O�Ń`�F�b�N������́A���̏ꍇ����Player���Y��
        if (other.CompareTag("Player"))
        {
            //����̓o�[�i�[�ɐG�ꂽ�u��(other)��ɂ���butnedMaterial(�Ă����f��)����
            //Renderer�����o����renderer�ɕύX�������
            Renderer renderer = other.GetComponent<Renderer>();
            //�����ڂ�ς���O�ɁA�K�v�Ȃ��̂������Ƃ��邩�m�F���Ă��鍀��
            //&&�͗�����������true(����)�̂Ƃ��������̏��������s����Ƃ����Ӗ�
            if (renderer != null && butnedMaterial != null)
            {
                //�ǂ���������Ƃ���Ƃ������Ă��������ڂɂȂ�butnedMaterial�����s�ł���
                renderer.material = butnedMaterial;
            }
        }
    }
}
