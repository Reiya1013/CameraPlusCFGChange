using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEngine;
using BS_Utils.Utilities;

namespace CameraPlusCFGChange
{
    /// <summary>
    /// Monobehaviours (scripts) are added to GameObjects.
    /// For a full list of Messages a Monobehaviour can receive from the game, see https://docs.unity3d.com/ScriptReference/MonoBehaviour.html.
    /// </summary>
    public class CameraPlusCFGChangeController : MonoBehaviour
    {
        public static CameraPlusCFGChangeController instance { get; private set; }

        private string ChangedCfg;

        #region Monobehaviour Messages
        /// <summary>
        /// Only ever called once, mainly used to initialize variables.
        /// </summary>
        private void Awake()
        {
            // For this particular MonoBehaviour, we only want one instance to exist at any time, so store a reference to it in a static property
            //   and destroy any that are created while one already exists.
            if (instance != null)
            {
                Logger.log?.Warn($"Instance of {this.GetType().Name} already exists, destroying.");
                GameObject.DestroyImmediate(this);
                return;
            }
            GameObject.DontDestroyOnLoad(this); // Don't destroy this object on scene changes
            instance = this;
            Logger.log?.Debug($"{name}: Awake()");
            Settings.instance.Awake();
        }
        /// <summary>
        /// Only ever called once on the first frame the script is Enabled. Start is called after any other script's Awake() and before Update().
        /// </summary>
        private void Start()
        {
            BSEvents.gameSceneLoaded += this.OnGameSceneLoaded;
            BSEvents.menuSceneLoaded += this.OnMenuSceneLoaded;
        }
        private void OnGameSceneLoaded()
        {
            Logger.log?.Debug($"{name}: OnGameSceneLoaded Start");
            if (Settings.instance.GameCamera_value != string.Empty && Settings.instance.OutputCamera_value != string.Empty)
            {
                Logger.log?.Debug($"{name}: OnGameSceneLoaded Change");
                ReturnCFG(Settings.instance.DefaultCamera_value);
                ChangedCFG(Settings.instance.GameCamera_value);
                Logger.log?.Debug($"{name}: OnGameSceneLoaded Compleat");
            }
        }
        private void OnMenuSceneLoaded()
        {
            Logger.log?.Debug($"{name}: OnMenuSceneLoaded Start");
            if (Settings.instance.DefaultCamera_value != string.Empty && Settings.instance.OutputCamera_value != string.Empty)
            {
                Logger.log?.Debug($"{name}: OnMenuSceneLoaded Change");
                ReturnCFG(Settings.instance.GameCamera_value);
                ChangedCFG(Settings.instance.DefaultCamera_value);
                Logger.log?.Debug($"{name}: OnMenuSceneLoaded Compleat");
            }
        }

        private void ReturnCFG(string retrunName)
        {
            if (ChangedCfg == null) return;
            try
            {
                Logger.log?.Debug($"{ System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"..\..\"}");
                string directryName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"..\..\";

                System.IO.File.Copy(directryName + @"\UserData\CameraPlus\" + Settings.instance.OutputCamera_value, directryName + @"\UserData\CameraPlus\" + retrunName, true);
            }
            catch (Exception e)
            {
                Logger.log?.Debug($"{e.Message}");
            }
        }

        private void ChangedCFG(string changedName)
        {
            ChangedCfg = changedName;
            try
            {
                Logger.log?.Debug($"{ System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"..\..\"}");
                string directryName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"..\..\";

                System.IO.File.Copy(directryName + @"\UserData\CameraPlus\" + changedName, directryName + @"\UserData\CameraPlus\" + Settings.instance.OutputCamera_value, true);
            }
            catch (Exception e)
            {
                Logger.log?.Debug($"{e.Message}");
            }
        }

        /// <summary>
        /// Called when the script is being destroyed.
        /// </summary>
        private void OnDestroy()
        {
            Logger.log?.Debug($"{name}: OnDestroy()");
            instance = null; // This MonoBehaviour is being destroyed, so set the static instance property to null.

        }
        #endregion
    }
}
