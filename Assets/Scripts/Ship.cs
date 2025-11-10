using UnityEngine;

public class Ship : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 thrustDirection = new Vector2(1,0);
    private const float thrustForce = 5f;
    private float colliderRadius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        colliderRadius = GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float thrustInput = Input.GetAxis("Thrust");

        if (thrustInput > 0)
        {
            rb2D.AddForce(thrustDirection * thrustForce, ForceMode2D.Force);
        }
    }

    private void OnBecameInvisible()
    {
        Vector2 newPosition = transform.position;

        // Check horizontal wrap
        if (transform.position.x > ScreenUtils.ScreenRight)
        {
            newPosition.x = ScreenUtils.ScreenLeft;
        }

        else if (transform.position.x < ScreenUtils.ScreenLeft)
        {
            newPosition.x = ScreenUtils.ScreenRight;
        }

        // Check vertical wrap
        if (transform.position.y > ScreenUtils.ScreenTop)
        {
            newPosition.x = ScreenUtils.ScreenBottom;
        }

        else if (transform.position.y < ScreenUtils.ScreenBottom)
        {
            newPosition.x = ScreenUtils.ScreenTop;
        }

        transform.position = newPosition;
    }
}