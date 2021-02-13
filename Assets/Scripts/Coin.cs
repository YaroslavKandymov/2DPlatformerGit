using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        Destroy(gameObject);
    }
}
