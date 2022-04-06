using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCounter : MonoBehaviour
{
	public LetterContainer LetterContainer { get => _letterContainer; private set => _letterContainer = value; }

	[SerializeField] private LetterContainer _letterContainer;

	public void UpdateHealth(int health)
	{
		LetterContainer.SetText(health.ToString());
	}
}
