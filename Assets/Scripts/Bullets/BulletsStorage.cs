using System.Collections.Generic;
using UnityEngine;

public class BulletsStorage : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    readonly Queue<GameObject> bulletPool = new();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        if(bulletPool.Count == 0)
        {
            return Instantiate(bulletPrefab);
        }
        var bullet = bulletPool.Dequeue();
        bullet.SetActive(true);
        return bullet;
    }

    public void ReturnToStorage(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
