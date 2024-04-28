using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 10f;
    public float momentumDamping = 5f;

    private CharacterController myCC;
    public Animator camAnim;
    private bool isWalking;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float myGravity = -50f;

    void Start()
    {
        myCC = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // Check for 'P' key press to pause
        {
            PauseGame();
        }

        if (!GameManager.IsGamePaused) // Only update movement if the game is not paused
        {
            GetInput();
            MovePlayer();

            camAnim.SetBool("isWalking", isWalking);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) // Check for left shift key press to return to Main Menu
        {
            ReturnToMainMenu();
        }
    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D))
        {
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            inputVector.Normalize();
            inputVector = transform.TransformDirection(inputVector);

            isWalking = true;
        }
        else
        {
            inputVector = Vector3.Lerp(inputVector, Vector3.zero, momentumDamping * Time.deltaTime);

            isWalking = false;
        }

        movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity);
    }

    void MovePlayer()
    {
        myCC.Move(movementVector * Time.deltaTime);
    }

    void PauseGame()
    {
        GameManager.TogglePause(); // Call GameManager to toggle pause state
    }

    void ReturnToMainMenu()
    {
        GameManager.ReturnToMainMenu(); // Call GameManager to return to Main Menu
    }
}

public static class GameManager
{
    private static bool isGamePaused = false;

    public static bool IsGamePaused
    {
        get { return isGamePaused; }
    }

    public static void TogglePause()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            Time.timeScale = 0f; // Pause time
        }
        else
        {
            Time.timeScale = 1f; // Resume time
        }
    }

    public static void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Ensure time is resumed
        SceneManager.LoadScene("MainMenu"); // Load Main Menu scene
    }
}
