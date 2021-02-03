using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Serializable]
    private struct SpawnObject
    {
        [SerializeField] private KeyCode _key;
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Transform _spawnPoint;

        public KeyCode GetKey() { return _key; }
        public GameObject GetObject() { return _gameObject; }
        public Vector3 GetPosition() { return _spawnPoint.position; }
    }
    
    [SerializeField] private SpawnObject[] _spawnObjects;

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        foreach (var spawnObject in _spawnObjects)
        {
            if (Input.GetKeyDown(spawnObject.GetKey()))
            {
                Create(spawnObject.GetObject(), spawnObject.GetPosition());
            }
        }
    }

    private void Create(GameObject spawnObject, Vector3 position)
    {
        Instantiate(spawnObject, position, Quaternion.identity);
    }
}
