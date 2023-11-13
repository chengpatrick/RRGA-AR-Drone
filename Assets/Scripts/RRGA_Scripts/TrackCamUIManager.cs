using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCamUIManager : MonoBehaviour
{
	[SerializeField] private GameObject win_txt;
	[SerializeField] private GameObject crack_img;
	[SerializeField] private float crack_time;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void setWinText()
	{
		win_txt.SetActive(true);
	}

	public void setCrack()
	{
		StartCoroutine(ScreenCrack(crack_time));
	}

	IEnumerator ScreenCrack(float t)
	{
		crack_img.SetActive(true);
		yield return new WaitForSeconds(t);
		crack_img.SetActive(false);
	}
}
