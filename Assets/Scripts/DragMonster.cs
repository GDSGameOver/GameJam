using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMonster : MonoBehaviour
{
    private bool _isDragging;

    public void OnMouseDown()
    {
        _isDragging = true;
    }

    public void OnMouseUp()
    {
        _isDragging = false;
    }

    void Update()
    {
        if (_isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Furniture furniture))
        {
            _isDragging = false;
        }
    }
}
