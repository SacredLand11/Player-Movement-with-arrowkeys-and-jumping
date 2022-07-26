using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 3.0f;
    float rotationSpeed = 100.0f;
    float translation;
    float rotation;
    Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        MovementInputs(); //Define the movement inputs
        MovementAnimations(); //Define the Movement Boundaries
    }

    private void MovementAnimations()
    {
        if (translation > 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("direction", 1);
        }
        else if (translation < 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("direction", -1);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown("space"))
        {
            anim.SetTrigger("isJumping");
        }
    }

    private void MovementInputs()
    {
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }
}
