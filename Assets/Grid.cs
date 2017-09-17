using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
	private const int START_SIDE_LEN = 8;
	private const int MAX_SIDE_LEN = 20;
	private int sideLen = START_SIDE_LEN;
	private List<Building> buildings = new List<Building>();
	public Sprite gridSprite;
	private bool placingPiece = false;
	private GameObject buildingGameObj = null;
	private Vector3 tileBound;
	private int placeX = 0, placeY = 0;
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
				square.AddComponent<BoxCollider2D> ();
				square.AddComponent<GridSquare> ();
				square.GetComponent<GridSquare> ().gridLoc = new Vector2 (x, y);
				SpriteRenderer spriteRend = square.GetComponent<SpriteRenderer> ();
				spriteRend.sprite = gridSprite;
				Texture2D texture = spriteRend.sprite.texture;
				Vector3 bounds = square.GetComponent<Renderer>().bounds.size;
				tileBound = bounds;
				square.transform.position = new Vector3 ((x-sideLen/2.0f+1f/2f)*bounds[0], (y-sideLen/2.0f+1f/2f)*bounds[1]);
				//gridSquares.Add (square);
				row.Add(square);
			}
			gridSquares.Add (row);
		}
	}

	// Update is called once per frame
	void Update () {
		if (!placingPiece) {
			//Debug.Log ("not placing piece\n");
			if (Input.GetKeyDown (KeyCode.L)) {
				buildingGameObj = keyPlace<Lounge> ();
				placingPiece = true;
			} else if (Input.GetKeyDown (KeyCode.G)) {
				buildingGameObj = keyPlace<Garage> ();
				placingPiece = true;
			} else if (Input.GetKeyDown (KeyCode.J)) {
				buildingGameObj = keyPlace<Dump> ();
				placingPiece = true;
			}
		} else {
			Building placeBuilding = buildingGameObj.GetComponent<Building> ();
			if (inBounds (placeBuilding, placeX, placeY))
				placeBuilding.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, .5f);
			else
				placeBuilding.GetComponent<SpriteRenderer> ().color = new Color (1f, .5f, .5f, .5f);
			if (Input.GetKeyDown (KeyCode.W)) {
				Vector3 pos = placeBuilding.transform.position;
				placeY++;
				placeBuilding.transform.position = new Vector3(pos[0], pos[1] + tileBound[1]);
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				Vector3 pos = placeBuilding.transform.position;
				placeY--;
				placeBuilding.transform.position = new Vector3(pos[0], pos[1] - tileBound[1]);
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				Vector3 pos = placeBuilding.transform.position;
				placeX++;
				placeBuilding.transform.position = new Vector3(pos[0] + tileBound[1], pos[1]);
			}
			if (Input.GetKeyDown (KeyCode.A)) {
				Vector3 pos = placeBuilding.transform.position;
				placeX--;
				placeBuilding.transform.position = new Vector3(pos[0] - tileBound[1], pos[1]);
			}
			if (Input.GetKeyDown (KeyCode.Escape)) {
				Destroy (buildingGameObj);
				placingPiece = false;
				placeX = placeY = 0;
			}
			if (Input.GetKey (KeyCode.Return)) {
				Debug.Log ("Enter Pressed, "+placeX+", "+placeY+"\n");
				if (inBounds (placeBuilding, placeX, placeY)) {
					Debug.Log ("In Bounds");
					addBuilding (placeBuilding, placeX, placeY);
					placingPiece = false;
					placeX = placeY = 0;
					placeBuilding.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
				}
			}
		}
	}

	private GameObject keyPlace<T> () where T: Building {
		GameObject placeItem = new GameObject ();
		placeItem.AddComponent<T> ();
		placeItem.AddComponent<SpriteRenderer> ();
		T building = placeItem.GetComponent<T> ();
		//Sprite buildingSprite = Resources.Load ("breakroom 0", typeof(Sprite)) as Sprite;//building.getLevel0Sprite ();
		Sprite buildingSprite = building.getLevel0Sprite();

		placeItem.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, .5f);

		Vector3 buildingPos = new Vector3 ((0 - sideLen / 2.0f) * tileBound [0] + 1f / 2f * buildingSprite.bounds.size [0],
			(0 - sideLen / 2.0f) * tileBound [1] + 1f / 2f * buildingSprite.bounds.size [1]);
		building.transform.position = buildingPos;

		Debug.Log (buildingSprite);
		placeItem.GetComponent<SpriteRenderer> ().sprite = buildingSprite;
		return placeItem;
		//lounge.GetComponent<SpriteRenderer>().sprite.
	}

	void addBuilding(Building b, int x, int y) {
		/*if (!inBounds (b, x, y)) {
			// TODO: handle this case
		}*/
		buildings.Add (b);
		for (int y2 = y; y2 < y + b.Height; y2++) {
			for (int x2 = x; x2 < x + b.Width; x2++) {
				gridSquares [y2] [x2].GetComponent<GridSquare> ().Occupied = true;
			}
		}
	}

	bool inBounds(Building b, int x, int y) {
		if (!(x >= 0 && y >= 0 && x < sideLen && y < sideLen))
			return false;
		for (int y2 = y; y2 < y + b.Height; y2++) {
			for (int x2 = x; x2 < x + b.Width; x2++) {
				if (!(x2 >= 0 && y2 >= 0 && x2 < sideLen && y2 < sideLen))
					return false;
				if (gridSquares [y2] [x2].GetComponent<GridSquare> ().Occupied)
					return false;
			}
		}
		return true;
	}

	public List<Building> Buildings {
		get { return buildings; }
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