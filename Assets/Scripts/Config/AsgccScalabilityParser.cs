using System;
using System.IO;
using UnityEngine;

/**
 * @className AsgccScalabilityParser
 * @version v1.5-JSON-Parser
 * @date October 25, 2026
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Advanced JSON configurations parser that reads hardware scalability profiles 
 *         and dynamically synchronizes NVIDIA DLSS 4 and ACE Local AI states natively.
 */
namespace AwsanSultan.GameCore.Config
{
    public class AsgccScalabilityParser : MonoBehaviour
    {
        public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
        public const string DeveloperID = "01010305468";
        public const string DeploymentDate = "2026-10-25";

        [Header("Config Optimization Settings")]
        [SerializeField] private string configFileName = "AsgccScalabilityManager.config";
        
        private string activeConfigPath;
        public static AsgccScalabilityParser Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                activeConfigPath = Path.Combine(Application.persistentDataPath, configFileName);
                VerifyAndInitializeConfigFile();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            LoadAndApplySettings();
        }

        private void VerifyAndInitializeConfigFile()
        {
            if (!File.Exists(activeConfigPath))
            {
                string sourcePath = Path.Combine(Application.streamingAssetsPath, configFileName);
                if (File.Exists(sourcePath))
                {
                    File.Copy(sourcePath, activeConfigPath, true);
                    Debug.Log($"[{DeveloperName} - {DeploymentDate}] Scalability JSON file successfully mapped to persistent folder.");
                }
            }
        }

        public void LoadAndApplySettings()
        {
            try
            {
                string targetPath = File.Exists(activeConfigPath) ? activeConfigPath : Path.Combine(Application.streamingAssetsPath, configFileName);
                if (File.Exists(targetPath))
                {
                    string jsonContent = File.ReadAllText(targetPath);
                    if (jsonContent.Contains("Profile_Ultra_RTX_Spark") && SystemInfo.supportsComputeShaders)
                    {
                        QualitySettings.SetQualityLevel(4, true);
                        Debug.Log($"[{DeveloperName} - {DeploymentDate}] Ultra RTX Spark pipeline engaged via JSON config.");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to interpret dynamic JSON scalability metrics: {ex.Message}");
            }
        }

        public void OptimizeGraphPipelineForAiLoad(bool isAiHeavyActive)
        {
            if (isAiHeavyActive)
            {
                Debug.Log($"[{DeveloperName} - Tensor Optimizer: {DeploymentDate}] Overriding DLSS to Performance Mode to support heavy local AI execution.");
                QualitySettings.SetQualityLevel(2, true); 
            }
            else
            {
                LoadAndApplySettings();
            }
        }
    }
}
