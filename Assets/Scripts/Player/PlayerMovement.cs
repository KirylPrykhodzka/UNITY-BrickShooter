using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
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

        var mousePosition = Input.mousePosition;
        var playerPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePosition.x = mousePosition.x - playerPosition.x;
        mousePosition.y = mousePosition.y - playerPosition.y;
        var angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        playerBody.AddForce(new Vector2(movementX * Time.deltaTime * moveSpeed, movementY * Time.deltaTime * moveSpeed));
    }
}
