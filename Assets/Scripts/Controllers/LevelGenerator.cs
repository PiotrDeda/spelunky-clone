using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	[field: SerializeField] protected List<LevelObject> LevelObjects { get; set; } = new();

	void Start()
	{
		List<string> levelLines = System.IO.File.ReadAllLines("Assets/Levels/test.txt").ToList();
		float x = 0, y = 0;
		foreach (string line in levelLines)
		{
			foreach (char character in line)
			{
				foreach (LevelObject levelObject in LevelObjects)
				{
					if (character == levelObject.Character)
					{
						Instantiate(levelObject.Object, new Vector3(x, y), Quaternion.identity);
						break;
					}
				}
				x++;
			}
			x = 0;
			y--;
		}
	}
}

[System.Serializable]
public struct LevelObject
{
	public char Character;
	public GameObject Object;
}