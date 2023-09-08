using UnityEngine;

public class BulletController : MonoBehaviour
{
    private GameManager gameManager;
    private BulletsStorage bulletsStorage;
    private Rigidbody2D body;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        bulletsStorage = FindObjectOfType<BulletsStorage>();
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.collider.gameObject.tag)
        {
            case "Player":
                {
                    var playerStatusController = collision.collider.gameObject.GetComponent<PlayerStatus>();
                    playerStatusController.Die();
                    gameManager.OnLoss();
                    break;
                }
            case "Wall":
                {
                    Ricochet();
                    break;
                }
            case "RedBrick":
                {
                    Destroy(collision.gameObject);
                    bulletsStorage.ReturnToStorage(gameObject);
                    break;
                }
            case "BlueBrick":
                {
                    Destroy(collision.gameObject);
                    Ricochet();
                    break;
                }
            default: break;
        }
    }

    private void Ricochet()
    {
        var velocity = body.velocity;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90);
    }
}
