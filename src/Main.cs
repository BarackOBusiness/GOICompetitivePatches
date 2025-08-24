using BepInEx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CompetitivePatches
{
    [BepInPlugin("goi.core.competitivepatches", "Competitive Patches", "0.1.1")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Competitive patches have loaded!");

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode _mode)
        {
            switch (scene.name) {
                case "Gems and Minerals": // Cavern map
                    GameObject rotary = GameObject.Find("Rotary");
                    Rigidbody2D[] bodies = rotary.GetComponentsInChildren<Rigidbody2D>();
                    foreach (Rigidbody2D body in bodies) {
                        body.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
                    }
                    break;
                default: // Do nothing to other scenes
                    break;
            }
        }
    }
}
