using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState //state machine for player
{
    walk,
    attack, 
    interact //curently not being used
}


public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    public Vector3 change;
    private Animator animator;
    public FloatValue currentHealth; //keeps track of user's health
    public Signals playerHealthSignal;

    // Start is called before the first frame update
    void Start()
    {
        //currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody =  GetComponent<Rigidbody2D>();
        //start user as pointing down
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack) //not already attacking and attacked button pressed
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk) //if in walk state
        {
            UpdateAnimationAndMove();
        }

    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null; //wait one frame
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.20f); //wait for animation to be displayed
        currentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove(){
        if (change != Vector3.zero){
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving",true);
        }else{
            animator.SetBool("moving",false);
        }
    }
    void MoveCharacter()
    {
        change.Normalize(); //ensure no super-speed diagonal movement
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }

    public void decreaseHealth(float amount)
    {
        print("Told to decrease health");
        if (currentHealth.RuntimeValue > 0)
        {
            currentHealth.RuntimeValue -= amount;
            playerHealthSignal.Raise();
        } else
        {
            this.gameObject.SetActive(false); //hides player upon death
        }
    }
}
