using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public List<Mask> masks = new List<Mask>();

    public bool isFull;

    public GameObject vfxFull;

    Vector2 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        isFull = CheckMask();
    }

    private bool CheckMask()
    {
        for (int i = 0; i < masks.Count - 1; i++)
        {
            if (masks[i].type != masks[i + 1].type)
            {
                return false;
            }
        }
        return true;
    }

    private bool CheckEmpty()
    {
        if (masks[0].type == Type.None && masks[1].type == Type.None && masks[2].type == Type.None)
            return true;
        else
            return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GetComponent<DragAndDrop>().isSelected)
            return;

        if (collision != null && collision.gameObject.CompareTag("Object"))
        {
            GetComponent<DragAndDrop>()._dragging = false;

            if (isFull)
            {
                GameObject vfx = Instantiate(vfxFull, transform.position, Quaternion.identity) as GameObject;
                Destroy(vfx, 1f);

                gameObject.SetActive(false);

                collision.gameObject.GetComponent<Object>().SetUpByIndex(collision.gameObject.GetComponent<Object>().index + 1);
            }
            else
            {
                transform.position = startPos;

                return;
            }

        }

        if (collision != null && collision.gameObject.CompareTag("Bottle") && !isFull)
        {
            GetComponent<DragAndDrop>()._dragging = false;

            if (collision.gameObject.GetComponent<Bottle>().HaveRoomToFill())
            {
                if (CheckEmpty())
                {
                    transform.position = startPos;

                    return;
                }

                collision.gameObject.GetComponent<Bottle>().SetUpperMaskType(GetTypeToFill());

                transform.position = startPos;
            }
            else
            {
                transform.position = startPos;

                return;
            }

        }
    }

    public bool HaveRoomToFill()
    {
        if (masks[0].type == Type.None || masks[1].type == Type.None || masks[2].type == Type.None)
            return true;
        else
            return false;
    }

    public Type GetTypeToFill()
    {
        Type typeToFill = Type.None;

        for (int i = 0; i < masks.Count - 1; i++)
        {
            if (masks[i].type != Type.None)
            {
                typeToFill = masks[i].type;
                masks[i].SetType(Type.None);
                break;
            }
            else
                continue;
        }
        return typeToFill;
    }

    public void SetUpperMaskType(Type type)
    {
        if (CheckEmpty())
        {
            masks[2].SetType(type);
        }
        else
        {
            if (masks[1].type == Type.None)
            {
                masks[1].SetType(type);
            }
            else
            {
                masks[0].SetType(type);
            }
        }
    }
}
