using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletsStorage;
    [SerializeField] GameObject barrelTip;
    [SerializeField] float bulletSpeed;

    private BulletsStorage bulletsStorageScript;

    private void Start()
    {
        bulletsStorageScript = bulletsStorage.GetComponent<BulletsStorage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            var bullet = bulletsStorageScript.GetBullet();
            bullet.transform.SetPositionAndRotation(barrelTip.transform.position, barrelTip.transform.rotation);
            var angle = barrelTip.transform.rotation.eulerAngles.z + 90;
            var forceX = Mathf.Cos(angle * Mathf.Deg2Rad) * bulletSpeed;
            var forceY = Mathf.Sin(angle * Mathf.Deg2Rad) * bulletSpeed;
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        }
    }
}
