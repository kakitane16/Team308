using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Fan : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        // ��������Object�̃^�O��Player�ł͂Ȃ��Ȃ珈�������Ȃ�
        if (other.gameObject.tag != "Player") { return; }

        // Player��Rigidbody���擾
        Rigidbody playerRb = other.attachedRigidbody;
        // ��񂪂Ȃ��Ȃ珈�������Ȃ�
        if (playerRb == null) { return; }

        // �����̌����Ă���������擾
        Vector3 forward = transform.forward;
        // player�����̕����ɔ�΂�
        playerRb.velocity = Vector3.zero;
        playerRb.AddForce(forward.normalized * Force, ForceMode.VelocityChange);
    }
}
