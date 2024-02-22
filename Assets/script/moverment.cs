using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private Animator anim;
    private float horizontalInput;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        System.Console.WriteLine(horizontalInput);
        Vector2 movement = new Vector2(horizontalInput, 0f);
        rb.velocity = movement * speed;
        //quay dau
        flip();
        //anim
        anim.SetFloat("move", Mathf.Abs(horizontalInput));
        

    }

    void flip()
    {
        if (isFacingRight & horizontalInput < 0
        || !isFacingRight & horizontalInput > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 size = transform.localScale;
            size.x = size.x * -1;
            transform.localScale = size;
        }
    }

    public bool canAttack()
    {
        return horizontalInput == 0;
    }
}