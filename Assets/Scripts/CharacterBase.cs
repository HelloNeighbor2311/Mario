using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public enum ActionType
{
    Left, Right, Jump
}
public abstract class CharacterBase : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRedenrer;
    public Rigidbody2D rigidbody2D;
    public float speed, jumpForce;
    public bool groundCheck;
    
    public abstract void Init();
    public abstract void hit();
    public virtual void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(ActionType.Left);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            Move(ActionType.Right);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            Move(ActionType.Jump);
        }
        if (!Input.anyKey) {
            rigidbody2D.velocity = new Vector2(0,rigidbody2D.velocity.y);
            animator.Play("IDLE");
        }
    }
    public virtual void Die()
    {

    }
    public virtual void Move(ActionType param)
    {
        if (groundCheck == true)
        {
            switch (param)
            {
                case ActionType.Left:

                    rigidbody2D.velocity = new Vector2(-1, 0) * speed;
                    spriteRedenrer.transform.localScale = new Vector3(-1, 1, 1);
                    animator.Play("Move");
                    break;
                case ActionType.Right:
                    rigidbody2D.velocity = new Vector2(1, 0) * speed;
                    spriteRedenrer.transform.localScale = new Vector3(1, 1, 1);
                    animator.Play("Move");
                    break;
                case ActionType.Jump:

                    rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x, 2 * jumpForce) );
                    animator.Play("Jump");

                    break;
                
            }
        }
    }
}
