using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ICollidable collidable))
        {
            collidable.HandleCollisionWithPlayer(_player);
        }
    }
}
