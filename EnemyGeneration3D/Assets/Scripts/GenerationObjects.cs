using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationObjects : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform[] _pointsSpawn;
    [SerializeField] int _numberEnemy;

    private Coroutine _generationEnemy;
    private float _timeGeneration = 2f;
    private int _minNumberRandom = 0;

    private void Start()
    {
        TurnOnGenerationEnemy();
    }

    private void TurnOnGenerationEnemy()
    {
        _generationEnemy = StartCoroutine(GenerationEnemy());
    }

    private IEnumerator GenerationEnemy()
    {        
        for (int i = 0; i < _numberEnemy; i++)
        {
            yield return new WaitForSeconds(_timeGeneration);
            int randomPoinGeneration = Random.Range(_minNumberRandom, _pointsSpawn.Length);
            Instantiate(_enemy, _pointsSpawn[randomPoinGeneration]);           
        }
    }
}
