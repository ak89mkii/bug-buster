using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Tutorial Link: https://www.youtube.com/watch?v=dwcT-Dch0bA
    // STEP 01.
    public CharacterController2D controller;
    // STEP Animations.
    public Animator animator;

    // Used in STEP 02.
    public float runSpeed = 40f;

    // Used in STEP 02 and 03.
    float horizontalMove = 0f;

    // Used in STEP 04 and 05.
    bool jump = false;
    
    // Used in STEP 06 and 07.
    bool crouch = false;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        // STEP 02: Detects left and right inputs as range from -1 to 1.
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        // STEP Walk Animation.
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // STEP 04: Detects input for jump functionality.
        if (Input.GetButtonDown("Jump")) {
            jump = true;
            // Step Jump Animation.
            animator.SetBool("IsJumping", true);
        }

        // STEP 06 (Button Pressed): Detects input for crouch functionality.
        if (Input.GetButtonDown("Crouch")) {
            crouch = true;
        }

        // STEP 06 (No Button Pressed): Detects no input for crouch functionality.

        else if (Input.GetButtonUp("Crouch")) {
            crouch = false;
        }
        
    }

    // Step Jump Animation.
    public void OnLanding() {
        animator.SetBool("IsJumping", false);
    }

    // Step Crouch Under Platform Animation.
    public void OnCrouching(bool isCrouching) {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate() {
        
        // STEP 03: Used to move character.
        // The "Time.fixedDeltaTime" ensures that the character moves the same amount regardless of how many times the function is called.
        // STEP 05: Adds jump functionality then sets jump to false.
        // STEP 07: Adds crouch functionality.
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
