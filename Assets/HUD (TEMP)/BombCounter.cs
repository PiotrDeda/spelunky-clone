using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCounter : MonoBehaviour
{
	[field: SerializeField] public LetterContainer LetterContainer { get; protected set; }

	public void UpdateBombs(int bombs)
	{
		LetterContainer.SetText(bombs.ToString());
	}
}
