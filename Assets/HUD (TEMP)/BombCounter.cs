using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCounter : MonoBehaviour
{
	public LetterContainer LetterContainer { get => _letterContainer; private set => _letterContainer = value; }

	[SerializeField] private LetterContainer _letterContainer;

	public void UpdateBombs(int bombs)
	{
		LetterContainer.SetText(bombs.ToString());
	}
}
