using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public bool IsAlive { get; private set; } = true;

    public void Die()
    {
        IsAlive = false;
        //death animation
    }
}
