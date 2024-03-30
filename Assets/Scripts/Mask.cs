using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public Type type;

    public GameObject orange;
    public GameObject red;
    public GameObject purple;
    public GameObject white;

    private void Start()
    {
        SetUpType();
    }

    private void SetUpType()
    {
        switch (type)
        {
            case Type.None:
                DisableAll();
                break;

            case Type.Orange:
                DisableAll();
                orange.SetActive(true);
                break;

            case Type.Red:
                DisableAll();
                red.SetActive(true);
                break;

            case Type.Purple:
                DisableAll();
                purple.SetActive(true);
                break;

            case Type.White:
                DisableAll();
                white.SetActive(true);
                break;
        }
    }

    private void DisableAll()
    {
        orange.SetActive(false);
        red.SetActive(false);
        purple.SetActive(false);
        white.SetActive(false);
    }

    public void SetType(Type type)
    {
        this.type = type;

        SetUpType();
    }
}
