using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] private float force;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * force);
        }
    }

    void OnCollisionEnter2D(Collision2D other) => GameManager.Instance.GameOver();
}