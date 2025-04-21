using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float bounceDamping; // 跳ね返り時の減衰率
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
        //タグWallに当たったら跳ね返る
        if (other.gameObject.CompareTag("Wall"))
        {
            Vector3 velocityNext = Vector3.Reflect(velocity, other.contacts[0].normal);
            rb.velocity = velocityNext;
            velocity = rb.velocity * bounceDamping;//速さなどを減衰させていく
        }
    }

    private void FixedUpdate()
    {
        Shot();
    }

    private void Shot()
    {
        //一度だけ打つ
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
        /*一次方程式
        　(MoveX,Y)の表ができる*/
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
        //角度指定
        velocity = new Vector3(MoveX, MoveY, 0.0f);
    }
}