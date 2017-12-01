using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

	private Text score;
	private int counter = 0;

	void Start ()
	{
		score = GetComponent<Text> ();
	}

	void FixedUpdate ()
	{
		score.text = ((int)(counter++ * Time.deltaTime)).ToString ();
	}
}
