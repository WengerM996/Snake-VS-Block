using System;
using UnityEngine;
using UnityEngine.Events;

public class SnakeHead : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;

    public event UnityAction BlockCollided; 
    public event UnityAction<int> BonusCollected; 

    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 newPosition)
    {
        _rigidBody2D.MovePosition(newPosition);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Block block))
        {
            BlockCollided?.Invoke();
            block.Fill();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Bonus bonus))
        {
            BonusCollected?.Invoke(bonus.Collect());
        }
    }
}
