using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [Header("���� �̵�")]
    [SerializeField]
    private float xMoveSpeed = 2; // �ӵ�
    [SerializeField]
    private float xDelta = 2; // ����
    private float xStartPosition; //���� ��ġ
    [Space]
    [Header("���� �̵�")]
    [SerializeField]
    private float yMoveSpeed = 0.5f; //���� �ӵ�
    private Rigidbody2D rigid2D;



    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        xStartPosition = transform.position.x;
    }

    public void MoveToX()
    {
        float xMove = xStartPosition + xDelta * Mathf.Sin(Time.time * xMoveSpeed);
        transform.position = new Vector3(xMove, transform.position.y, transform.position.z);
    }

    public void MoveToY()
    {
        rigid2D.AddForce(transform.up * yMoveSpeed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Score"))
        {

        }
    }
}
