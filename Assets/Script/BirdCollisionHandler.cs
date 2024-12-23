using UnityEngine;

public class BirdCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyManager.Instance.RemoveEnemy(collision.gameObject);
            Destroy(collision.gameObject);
       
        }
    }


    private void Update()
    {
        Destroy(gameObject, 10f);
    }
}
