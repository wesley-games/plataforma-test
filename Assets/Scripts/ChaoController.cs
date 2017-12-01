using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoController : MonoBehaviour {

	public float velocidade = 60f;

	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.down * velocidade * Time.deltaTime;
	}
}
