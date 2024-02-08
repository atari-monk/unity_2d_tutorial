using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private float dirX = 0f;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update() 
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        if (Input.GetButtonDown("Jump")) {
            rb.velocity = new Vector2(rb.velocity.x, 14f);
        }

        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate() 
    {
        if (dirX > 0f) {
            anim.SetBool("running", true);
            sprite.flipX = false;
        } 
        else if (dirX < 0f) 
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        } 
        else 
        {
            anim.SetBool("running", false);
        }
    }
}