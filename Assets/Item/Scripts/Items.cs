using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public static Items Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public GameObject rock;
}
