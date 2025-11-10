using UnityEngine;

public class Ship : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 thrustDirection = new Vector2(1,0);
    private const float thrustForce = 5f;
    private float colliderRadius;
    private const float rotateDegreesPerSecond = 90f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        colliderRadius = GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        float rotationInput = Input.GetAxis("Rotate");

        if (rotationInput != 0)
        {
            float rotationAmount = rotateDegreesPerSecond * Time.deltaTime;

            if (rotationInput < 0)
            {
                rotationAmount *= -1;
            }

            transform.Rotate(Vector3.forward, rotationAmount);

            float angleInRadians = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
        }
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
            newPosition.y = ScreenUtils.ScreenBottom;
        }

        else if (transform.position.y < ScreenUtils.ScreenBottom)
        {
            newPosition.y = ScreenUtils.ScreenTop;
        }

        transform.position = newPosition;
    }
}