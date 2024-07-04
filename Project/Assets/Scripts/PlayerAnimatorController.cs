using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private PlayerController playerController;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
        animator.SetBool("IsJumping", false);
    }

    void Update()
    {
        // Hareket h�z�n� alarak Speed parametresini g�ncelle
        float speed = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;
        animator.SetFloat("Speed", speed);

        // Z�plama durumu kontrol�
        bool isJumping = !Mathf.Approximately(rb.velocity.y, 0);
        animator.SetBool("IsJumping", isJumping);

        // W tu�una bas�l�ysa ve hareket varsa y�r�me animasyonunu aktifle�tir
        if (Input.GetKey(KeyCode.W) && speed > 0.1f)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }

    }
}