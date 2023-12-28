using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ICollidable collidable))
        {
            collidable.HandleCollisionWithPlayer(GetComponent<Player>());
        }
    }
}
