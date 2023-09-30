using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public float moveSpeed = 1.0f;
    public Text carrotText;
    private CharacterController characterController;
    private Animator animator;
    public float runSpeed;
    public float gravityScale = -9.81f;
    private Vector3 PlayerVelocity;
    public float jumpHeight = 1f;
    private int carrotsCollected = 0;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded && characterController.velocity.y < 0)
        {
            PlayerVelocity.y = 0;
        }
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);
        Vector3 direction = transform.forward;
        float curSpeed = Input.GetAxis("Vertical") * moveSpeed;
        characterController.Move(direction * curSpeed * Time.deltaTime);
        animator.SetFloat("RunSpeed", runSpeed);
        animator.SetFloat("RabbitSpeed", Mathf.Abs(curSpeed));

        if(Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            PlayerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityScale);
        }

        PlayerVelocity.y += gravityScale * Time.deltaTime;
        characterController.Move(PlayerVelocity * Time.deltaTime);

        carrotText.text = carrotsCollected.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Carrot")
        {
            carrotsCollected += 1;
            print(carrotsCollected);
            Destroy(collision.gameObject);
        }
    }
}
