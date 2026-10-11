using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;

    private Rigidbody _rb;
    private int jumpCount = 0;
    private int maxJump = 2;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        transform.Translate(dir * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJump)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, jumpForce, _rb.velocity.z);
            jumpCount++;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
}