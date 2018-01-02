using UnityEngine;
using System.Collections;

public class AutoObjectSpawner : MonoBehaviour
{
	[Header("Object creation")]

	// The object to spawn
	public GameObject prefabToSpawn;

	[Header("Other options")]

	// Configure the spawning pattern
	public float spawnInterval = 1;
	public int maxObjects;

	void Start ()
	{

		StartCoroutine(SpawnObject());
	}
	
	// This will spawn an object, and then wait some time, then spawn another...
	IEnumerator SpawnObject ()
	{
		// Counts the number of objects spawned
		int objectCount = 0;
		// Counts if the object is under the max amount of objects spawned
		while(objectCount < maxObjects)
		{
			// Generate the new object
			GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
			// Set the position of the spawned object
			newObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
			// Count them to ensure they don't go over the max amount of objects spawned
			objectCount = objectCount + 1; 

			// Wait for some time before spawning another object
			yield return new WaitForSeconds(spawnInterval);
		}
	}
}
