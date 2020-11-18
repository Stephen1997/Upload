using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFreeAnim : MonoBehaviour {

	//bool isOpen = false;
	Animator anim;

	// Use this for initialization
	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		CheckKey();
	}

	void CheckKey()
	{
		// Walk
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
		{
			anim.SetBool("Walk_Anim", true);
		}
		else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S))
		{
			anim.SetBool("Walk_Anim", false);
		}

		// Roll
		if (Input.GetKeyDown(KeyCode.Space))
		{
			RollAnimation();
		}

		// Close
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			CloseAnimation();
		}
	}

	private void RollAnimation()
	{
		if (anim.GetBool("Roll_Anim"))
		{
			anim.SetBool("Roll_Anim", false);
		}
		else
		{
			anim.SetBool("Roll_Anim", true);
		}
	}

	private void CloseAnimation()
	{
		if (!anim.GetBool("Open_Anim"))
		{
			anim.SetBool("Open_Anim", true);
		}
		else
		{
			anim.SetBool("Open_Anim", false);
		}
	}
}
