using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawnCollider : MonoBehaviour
{

    public float positionY = 0.81f;
    public Transform[] PathSpawnPoints;
    public GameObject Path;
    public GameObject DangerousBorder;
    public Transform[] CollectibleSpawnPoints;
    public GameObject[] Collectibles;
    public int maxCollectibleForward;
    public int maxCollectibleUp;
    public int maxSpawnables;

    void OnTriggerEnter(Collider hit)
    {
        //player has hit the collider
        if (hit.gameObject.tag == "Player")
        {
            //find whether the next path will be straight, left or right
            int randomSpawnPoint = Random.Range(0, PathSpawnPoints.Length);
            for (int i = 0; i < PathSpawnPoints.Length; i++)
            {
                //instantiate the path, on the set rotation
                if (i == randomSpawnPoint)
                    Instantiate(Path, PathSpawnPoints[i].position, PathSpawnPoints[i].rotation);
                else
                {
                    //instantiate the border, but rotate it 90 degrees first
                    Vector3 rotation = PathSpawnPoints[i].rotation.eulerAngles;
                    rotation.y += 90;
                    Vector3 position = PathSpawnPoints[i].position;
                    position.y += positionY;
                    Instantiate(DangerousBorder, position, Quaternion.Euler(rotation));
                }
            }

            for (int i = 0; i < maxSpawnables; i++)
            {
                int randomCollectibleSpawn = Random.Range(0, CollectibleSpawnPoints.Length);
                int randomCollectible = Random.Range(0, Collectibles.Length);
                int randomForward = Random.Range(0, maxCollectibleForward);
                int randomUp = Random.Range(0, maxCollectibleUp);
                float forward = CollectibleSpawnPoints[randomCollectibleSpawn].position.z + randomForward;
                float up = CollectibleSpawnPoints[randomCollectibleSpawn].position.y + randomUp;
                Vector3 finalSpawnPoint = new Vector3(CollectibleSpawnPoints[randomCollectibleSpawn].position.x, up, forward);
                GameObject go = Instantiate(Collectibles[randomCollectible], finalSpawnPoint, CollectibleSpawnPoints[randomSpawnPoint].rotation);
                go.SetActive(true);
            }
        }
    }

}