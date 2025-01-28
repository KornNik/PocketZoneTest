﻿using System;
using UnityEngine;
using Behaviours;
using Data;
using Helpers.Extensions;
using Controllers;

namespace Helpers
{
    sealed class Services
    {
        private static readonly Lazy<Services> _instance = new Lazy<Services>();

        public static Services Instance => _instance.Value;
        public Service<ICameraController> CameraController { get; private set; }
        public Service<IAudioPlayer> AudioPlayer { get; private set; }
        public Service<ISettingsController> SettingsController { get; private set; }
        public Service<ITimeController> TimeController { get; private set; }
        public Service<DatasBundle> DatasBundle { get; private set; }
        public Service<ILevelLoader> LevelLoader { get; private set; }
        public Service<GameStateBehaviour> GameStateBehavior { get; private set; }
        public Service<DataResourcePrefabs> DataResourcePrefabs { get; private set; }
        public Service<InputActions> Inputs { get; private set; }
        public Service<UnitController> PlayerController { get; private set; }
        public Service<Level> Level { get; private set; }

        public Services()
        {
            Initialize();
        }

        private void Initialize()
        {
            CameraController = new Service<ICameraController>();
            AudioPlayer = new Service<IAudioPlayer>();
            SettingsController = new Service<ISettingsController>();
            TimeController = new Service<ITimeController>();
            DatasBundle = new Service<DatasBundle>();
            LevelLoader = new Service<ILevelLoader>();
            GameStateBehavior = new Service<GameStateBehaviour>();
            DataResourcePrefabs = new Service<DataResourcePrefabs>();
            Inputs = new Service<InputActions>();
            PlayerController = new Service<UnitController>();
            Level = new Service<Level>();
        }

    }
}
