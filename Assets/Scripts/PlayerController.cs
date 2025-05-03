using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveInput;
    private Animator playerAnimator;
    public float speed;
    private Rigidbody2D rb;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
        if (moveInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); 
        }
        else if (moveInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0); 
        } 
        playerAnimator.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject bullet = BulletPooling.instance.GetPooledBullet();
        if(bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
    }
    

}
