using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : Enemy {

    
    public Rigidbody2D myRigidbody;
    [Header("Target Variables")]
    public Transform target;
    public float chaseRadius;
    public float attackRadius;

    [Header("Animator")]
    public Animator anim;


	// Use this for initialization
	void Start () {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        CheckDistance();
	}

    public virtual void CheckDistance()
    {
        if(Vector3.Distance(target.position, 
                            transform.position) <= chaseRadius
           && Vector3.Distance(target.position,
                               transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position,
                                                         target.position,
                                                         moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }
        }else if (Vector3.Distance(target.position,
                            transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
        }
    }

    public void SetAnimFloat(Vector2 setVector){
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    public void changeAnim(Vector2 direction){
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0){
                SetAnimFloat(Vector2.right);
            }else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y)){
            if(direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    public void ChangeState(EnemyState newState){
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
