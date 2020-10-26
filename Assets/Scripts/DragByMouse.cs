using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragByMouse : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    Collider2D _collider2D;

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();    
    }

    void OnMouseDown()

    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;



        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }



    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    void OnMouseDrag()

    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Furniture furniture))
        {
            Debug.Log(transform.position);
            transform.position = new Vector3(0,0,0);
        }
    }
}
