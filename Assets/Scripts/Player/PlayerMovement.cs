using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private Rigidbody2D playerBody;

    private int movementX = 0;
    private int movementY = 0;

    private void Start()
    {
        playerBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) || (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)))
        {
            movementY = 0;
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                movementY = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movementY = -1;
            }
        }

        if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) || (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)))
        {
            movementX = 0;
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                movementX = 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                movementX = -1;
            }
        }
    }

    private void FixedUpdate()
    {
        playerBody.AddForce(new Vector2(movementX * Time.deltaTime * moveSpeed, movementY * Time.deltaTime * moveSpeed));
    }
}
