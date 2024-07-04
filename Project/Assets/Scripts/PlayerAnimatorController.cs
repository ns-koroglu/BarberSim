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
        // Hareket hýzýný alarak Speed parametresini güncelle
        float speed = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;
        animator.SetFloat("Speed", speed);

        // Zýplama durumu kontrolü
        bool isJumping = !Mathf.Approximately(rb.velocity.y, 0);
        animator.SetBool("IsJumping", isJumping);

        // W tuþuna basýlýysa ve hareket varsa yürüme animasyonunu aktifleþtir
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