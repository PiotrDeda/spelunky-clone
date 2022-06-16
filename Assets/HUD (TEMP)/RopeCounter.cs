using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCounter : MonoBehaviour
{
	[field: SerializeField] public LetterContainer LetterContainer { get; protected set; }

	public void UpdateRopes(int ropes)
	{
		LetterContainer.SetText(ropes.ToString());
	}
}
