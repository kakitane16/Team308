using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float ShotForce = 10f; // Shot�̋���
    public float curveForce = 2f; // �p�Ȃ̋���
    public bool canShot = true; // Shot�\���ǂ���
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Space�L�[�������ꂽ�Ƃ��A��񂾂�Shot
        if (Input.GetKeyDown(KeyCode.Space) && canShot)
        {
            Shot();
        }
    }

    void Shot()
    {
        canShot = false; // ��񂾂��łƑł��Ȃ��Ȃ�

        // ������ɃW�����v�͂�������
        rb.velocity = Vector3.zero; // ���x���Z�b�g
        rb.AddForce(Vector3.up * ShotForce, ForceMode.Impulse);

        // �p�Ȃ��R���[�`���œK�p
        StartCoroutine(ApplyCurve());
    }

    IEnumerator ApplyCurve()
    {
        float duration = 1.0f; // �p�ȗ͂������鎞��
        float elapsed = 0f;

        while (elapsed < duration)
        {
            // �O���� + �������ɗ͂�������
            rb.AddForce((transform.forward + transform.right * curveForce) * Time.deltaTime, ForceMode.VelocityChange);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // �W�����v������������AcanShot�����Z�b�g
        yield return new WaitForSeconds(1f); // ���n�܂ł̗P�\
        canShot = true;
    }
}