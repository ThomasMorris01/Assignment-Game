using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(BoxCollider2D))]
public class AutoObjectSpawner : MonoBehaviour
{
	[Header("Object creation")]

	// The object to spawn
	public GameObject prefabToSpawn;

	[Header("Other options")]

	// Configure the spawning pattern
	public float spawnInterval = 1;
	public int maxObjects;

	private BoxCollider2D boxCollider2D;

	void Start ()
	{
		boxCollider2D = GetComponent<BoxCollider2D>();

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
			// Create some random numbers
			float randomX = Random.Range (-boxCollider2D.size.x, boxCollider2D.size.x) *.5f;
			float randomY = Random.Range (-boxCollider2D.size.y, boxCollider2D.size.y) *.5f;

			// Generate the new object
			GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
			// Set the position of the spawned object
			newObject.transform.position = new Vector2(50, -8);
			// Count them to ensure they don't go over the max amount of objects spawned
			objectCount = objectCount + 1; 

			// Wait for some time before spawning another object
			yield return new WaitForSeconds(spawnInterval);
		}
	}
}
