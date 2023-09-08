using System.Collections.Generic;
using UnityEngine;

public class BulletsStorage : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    Queue<GameObject> bullets = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    bullets.Enqueue(Instantiate(bulletPrefab));
        //}
    }

    public GameObject GetBullet()
    {
        if(bullets.Count == 0)
        {
            return Instantiate(bulletPrefab);
        }
        return bullets.Dequeue();
    }
}
