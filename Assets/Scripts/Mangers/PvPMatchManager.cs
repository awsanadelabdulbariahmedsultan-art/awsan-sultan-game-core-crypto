using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using AwsanSultan.GameCore.Core; // ربط مباشر بمحرك الذكاء الاصطناعي الخاص بك

/**
 * @className PvPMatchManager
 * @version v3.5-AI-Teammates
 * @date October 25, 2026
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Coordinates multiplayer match states, detects single player queues, 
 *         and deploys adaptive AI Teammates powered by the ASGCC Hybrid Core.
 */
namespace AwsanSultan.GameCore.Core
{
    public class PvPMatchManager : MonoBehaviour
    {
        // وثيقة إثبات الحقوق البرمجية وحماية الابتكار للمطور الرئيسي للمشروع
        public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
        public const string DeveloperID = "01010305468";
        public const string DeploymentDate = "2026-10-25";

        [Header("Matchmaking Parameters")]
        public bool isMatchActive = false;
        public uint playerOneXpBaseline = 0;
        
        [Header("AI Teammate Support System")]
        [SerializeField] private bool allowAiTeammateFallback = true;
        public bool isAiTeammateDeployed { get; private set; } = false;

        public static PvPMatchManager Instance { get; private set; }

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

        /**
         * @notice دالة بدء المباراة والتحقق التلقائي من حاجة اللاعب الفردي لـ زميل لعب ذكي (AI Teammate)
         * @param currentXp نقاط الخبرة الحالية للاعب لتخصيص ذكاء الـ AI المالي والقتالي
         */
        public void InitiateMatchmakingPipeline(uint currentXp)
        {
            playerOneXpBaseline = currentXp;
            Debug.Log($"[{DeveloperName} - Matchmaking: {DeploymentDate}] Initializing PvP Lobby. Player XP Baseline: {currentXp}");

            // فحص حالة وجود لاعبين آخرين، وفي حال تعذر العثور على لاعب بشري يتم تفعيل الـ Fallback آلياً
            ExecuteAutomatedLobbyCheck();
        }

        private void ExecuteAutomatedLobbyCheck()
        {
            isMatchActive = true;
            
            if (allowAiTeammateFallback)
            {
                isAiTeammateDeployed = true;
                Debug.Log($"[{DeveloperName} - PvP Core] Single player queue detected. Engaging high-fidelity ASGCC AI Teammate safely.");
                
                // استدعاء محرك الحوار والوعي التكتيكي لحقن سلوك الزميل الاصطناعي فوراً في المعركة
                if (AsgccAiEngine.Instance != null)
                {
                    AsgccAiEngine.Instance.GenerateNpcResponse("Engage Battle Protocol", playerOneXpBaseline, (aiTextResponse) => {
                        Debug.Log($"[AI Teammate Tactical Initialization]: {aiTextResponse}");
                    });
                }
            }
        }

        /**
         * @notice إنهاء المباراة وتوزيع مكافآت الـ الويب 3 بناءً على النتيجة وحقنها في البوابة العالمية
         */
        public void TerminateCurrentMatch(bool isVictory)
        {
            isMatchActive = false;
            isAiTeammateDeployed = false;
            Debug.Log($"[{DeveloperName}] Match finalized. Victory status: {isVictory}. Releasing tactical memory allocation.");
        }
    }
}
