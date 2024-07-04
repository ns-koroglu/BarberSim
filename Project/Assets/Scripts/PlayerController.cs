using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public float mouseSensitivity = 2.0f;
    public float jumpForce = 5.0f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpCooldown = 0.5f;

    private float verticalLookRotation;
    private bool isGrounded;
    private Rigidbody rb;
    private Transform cameraTransform;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

        // Rigidbody d�n���n� s�n�rlama
        rb.freezeRotation = true;

        // Kamera bile�enini bul
        cameraTransform = GetComponentInChildren<Camera>().transform;

        // Animator bile�enini bul
        animator = GetComponent<Animator>();

        // LayerMask'i kontrol etme
        groundMask = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        // Mouse hareketi ile kamera kontrol�
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Yatay hareket
        transform.Rotate(Vector3.up * mouseX);

        // Dikey hareket
        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        cameraTransform.localEulerAngles = Vector3.right * verticalLookRotation;

        // Karakterin WASD tu�lar� ile hareketi
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        float moveForwardBackward = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float moveLeftRight = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        Vector3 move = transform.right * moveLeftRight + transform.forward * moveForwardBackward;
        rb.MovePosition(rb.position + move);

        // Z�plama kontrol�
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Debug.Log("GroundCheck Position: " + groundCheck.position);
        //Debug.Log("isGrounded: " + isGrounded);
        //Debug.DrawRay(groundCheck.position, Vector3.down * groundDistance, Color.red); // GroundCheck �izgi g�sterimi

        // Z�plama kontrol�
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        // Debug.Log("Space tu�una bas�ld�. isGrounded durumu: " + isGrounded);
        //if (isGrounded)
        // {
        // Debug.Log("Jumping");
        // rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        // }
        //}
        


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}