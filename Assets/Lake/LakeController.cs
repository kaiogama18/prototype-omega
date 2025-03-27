using UnityEngine;
using System.Collections.Generic;

public class LakeController : MonoBehaviour, IInteractable
{
    //public GameObject itemDrop;
    [SerializeField] private List<GameObject> listOfItemsToDrop;
    [SerializeField] private float heightOffset = 1f;


    public void Interact()
    {
        GameObject randomItem = listOfItemsToDrop[Random.Range(0, listOfItemsToDrop.Count)];


        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + heightOffset, transform.position.z);
        Instantiate(randomItem, newPosition, Quaternion.identity);



        //Actions.OnDropItem?.Invoke(1);
    }
}
