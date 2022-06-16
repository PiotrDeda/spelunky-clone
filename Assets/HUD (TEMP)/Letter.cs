using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
	[field: SerializeField] public SpriteAtlas FontAtlas { get; protected set; }

	public void SetCharacter(char character)
	{
		Sprite letterSprite = FontAtlas.GetSprite(CharToFont(character));
		GetComponent<Image>().sprite = letterSprite ? letterSprite : FontAtlas.GetSprite("Space");
	}

	protected static string CharToFont(char character) =>
		character switch
		{
			' ' => "Space",
			'.' => "Dot",
			_ => character.ToString().ToUpper()
		};
}