using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using BS_Utils.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;

namespace CameraPlusCFGChange
{
    class Settings : PersistentSingleton<Settings>
    {
        private Config config;

        private string _defaultCamera;
        [UIValue("DefaultCamera_value")]
        public string DefaultCamera_value
        {
            get => _defaultCamera;
            set
            {
                _defaultCamera = value;
                config.SetString("Modes", "DefaultCamera", _defaultCamera.ToString());
            }
        }

        private string _gameCamera;
        [UIValue("GameCamera_value")]
        public string GameCamera_value
        {
            get => _gameCamera;
            set
            {
                _gameCamera = value;
                config.SetString("Modes", "GameCamera", _gameCamera.ToString());
            }
        }

        private string _outputCamera;
        [UIValue("OutputCamera_value")]
        public string OutputCamera_value
        {
            get => _outputCamera;
            set
            {
                _outputCamera = value;
                config.SetString("Modes", "OutputCamera", _outputCamera.ToString());
            }
        }
        public void Awake()
        {
            config = new Config("CameraPlusCFGChange");
            config.GetString("Modes", "MaterialChange", "ON");
            string getStr = config.GetString("Modes", "DefaultCamera", "");
            if (getStr != string.Empty)
                DefaultCamera_value = getStr;
            else
                DefaultCamera_value = "cameraplus.cfg";


            getStr = config.GetString("Modes", "GameCamera", "");
            if (getStr != string.Empty)
                GameCamera_value = getStr;
            else
                GameCamera_value = string.Empty;


            getStr = config.GetString("Modes", "OutputCamera", "");
            if (getStr != string.Empty)
                OutputCamera_value = getStr;
            else
                OutputCamera_value = string.Empty;
        }


    }
}
