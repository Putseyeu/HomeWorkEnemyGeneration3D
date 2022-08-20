using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform[] _pointsSpawn;
    [SerializeField] private int _numberEnemy;
    [SerializeField] private float _delay;

    private Coroutine _generationEnemy;
    private int _minNumberRandom = 0;

    private void Start()
    {
        _generationEnemy = StartCoroutine(GenerationEnemy());
    }

    private IEnumerator GenerationEnemy()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        for (int i = 0; i < _numberEnemy; i++)
        {
            yield return waitForSeconds;
            int randomPoinGeneration = Random.Range(_minNumberRandom, _pointsSpawn.Length);
            Instantiate(_enemy, _pointsSpawn[randomPoinGeneration]);
        }
    }
}
