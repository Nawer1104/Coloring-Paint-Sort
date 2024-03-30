using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Object : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();

    public int index;

    private void Start()
    {
        index = 0;

        SetUpByIndex(0);
    }

    public void SetUpByIndex(int number)
    {
        DisableAll();

        index = number;

        objects[index].SetActive(true);

        objects[index].transform.DOScale(1, 1f).OnComplete(() => {

            if (index >= objects.Count - 1) 
                GameManager.Instance.ResetGame();
        });
    }

    public void DisableAll()
    {
        foreach(GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }
}
