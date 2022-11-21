using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    //Prefabs
    public GameObject[] WallPrefabs;
    public GameObject[] GoodCubesPrefabs;
    //Options for bad walls generator
    public int MinCountWalls;
    public int MaxCountWalls;
    public float DistanceBetweenWalls;
    //Options for good cubes generator
    private float minForX = -4;
    private float maxForX = 5;
    private float minForZ = 3;
    private float maxForZ = 11;
    //Transforms
    public Transform Finish1;
    public Transform Finish2;
    public Transform LastFinish;
    public Transform Road;
    public Transform Player;
    public Transform Level;
    public Level LevelScript;
    //Options for objects transform's component
    private float allObjectsPositionY = -1.25f;
    private float finishPositionX = 0;
    private Vector3 roadPosition = new Vector3(0, -2.2f, 50);
    private float roadScaleX = 10;
    private float roadScaleY = 1;
    //other
    public float PlayerPositionZ;
    private Random random;
    private int levelIndex;

    private void Awake()
    {
        levelIndex = LevelScript.LevelIndex;
        random = new Random(levelIndex);
        int wallsCount = RandomRange(random, MinCountWalls, MaxCountWalls + 1);
        int cubesCount = 3;
        for (int i = 0; i < wallsCount; i++)
        {
            int prefabIndex = RandomRange(random, 0, WallPrefabs.Length);
            CreateBadWall(i, prefabIndex);

            for (int j = 0; j < cubesCount; j++)
            {
                //random2 = new Random(levelIndex);
                int cubePrefabIndex = RandomRange(random, 0, GoodCubesPrefabs.Length);
                CreateGoodCube(i, cubePrefabIndex);
            }
        }
        Finish1.localPosition = new Vector3(finishPositionX, allObjectsPositionY, wallsCount * DistanceBetweenWalls);
        Finish2.localPosition = new Vector3(finishPositionX, allObjectsPositionY / 2, wallsCount * DistanceBetweenWalls + Finish1.localScale.z);
        LastFinish.localPosition = new Vector3(finishPositionX, allObjectsPositionY / 3 + 0.23f, wallsCount * DistanceBetweenWalls + Finish2.localScale.z * 2);
        Road.localPosition = roadPosition;
        Road.localScale = new Vector3(roadScaleX, roadScaleY, wallsCount * DistanceBetweenWalls * 2);
        Player.position = new Vector3(0, Road.position.y + 0.5f, Level.transform.position.z - 10);
    }


    private void CreateBadWall(int i, int prefabIndex)
    {
        GameObject wall = Instantiate(WallPrefabs[prefabIndex], transform);
        wall.transform.localPosition = new Vector3(0, allObjectsPositionY, DistanceBetweenWalls * i);
    }


    private void CreateGoodCube(int i, int cubePrefabIndex)
    {
        GameObject goodCube = Instantiate(GoodCubesPrefabs[cubePrefabIndex], transform);
        Vector3 vector3 = new Vector3(RandomRange(random, minForX, maxForX), allObjectsPositionY, DistanceBetweenWalls * i - RandomRange(random, minForZ, maxForZ));
        goodCube.transform.localPosition = vector3;
    }

    private int RandomRange(Random random, int min, int maxExclusive)
    {
        int number = random.Next();
        int length = maxExclusive - min;
        number %= length;
        return min + number;
    }
    private float RandomRange(Random random, float min, float max)
    {
        float t = (float) random.NextDouble();
        return Mathf.Lerp(min, max, t);
    }
}
