using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(CharacterController2D))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float runSpeed = 40f;

    private CharacterController2D controller;
    private Animator animator;
    private bool isAttacking = false;
    private float horizontalMove = 0f;
    private bool isJumping = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // determine movement
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //Debug.Log("Horizontal move: " + horizontalMove);

        // determine jumping
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            animator.SetTrigger("Jump");
        }
        // determine attacking
        if (Input.GetButtonDown("Fire1"))
        {
            isAttacking = true;
            animator.SetTrigger("Attack");
            Invoke("resetAttack", 1.2f);
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping, isAttacking); // should set velocity to 0
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            controller.SaveLocation(); // save data right away incase of misclick or whatever, dont hold it until save game is clicked
            SceneManager.LoadScene("MainMenu");
        }
        // show the correct animation
        animator.SetFloat("Speed", Mathf.Abs(controller.speed));
    }

    private void FixedUpdate()
    {
        if (!isAttacking)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping, isAttacking);
            isJumping = false;
        }
    }
    private void resetAttack()
    {
        isAttacking = false;
    }
}
