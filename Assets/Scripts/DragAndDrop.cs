using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool _dragging;

    private Vector2 _offset;

    public static bool mouseButtonReleased;

    public bool isSelected;

    private void Awake()
    {
        isSelected = false;
    }

    private void OnMouseDown()
    {

        isSelected = true;

        _dragging = true;

        _offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        if (!_dragging) return;

        isSelected = true;

        var mousePosition = GetMousePos();

        transform.position = mousePosition - _offset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void OnMouseUp()
    {
        isSelected = false;

        mouseButtonReleased = true;
    }

    private Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}