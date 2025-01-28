﻿using UnityEngine;
using Helpers;
using Behaviours;
using Helpers.Extensions;

namespace Data
{
    [CreateAssetMenu(fileName = "ResourcesData", menuName = "Data/ResourcesData")]
    sealed class DataResourcePrefabs : ScriptableObject
    {
        [SerializeField] private GameObject _cameraPrefab;
        [SerializeField] private GameStateBehaviour _gameStatePrefab;
        [SerializeField] private EnemiesBundle _enemiesBundle;
        [SerializeField] private GameObject _playerPrefab;

        [SerializeField] private SerializableDictionary<ScreenTypes, GameObject> _screensPrefabs;
        [SerializeField] private SerializableDictionary<AudioTypes, GameObject> _audioPrefabs;

        public GameObject GetScreenPrefab(ScreenTypes screenType)
        {
            GameObject screenPrefab = default;
            if (_screensPrefabs.Contains(screenType))
            {
                screenPrefab = _screensPrefabs[screenType];
            }
            return screenPrefab;
        }
        public GameObject GetAudioPrefab(AudioTypes audioType)
        {
            GameObject audioPrefab = default;
            if (_audioPrefabs.Contains(audioType))
            {
                audioPrefab = _audioPrefabs[audioType];
            }
            return audioPrefab;
        }
        public EnemiesBundle GetEnemiesBundle()
        {
            return _enemiesBundle;
        }
        public GameObject GetCamerPrefab()
        {
            return _cameraPrefab;
        }
        public GameStateBehaviour GetGameStatePrefab()
        {
            return _gameStatePrefab;
        }
        public GameObject GetPlayerPrefab()
        {
            return _playerPrefab;
        }

    }
}
