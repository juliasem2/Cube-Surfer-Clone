using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCube : MonoBehaviour
{
    public GameObject CubePrefab;
    public Transform PlaerRoot;
    private Vector3 _targetPosition;
    public int GoodCubesCount;
    private AudioSource _audio;
    public Player Player;
    //public AudioClip _audioGetGoodCube;

    private void Awake()
    {
       _audio = GetComponent<AudioSource>();
    }
    //adding new cubes
    private void OnTriggerEnter(Collider other)
    {
        //_audio.PlayOneShot(_audioGetGoodCube);
        _audio.Play();
        for (int i = 0; i < GoodCubesCount; i++)
        {
            Transform _bottomCube = GetBottomCubePosition(other);
            ChangeCubePosition changeCubePosition = other.GetComponentInParent<ChangeCubePosition>();

            changeCubePosition.ChangePosition();

            _targetPosition = new Vector3(_bottomCube.position.x, _bottomCube.position.y - 1, _bottomCube.position.z);
            GameObject newCube = Instantiate(CubePrefab, _targetPosition, Quaternion.identity);

            changeCubePosition.Cubes.Add(newCube);
        }
        this.gameObject.SetActive(false);
    }


    //getting bottom cube's position
    private static Transform GetBottomCubePosition(Collider other)
    {
        List<GameObject> _cubes = other.GetComponentInParent<ChangeCubePosition>().Cubes;
        Transform _bottomCube = _cubes[^1].transform;
        return _bottomCube;
    }
}
