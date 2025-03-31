using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

    public Item item;

    [SerializeField] private GameObject gameObj;
    private MeshFilter staticMesh;
    private float lifeTime = 10f; 
    void Start()
    {
        gameObj.SetActive(true);
        staticMesh =   gameObj.GetComponent<MeshFilter>();
        staticMesh.mesh = item.staticMesh;
    }

    void Update()
    {
        this.transform.Rotate(Vector3.up, (item.rotationSpeed * 2) * Time.deltaTime);
        Destroy(this.gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Actions.AddItemToBackpack(this);
        }
    }

    public void OnDestroyItem()
    {
        Destroy(gameObject);
    }
}
