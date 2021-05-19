using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] private float _force;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(Vector2.up * _force);
        }
    }

    void OnCollisionEnter2D(Collision2D other) => GameManager.Instance.GameOver();
}