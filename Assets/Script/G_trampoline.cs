using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_trampoline : MonoBehaviour
{
    public float Force = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �����蔻��
    private void OnCollisionEnter(Collision collision)
    {
        // ��������Object�̃^�O��Player�ł͂Ȃ��Ȃ珈�������Ȃ�
        if (collision.gameObject.tag != "Player") { return; }

        // Player��Rigidbody���擾
        Rigidbody playerRb = collision.rigidbody;
        // ��񂪂Ȃ��Ȃ珈�������Ȃ�
        if (playerRb == null) { return; }

        //// ���˃x�N�g��
        Vector3 comingVec = -playerRb.velocity.normalized;
        //// �@���x�N�g��
        //Vector3 normal = collision.contacts[0].normal;
        //// ���˃x�N�g�����v�Z
        //Vector3 reflectVec = Vector3.Reflect(comingVec.normalized, normal);
        //// �I�u�W�F�N�g�𔽎˕����֔�΂�
        //playerRb.AddForce(reflectVec * Force, ForceMode.VelocityChange);

        //player�̃g�����X�t�H�[�����擾
        Transform PlayerTransform = collision.transform;

        // �x�N�g���i���������j
        Vector3 rightVec = PlayerTransform.right;

        // x���x�N�g����z�������ɂX�O�x��]
        Vector3 rotateVec = Quaternion.AngleAxis(90, Vector3.forward) * rightVec;
        // ���̐����𔻒f
        float direction = Vector3.Dot(Vector3.Cross(rightVec, comingVec), Vector3.forward);
        // ���������ɉ����Ĕ��]
        if (direction < 0)
        {
            rotateVec = -rotateVec;
        }

        // player�����̕����ɔ�΂�
        playerRb.velocity = Vector3.zero;
        playerRb.AddForce(rotateVec.normalized * Force, ForceMode.VelocityChange);


    }
}
