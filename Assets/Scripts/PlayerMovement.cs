using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 2.0f; 
	private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;
    private Transform tr;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        tr = transform;
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove ()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x); 
            animator.SetFloat("moveY", change.y);      
            animator.SetBool("moving", true);       
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            position += Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            position += Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            position += Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            position += Vector3.up;
        }
        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);

       // myRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    public string GetDirection ()
    {
        if(change.x > 0)
        {
            return "Right";
        }
        else if(change.x < 0)
        {
            return "Left";
        }
        else if(change.y > 0)
        {
            return "Up";
        }
        else if(change.y < 0)
        {
            return "Down";
        }
        return "Staying Still";
    }
}
