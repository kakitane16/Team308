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

    // 当たり判定
    private void OnCollisionEnter(Collision collision)
    {
        // 当たったObjectのタグがPlayerではないなら処理をしない
        if (collision.gameObject.tag != "Player") { return; }

        // PlayerのRigidbodyを取得
        Rigidbody playerRb = collision.rigidbody;
        // 情報がないなら処理をしない
        if (playerRb == null) { return; }

        //// 入射ベクトル
        Vector3 comingVec = -playerRb.velocity.normalized;
        //// 法線ベクトル
        //Vector3 normal = collision.contacts[0].normal;
        //// 反射ベクトルを計算
        //Vector3 reflectVec = Vector3.Reflect(comingVec.normalized, normal);
        //// オブジェクトを反射方向へ飛ばす
        //playerRb.AddForce(reflectVec * Force, ForceMode.VelocityChange);

        //playerのトランスフォームを取得
        Transform PlayerTransform = collision.transform;

        // ベクトル（ｘ軸方向）
        Vector3 rightVec = PlayerTransform.right;

        // x軸ベクトルをz軸を軸に９０度回転
        Vector3 rotateVec = Quaternion.AngleAxis(90, Vector3.forward) * rightVec;
        // 軸の正負を判断
        float direction = Vector3.Dot(Vector3.Cross(rightVec, comingVec), Vector3.forward);
        // 正か負かに応じて反転
        if (direction < 0)
        {
            rotateVec = -rotateVec;
        }

        // playerをその方向に飛ばす
        playerRb.velocity = Vector3.zero;
        playerRb.AddForce(rotateVec.normalized * Force, ForceMode.VelocityChange);


    }
}
