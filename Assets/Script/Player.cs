using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float ShotForce = 10f; // Shotの強さ
    public float curveForce = 2f; // 湾曲の強さ
    public bool canShot = true; // Shot可能かどうか
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Spaceキーが押されたとき、一回だけShot
        if (Input.GetKeyDown(KeyCode.Space) && canShot)
        {
            Shot();
        }
    }

    void Shot()
    {
        canShot = false; // 一回だけ打つと打たなくなる

        // 上方向にジャンプ力を加える
        rb.velocity = Vector3.zero; // 速度リセット
        rb.AddForce(Vector3.up * ShotForce, ForceMode.Impulse);

        // 湾曲をコルーチンで適用
        StartCoroutine(ApplyCurve());
    }

    IEnumerator ApplyCurve()
    {
        float duration = 1.0f; // 湾曲力を加える時間
        float elapsed = 0f;

        while (elapsed < duration)
        {
            // 前方向 + 横方向に力を加える
            rb.AddForce((transform.forward + transform.right * curveForce) * Time.deltaTime, ForceMode.VelocityChange);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // ジャンプが完了した後、canShotをリセット
        yield return new WaitForSeconds(1f); // 着地までの猶予
        canShot = true;
    }
}