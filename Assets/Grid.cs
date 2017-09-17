using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
	private const int START_SIDE_LEN = 5;
	private const int MAX_SIDE_LEN = 20;
	private int sideLen = START_SIDE_LEN;
	private List<Building> buildings = new List<Building>();
	public Sprite gridSprite;
	//public Texture2D gridTexture;
	//private List<List<GridSquare>> gridSquares = new List<List<GridSquare>>();

	//private List<GameObject> gridSquares = new List<GameObject>();
	private List<List<GameObject>> gridSquares = new List<List<GameObject>>();

	// Use this for initialization
	void Start () {
		makeGridSquares ();
	}

	void makeGridSquares() {
		for (int y = 0; y < sideLen; y++) {
			List<GameObject> row = new List<GameObject> ();
			for (int x = 0; x < sideLen; x++) {
				// grid sprites
				GameObject square = new GameObject();
				square.AddComponent<SpriteRenderer> ();
				SpriteRenderer spriteRend = square.GetComponent<SpriteRenderer> ();
				spriteRend.sprite = gridSprite;
				Texture2D texture = spriteRend.sprite.texture;
				Vector3 bounds = square.GetComponent<Renderer>().bounds.size;
				square.transform.position = new Vector3 ((x-sideLen/2.0f+1f/2f)*bounds[0], (y-sideLen/2.0f+1f/2f)*bounds[1]);
				//gridSquares.Add (square);
				row.Add(square);
			}
			gridSquares.Add (row);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	void addBuilding(Building b, int x, int y) {
		if (!inBounds (b, x, y)) {
			// TODO: handle this case
		}
		buildings.Add (b);
	}

	bool inBounds(Building b, int x, int y) {
		if (!(x >= 0 && y >= 0 && x < sideLen && y < sideLen))
			return false;
		for (int y2 = y; y2 < y + b.Height; y2++) {
			for (int x2 = x; x2 < x + b.Width; x2++) {
				if (gridSquares [y2] [x2].GetComponent<GridSquare> ().Occupied)
					return false;
			}
		}
		return true;
	}

	/*void increaseSideLen(int value)
	{
		Debug.Assert (value % 2 == 0);
		Debug.Assert (sideLen == gridSquares.Count);
		for (int i = 0; i < sideLen; i++) {
			// grid sprites
			GameObject square = new GameObject();
			square.AddComponent<SpriteRenderer> ();
			SpriteRenderer spriteRend = square.GetComponent<SpriteRenderer> ();
			spriteRend.sprite = gridSprite;
			Texture2D texture = spriteRend.sprite.texture;
			Vector3 bounds = square.GetComponent<Renderer>().bounds.size;
			square.transform.position = new Vector3 ((x-sideLen/2.0f+1f/2f)*bounds[0], (y-sideLen/2.0f+1f/2f)*bounds[1]);


			gridSquares.Insert(0, 
		}
	}*/
}