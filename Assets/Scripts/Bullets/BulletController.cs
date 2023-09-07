using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Ricochet")
        {
            //using x and y velocity, find next z rotation
            var velocity = collision.otherRigidbody.velocity;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg + 90);
        }
    }
}
