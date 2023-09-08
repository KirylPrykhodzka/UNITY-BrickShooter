using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject bricks;

    void Update()
    {
        if(bricks.transform.childCount == 0)
        {
            OnVictory();
        }
    }

    void OnVictory()
    {
        Time.timeScale = 0;
    }

    public void OnLoss()
    {
        Time.timeScale = 0;
    }
}
