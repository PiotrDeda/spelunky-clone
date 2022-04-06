using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	[field: SerializeField] public GameObject MainCamera { get; protected set; }
	[field: SerializeField] public GameObject Player { get; protected set; }
	[field: SerializeField] public GameObject LoadingScreen { get; protected set; }

	public int Area { get; private set; }
	public int Level { get; private set; }

	void Awake()
	{
		if (Instance is null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); Destroy(gameObject); }
	}

	void Start()
	{
		Area = 1;
		Level = 1;
		StartCoroutine(LevelSetup());
	}

	void Update()
	{
		MainCamera.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, MainCamera.transform.position.z);
	}

	IEnumerator LevelSetup()
	{
		Time.timeScale = 0;
		yield return new WaitForEndOfFrame();
		LoadingScreen.SetActive(false);
		Time.timeScale = 1;
	}
}
