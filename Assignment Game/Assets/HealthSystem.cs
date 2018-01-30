using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour 
{
	public int health = 3;

	private UIScript ui;
	private int maxHealth;

	// Use this for initialization
	private void Start () 
	{
		ui = GameObject.FindObjectOfType<UIScript>(); 
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
