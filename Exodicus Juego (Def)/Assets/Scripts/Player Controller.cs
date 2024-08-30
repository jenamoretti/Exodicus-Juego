using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float horizontalMove;
    private float verticalMove;
    public CharacterController player;
    public float speed;

    private Vector3 playerInput;
    private Vector3 movePlayer;

    public Camera mainCamera;
    private Vector3 forward;
    private Vector3 side;

    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDir();

        movePlayer = playerInput.x * side + playerInput.z * forward;

        player.transform.LookAt(player.transform.position + movePlayer);

        player.Move(playerInput * speed * Time.deltaTime);
    }

    void camDir()
    {
        forward = mainCamera.transform.forward;
        side = mainCamera.transform.right;

        forward.y = 0;
        side.y = 0;

        forward = forward.normalized;
        side = side.normalized;
    }
}
