using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public Item item;
    
    [SerializeField] private GameObject gameObj;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private float moveToPlayerDuration = 0.25f;
    [SerializeField] private float lifeTime = 100f;

    private MeshFilter staticMesh;
    private Vector3 playerPosition;


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

    private void MoveToPlayer()
    {
        StartCoroutine(AnimMoveItemToPlayer());
    }

    IEnumerator AnimMoveItemToPlayer()
    {
        Vector3 startPosition = transform.position;
        float timeElapsed = 0f;
        while (timeElapsed < moveToPlayerDuration)
        {
            transform.position = Vector3.Lerp(startPosition,
                new Vector3(playerPosition.x, 1f, playerPosition.z),
                timeElapsed / moveToPlayerDuration);

            timeElapsed += Time.deltaTime;
            yield return null;
        }
        Actions.AddItemToInventory(this);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.TryGetComponent(out Player player))
        {
            playerPosition = player.transform.position;
            MoveToPlayer();
        }
    }

    public void OnDestroyItem()
    {
        Destroy(gameObject);
    }
}
