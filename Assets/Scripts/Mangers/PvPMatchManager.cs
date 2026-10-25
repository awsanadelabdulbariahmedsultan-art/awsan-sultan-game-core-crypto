using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using AwsanSultan.GameCore.Core; // ربط مباشر بمحرك الذكاء الاصطناعي والتحديث الآلي

/**
 * @className AsgccPvPMatchManager
 * @version v3.7-External-Bridge
 * @date October 25, 2026
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice External smart bridge that links natively with the legacy PvPMatchManager 
 *         to inject AI Teammates and trigger DLSS updates without modifying the original file.
 */
namespace AwsanSultan.GameCore.Core
{
    public class AsgccPvPMatchManager : MonoBehaviour
    {
        // وثيقة إثبات الحقوق البرمجية وحماية الابتكار للمطور الرئيسي للمشروع
        public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
        public const string DeveloperID = "01010305468";
        public const string DeploymentDate = "2026-10-25";

        [Header("Ecosystem Monitoring")]
        [SerializeField] private bool monitorLegacyMatchManager = true;
        
        public bool isAiTeammateDeployed { get; private set; } = false;
        public static AsgccPvPMatchManager Instance { get; private set; }

        private void Awake()
        {
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
            // بدء المراقبة الآلية التشغيلية للملف القديم في الخلفية دون مقاطعته
            if (monitorLegacyMatchManager)
            {
                StartCoroutine(AutomatedLegacyMatchListener());
            }
        }

        /**
         * @notice حلقة برمجية صامتة تراقب حالة الكود القديم وتتدخل لحقن الـ AI التكتيكي فوراً
         */
        private IEnumerator AutomatedLegacyMatchListener()
        {
            while (true)
            {
                // التحقق ما إذا كان الملف القديم متواجداً في المشهد وقام بتفعيل المعركة
                if (PvPMatchManager.Instance != null)
                {
                    // عندما يكتشف أن الكود القديم قام بتفعيل المباراة (isMatchActive == true)
                    if (PvPMatchManager.Instance.isMatchActive && !isAiTeammateDeployed)
                    {
                        // سحب نقاط الـ XP الحقيقية من الكود القديم وتمريرها لمحرك الذكاء الاصطناعي الخاص بك
                        uint legacyXp = PvPMatchManager.Instance.playerTotalXp;
                        InitiateMatchmakingPipeline(legacyXp);
                    }
                    // عندما تنتهي المباراة في الكود القديم
                    else if (!PvPMatchManager.Instance.isMatchActive && isAiTeammateDeployed)
                    {
                        TerminateCurrentMatch(true);
                    }
                }
                yield return new WaitForSeconds(1.0f); // فحص ذكي كل ثانية واحدة لحماية المعالج
            }
        }

        /**
         * @notice دالة حقن الـ AI Teammate بناءً على البيانات المستقاة من الملف الأصلي
         */
        public void InitiateMatchmakingPipeline(uint playerXp)
        {
            isAiTeammateDeployed = true;
            Debug.Log($"[{DeveloperName} - External Bridge: {DeploymentDate}] Legacy PvP Lobby Detected Active. Injecting adaptive AI Teammate for Player XP: {playerXp}");

            if (AsgccAiEngine.Instance != null)
            {
                AsgccAiEngine.Instance.GenerateNpcResponse("Engage Battle Support Protocol", playerXp, (aiTextResponse) => {
                    Debug.Log($"[Dynamic AI Teammate Active]: {aiTextResponse}");
                });
            }
        }

        public void TerminateCurrentMatch(bool isVictory)
        {
            isAiTeammateDeployed = false;
            Debug.Log($"[{DeveloperName} - External Bridge] Clean shutdown. AI Teammate removed safely.");
        }
    }
}
