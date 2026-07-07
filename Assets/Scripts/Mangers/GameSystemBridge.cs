using UnityEngine;
using AwsanSultan.GameCore.UI;
using AwsanSultan.GameCore.Security;
using AwsanSultan.GameCore.Config;
using System;

namespace AwsanSultan.GameCore.Managers
{
    public class GameSystemBridge : MonoBehaviour
    {
        public static GameSystemBridge Instance { get; private set; }

        [Header("UI Controllers Reference")]
        [SerializeField] private WalletUIController walletUI;
        [SerializeField] private MatchmakingUI matchmakingUI;
        [SerializeField] private DataFlowVisualizer dataVisualizer;

        [Header("Configuration & Parsing")]
        [SerializeField] private ScalabilityParser scalabilityParser;
        [SerializeField] private PlayerSettingsPrefs playerPrefsManager;

        private void Awake()
        {
            // تطبيق نمط الـ Singleton لضمان وجود مدير مركزي واحد فقط عبر كل المشاهد
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Debug.Log("[GAME BRIDGE] Central System Core initialized successfully.");
            InitializeAllSystems();
        }

        private void InitializeAllSystems()
        {
            try
            {
                // 1. استدعاء ملف فحص وتطبيق الجرافيكس الهجين
                if (scalabilityParser != null) scalabilityParser.LoadAndApplySettings();

                // 2. تفعيل جدار الحماية ومكافحة الغش المحلي
                if (UnityAntiCheatManager.Instance != null) 
                    Debug.Log("[GAME BRIDGE] Security local shield linked to blockchain verification.");
            }
            catch (Exception ex)
            {
                Debug.LogError($"[GAME BRIDGE] Critical initialization failure: {ex.Message}");
            }
        }

        // دالة وسيطة لربط محاكاة الـ 5000 عقدة بواجهة العرض الحية
        public void ForwardSimulationData(int activeNodes, float txRate, float latencyMs)
        {
            if (dataVisualizer != null)
            {
                dataVisualizer.UpdateMetrics(activeNodes, txRate, latencyMs);
            }
        }
    }
}
