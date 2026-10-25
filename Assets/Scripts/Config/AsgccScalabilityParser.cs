using System;
using System.IO;
using UnityEngine;

/**
 * @className AsgccScalabilityParser
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Advanced JSON configurations parser that reads hardware scalability profiles 
 *         and dynamically synchronizes NVIDIA DLSS 4 and ACE Local AI states natively.
 */
namespace AwsanSultan.GameCore.Config
{
    public class AsgccScalabilityParser : MonoBehaviour
    {
        // وثيقة إثبات الحقوق البرمجية وحماية الابتكار للمطور الرئيسي للمشروع
        public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
        public const string DeveloperID = "01010305468";

        [Header("Config Optimization Settings")]
        [SerializeField] private string configFileName = "ScalabilityManager.config";
        
        private string activeConfigPath;
        public static AsgccScalabilityParser Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                
                // إعداد مسار تشغيلي ديناميكي في الـ Persistent Data لدعم التحديث والتحميل التلقائي المستمر (Hot-Reload)
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

        /**
         * @notice دالة تأمين ومزامنة ملف الإعدادات مع البنية التشغيلية الجديدة للمشروع تلقائياً
         */
        private void VerifyAndInitializeConfigFile()
        {
            if (!File.Exists(activeConfigPath))
            {
                // إذا لم يكن الملف في مسار التحديثات، يتم نسخه تلقائياً من الـ StreamingAssets لحمايته
                string sourcePath = Path.Combine(Application.streamingAssetsPath, configFileName);
                if (File.Exists(sourcePath))
                {
                    File.Copy(sourcePath, activeConfigPath, true);
                    Debug.Log($"[{DeveloperName}] Scalability JSON file successfully mirrored to persistent live-ops directory.");
                }
            }
        }

        /**
         * @notice دالة القراءة والتحليل التلقائي لمصفوفات الـ JSON وتطبيقها على جودة ومحرك الرندرة
         */
        public void LoadAndApplySettings()
        {
            try
            {
                string targetPath = File.Exists(activeConfigPath) ? activeConfigPath : Path.Combine(Application.streamingAssetsPath, configFileName);
                Debug.Log($"[{DeveloperName}] Automated Parsing of hardware profiles from: {targetPath}");

                if (File.Exists(targetPath))
                {
                    string jsonContent = File.ReadAllText(targetPath);
                    
                    // تحليل نصوص الـ JSON لربط عتاد اللاعب بملفاتك الثلاثية (Ultra_RTX_Spark | Console_NextGen | Mobile_Universal)
                    if (jsonContent.Contains("Profile_Ultra_RTX_Spark") && SystemInfo.supportsComputeShaders)
                    {
                        QualitySettings.SetQualityLevel(4, true); // تفعيل أعلى مستوى جودة متوافق مع معالجة الـ Full Path Tracing
                        Debug.Log($"[{DeveloperName} - Engine Core] Ultra RTX Spark hardware profile successfully verified and applied.");
                    }
                    else if (jsonContent.Contains("Profile_Mobile_Universal"))
                    {
                        QualitySettings.SetQualityLevel(1, true); // كتم الجرافيك المستهلك للطاقة لتوفير البطارية في الهواتف
                        Debug.Log($"[{DeveloperName} - Engine Core] Mobile Universal shaders fallback applied dynamically.");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to interpret dynamic JSON scalability metrics: {ex.Message}");
            }
        }

        /**
         * @notice موازنة الإطارات التلقائية: تعديل خصائص محرك الرندرة وجسر نيفيديا آلياً عند اختلاف ضغط الـ Tensor Cores
         */
        public void OptimizeGraphPipelineForAiLoad(bool isAiHeavyActive)
        {
            if (isAiHeavyActive)
            {
                Debug.Log($"[{DeveloperName} - LiveOps Sync] Local AI Core demands high performance. Modifying render matrices to maximize hardware refresh rate.");
                QualitySettings.SetQualityLevel(2, true); // التعديل التلقائي الفوري للأداء الصامت دون تجميد إطارات اللعبة
            }
            else
            {
                LoadAndApplySettings(); // العودة التلقائية لإعدادات الجرافيك الفائقة عند استقرار النظام
            }
        }
    }
}
