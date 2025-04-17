using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saebasi : MonoBehaviour
{
    //�������Ԃ����ė������ɓ��������������ꏊ
   private void OnTriggerEnter(Collider other)
    {
        //����susiObject���Ă��Ă閼�O�i�^�O�j�ɂ����������ē�������
        if(other.CompareTag("susiObject"))
        {
            //other�͂Ԃ����ė���object���w��
            //Rigitbody�����̃f�[�^���Ƃ�A������A���˂�A��ԂȂǁ@Rigitbody���Ȃ��Ƃł��Ȃ�
            Rigidbody rb = other.GetComponent<Rigidbody>();

            //rb��Rigitbody�������Ă���Ȃ炻�̌�̏��������s(null)
            if(rb != null )
            {
                //velocity(���x)���[���ɂ��Ď~�߂�
                rb.velocity = Vector3.zero;
                //kinematic(����or����)���~�߂ČŒ�
                rb.isKinematic = true;
                //Coroutine(���Ԍo��)���g������������֐�
                //ReleaseAfterDelay(rb)�R���[�`�����X�^�[�g�����Ď��s���閽��
                StartCoroutine(ReleaseAfterDelay(rb));
            }
        }
    }

    //IEnumerator.���X�g��z��̗v�f�����ԂɎ��o���ď�������֐�
    private System.Collections.IEnumerator ReleaseAfterDelay(Rigidbody rb)
    {
        // yield return�����ł�������~�܂���Ă��鍇�}
        //new WaitForSeconds(3f)3�b�҂Ƃ����w��
        yield return new WaitForSeconds(3f);

        //Rigidbody��.isKinematic��ture�̏ꍇ�����Ȃ��Afalse�̏ꍇ�d�͂Ƃ��͂��󂯂ē�����悤�ɂȂ�
        //�����̃I�u�W�F�N�g�͂��������Ă�����Ƃ�������
        rb.isKinematic = false;
        //�^���Ɍ������đ����R�ŗ����鏈��
        rb.velocity = Vector3.down * 3f;
    }

}
