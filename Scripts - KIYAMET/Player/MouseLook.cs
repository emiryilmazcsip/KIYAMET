using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour // This is the Mouse Script. This is how the player interacts with mouse movement. 
{
    public float sensitivity = 1.5f;
    public float smoothing = 1.5f;

    private float xMousePos;
    private float yMousePos;
    private float xRotation = 0f;
    private float yRotation = 0f;

    private Vector2 smoothedMousePos;

    private void Start() // When the player is playing. Hide cursor.
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() // This lets the cursor be unlocked as it it is locked to access menu.
    {
        GetInput();
        ModifyInput();
        MovePlayer();

        if (PauseMenu.GameIsPaused)
        {
            PauseMenu.SetCursorState(false); // Unlock the cursor when paused
        }
    }

    private void GetInput() // Up and down mouse movement. 
    {
        xMousePos = Input.GetAxisRaw("Mouse X");
        yMousePos = Input.GetAxisRaw("Mouse Y");
    }

    private void ModifyInput()
    {
        xMousePos *= sensitivity * smoothing;
        yMousePos *= sensitivity * smoothing;

        smoothedMousePos.x = Mathf.Lerp(smoothedMousePos.x, xMousePos, 1f / smoothing);
        smoothedMousePos.y = Mathf.Lerp(smoothedMousePos.y, yMousePos, 1f / smoothing);

        xRotation -= smoothedMousePos.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += smoothedMousePos.x;
    }

    private void MovePlayer()
    {
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
