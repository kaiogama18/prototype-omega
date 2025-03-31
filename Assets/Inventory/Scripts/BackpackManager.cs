using System.Collections;
using UnityEngine;

public class BackpackManager : Inventory
{
    [SerializeField] private Player player;

    [SerializeField] private float moveToPlayerDuration = 0.25f;

    private Vector3 playerPosition;

    private void OnEnable()
    {
        Actions.AddItemToBackpack += MoveItemToPlayer; 
    }

    private void OnDisable()
    {
        Actions.AddItemToBackpack -= MoveItemToPlayer;  
    }
    
    private void Update()
    {
        playerPosition = player.transform.position;
    }
    
    public void MoveItemToPlayer(Drop drop)
    {
        StartCoroutine(AnimMoveItemToPlayer(drop));
    }

    IEnumerator AnimMoveItemToPlayer(Drop drop)
    {
        Vector3 startPosition = drop.transform.position;

        float timeElapsed = 0f;

        while (timeElapsed < moveToPlayerDuration && drop != null)
        {
            drop.transform.position = Vector3.Lerp(startPosition,
                new Vector3(playerPosition.x, 1f, playerPosition.z), 
                timeElapsed / moveToPlayerDuration);
            
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        drop.transform.position = new Vector3(playerPosition.x, 1f, playerPosition.z);

        AddItemToInventory(drop);
    }
}
