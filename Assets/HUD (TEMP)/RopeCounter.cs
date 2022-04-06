using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCounter : MonoBehaviour
{
	public LetterContainer LetterContainer { get => _letterContainer; private set => _letterContainer = value; }

	[SerializeField] private LetterContainer _letterContainer;

	public void UpdateRopes(int ropes)
	{
		LetterContainer.SetText(ropes.ToString());
	}
}
