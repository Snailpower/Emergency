using UnityEngine;
using System.Collections;

public class MazeGeneration : MonoBehaviour {

    public GameObject wall;
    public GameObject floor;

    const int WALL = 1;
    const int UNVISITED = -1;
    const int FLOOR = 0;

    [SerializeField]
    int width = 10;
    [SerializeField]
    int height = 10;

    int[,] maze;

	// Use this for initialization
	void Start ()
    {
        GenerateMaze();
        Debug.Log(maze);
    }

    /// <summary>
    /// Want to make a maze in a square.
    /// The outside of the square is a wall
    /// </summary>
    void GenerateMaze()
    {
        maze = new int[width, height];

        //  horizontal
        for (int row = 0; row < height; row++)
        {
            //  vertical
            for (int column = 0; column < height; column++)
            {
                if (row == 0 || row == height-1 || column == 0 || column == width-1)
                {
                    maze[column, row] = WALL;
                    Instantiate(wall)
                }
                else
                {
                    maze[column, row] = UNVISITED;
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
