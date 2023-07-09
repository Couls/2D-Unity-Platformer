using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float closeEnoughDistance;
    [SerializeField] private float movementSpeed = 40f;

    private int currentWaypointIndex = 0;
    private float horizontalMove = 0f;

    private CharacterController2D controller;
    private Animator animator;

    private void Awake()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // are we close enough to the current waypoint?
        float distanceAway = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);
        Debug.Log($"Distance away from current waypoint ({waypoints[currentWaypointIndex].transform.name}): {distanceAway}");
        if (distanceAway < closeEnoughDistance)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        // determine walking direction
        float moveDirection = 1f;
        if (transform.position.x > waypoints[currentWaypointIndex].position.x)
        {
            // we need to move left
            moveDirection = -1f;
        }
        horizontalMove = moveDirection * movementSpeed;

        // ensure that the animator shows the correct animation
        animator.SetFloat("Speed", Mathf.Abs(moveDirection * movementSpeed));
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, false, false, false);
    }
}
