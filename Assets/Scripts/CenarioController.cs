using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioController : MonoBehaviour
{

	public GameObject chao;

	private int maxObjects = 10;
	private float height = 2f;
	private float minY = -10f;
	private float maxY = 10f;
	private float maxX = 4f;
	private float minX = -4f;
	private Queue<GameObject> objects;

	void Start ()
	{
		objects = new Queue<GameObject> ();
		objects.Enqueue (Instantiate (chao, new Vector3 (0, 0, 0), Quaternion.identity));
		for (int i = 1; i < maxObjects; i++) {
			objects.Enqueue (Instantiate (chao, new Vector3 (Random.Range (minX, maxX), i * height, 0), Quaternion.identity));
		}
	}

	void FixedUpdate ()
	{
		if (reposiciona ()) {
			reposicionar ();
		}
	}

	private bool reposiciona ()
	{
		GameObject obj = objects.Peek ();
		Rigidbody2D rigidBody = obj.GetComponent<Rigidbody2D> ();
		return rigidBody.transform.position.y < minY;
	}

	private void reposicionar ()
	{
		GameObject obj = objects.Dequeue ();
		obj.transform.position = new Vector3 (Random.Range (minX, maxX), maxY, 0);
		objects.Enqueue (obj);
	}
}
