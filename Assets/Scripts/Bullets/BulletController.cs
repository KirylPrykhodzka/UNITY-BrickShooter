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
            case "GreenBrick":
                {
                    Destroy(collision.gameObject);
                    Ricochet();
                    SpeedUp();
                    break;
                }
            case "YellowBrick":
                {
                    Destroy(collision.gameObject);
                    Split();
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

    private void SpeedUp()
    {
        body.velocity *= 2;
    }

    private void Split()
    {
        var originalVelocity = body.velocity;
        var originalBullet = gameObject;
        var newBullet = bulletsStorage.GetBullet();

        body.velocity = new Vector2(originalVelocity.x * 1.2f, originalVelocity.y * 0.8f);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(originalVelocity.x * 0.8f, originalVelocity.y * 1.2f);

        Ricochet();
        newBullet.transform.SetPositionAndRotation(body.position, Quaternion.Euler(0, 0, Mathf.Atan2(newBullet.GetComponent<Rigidbody2D>().velocity.y, newBullet.GetComponent<Rigidbody2D>().velocity.x) * Mathf.Rad2Deg - 90));
    }
}
