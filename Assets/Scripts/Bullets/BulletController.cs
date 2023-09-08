using UnityEngine;

public class BulletController : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.CompareTag("Player"))
        {
            var playerStatusController = collision.collider.gameObject.GetComponent<PlayerStatus>();
            playerStatusController.Die();
            gameManager.OnLoss();
        }
        if (collision.collider.gameObject.CompareTag("Ricochet"))
        {
            var velocity = collision.otherRigidbody.velocity;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90);
        }
    }
}
