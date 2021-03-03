using System;
using UnityEngine;

public class SnakeInput : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    public Vector2 GetDirectionToClick(Vector3 headPosition)
    {
        Vector3 mousePosition = Input.mousePosition;

        //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); TODO: Как в лекции у меня не работает, возможно из версии юнити
        //mousePosition = GetMousePosition(headPosition);
        mousePosition = _camera.ScreenToViewportPoint(mousePosition);
        mousePosition.y = 1;
        
        //mousePosition = _camera.ViewportToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 5f));
        mousePosition = _camera.ViewportToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, GetDistanceZ(headPosition.z)));

        var direction = new Vector2(mousePosition.x - headPosition.x, mousePosition.y - headPosition.y);

        return direction;
    }

    private float GetDistanceZ(float distanceZ)
    {
        const float module = -1f;
        var distance = (Camera.main.transform.position.z - distanceZ);
        
        if (distance < 0) distance *= module;

        return distance;
    }
}
