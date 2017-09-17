using UnityEngine;
using System.Collections;
using UnityEditor;

public class NewTileMapMenu {

	[MenuItem("GameObject/New Puzzle")]
	public static void CreateTileMap() {
		GameObject puzzle = new GameObject ("Tiles");
		Board puzzleScript = puzzle.AddComponent<Board> ();
		puzzleScript.tilePadding = new Vector2 (2f,2f);
		GameObject board = new GameObject ("Board");
		board.tag = "Board";
		board.AddComponent<SpriteRenderer> ();
		board.GetComponent<SpriteRenderer> ().sprite=puzzleScript.boardSprite;
		board.transform.position = new Vector3 (0,0.57f,0);
		Sprite boardSprite = board.GetComponent<SpriteRenderer> ().sprite;
		float newX = -boardSprite.bounds.size.x / 2f + GameManager.boardBorderWidth;
		float newY = boardSprite.bounds.size.y / 2f - GameManager.boardBorderWidth;
		puzzle.transform.SetParent (board.transform);
		puzzle.transform.localPosition = new Vector3 (newX,newY,0);
	}
}
