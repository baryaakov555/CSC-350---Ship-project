using UnityEngine;

public class Ship : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 thrustDirection = new Vector2(1,0);
    private const float thrustForce = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
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
}