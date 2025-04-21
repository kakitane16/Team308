using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float bounceDamping; // ���˕Ԃ莞�̌�����
    private float MoveX;
    private float MoveY;
    private bool isShot;
    Rigidbody rb;
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        MoveX = -5.0f;
        MoveY = 2.0f;
        isShot = false;
    }
    // Update is called once per frame
    private void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        //�^�OWall�ɓ��������璵�˕Ԃ�
        if (other.gameObject.CompareTag("Wall"))
        {
            Vector3 velocityNext = Vector3.Reflect(velocity, other.contacts[0].normal);
            rb.velocity = velocityNext;
            velocity = rb.velocity * bounceDamping;//�����Ȃǂ����������Ă���
        }
    }

    private void FixedUpdate()
    {
        Shot();
    }

    private void Shot()
    {
        //��x�����ł�
        if (isShot)
        {
            return;
        }

        ShotAngle();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = velocity;
            isShot = true;
        }
    }

    private void ShotAngle()
    {
        /*�ꎟ������
        �@(MoveX,Y)�̕\���ł���*/
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveX -= 2;
            MoveY += 3;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveX += 2;
            MoveY -= 3;
        }
        //�p�x�w��
        velocity = new Vector3(MoveX, MoveY, 0.0f);
    }
}