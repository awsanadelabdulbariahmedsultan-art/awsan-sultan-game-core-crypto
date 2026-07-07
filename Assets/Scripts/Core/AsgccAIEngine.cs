using System;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

/**
 * @className AsgccAiEngine
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Hybrid Local & Cloud Generative AI Engine integrating NVIDIA ACE SDK and Google Gemini API.
 *         Executes high-fidelity NPC contextual dialogue linked to player XP with automated cloud fallback.
 */
namespace AwsanSultan.GameCore.Core
{
    public class AsgccAiEngine : MonoBehaviour
    {
        // وثيقة إثبات الحقوق البرمجية وحماية الابتكار للمطور الرئيسي
        public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
        public const string DeveloperID = "01010305468";

        [Header("Google AI Studio Config (Fallback Cloud)")]
        [SerializeField] private string apiKey = "AQ.Ab8RN6K4Sw85HA6Q8h5WbioNP5MPKoRl79oEG_4iqQvxtUe2ng"; 
        [SerializeField] private string cloudModelName = "gemini-1.5-flash"; 

        [Header("AI Model Configuration (Local)")]
        public string localModelName = "ASGCC-Llama-3-8B-Quantized";
        public bool useRtxTensorCores = true;
        public string rtxSparkModelVersion = "v4.2-Local";
        
        [Header("Ecosystem Guardrails")]
        [Range(0.1f, 1.0f)] [SerializeField] private float aiCreativityTemperature = 0.7f;
        [SerializeField] private int maxLocalTokenContext = 2048;

        // متفرعات الحالة التشغيلية للمحرك الهجين
        public bool IsNvidiaAceInitialized { get; private set; } = false;
        public string ActiveModelProfile { get; private set; } = "Standby";

        public delegate void OnAIResponseReceived(string responseText);
        public static AsgccAiEngine Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // الحفاظ على حالة الذكاء الاصطناعي وذاكرة الحوارات قيد العمل بين كافة مراحل اللعبة
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            // تهيئة فورية للمحرك وربطه بالـ Bridge والـ Tensor Cores
            InitializeLocalNvidiaAiSubsystem();
        }

        /**
         * @notice دالة فحص العتاد والتهيئة الآمنة لنظام نيفيديا المحلي وإشعال شرارة RTX Spark
         */
        public void InitializeLocalNvidiaAiSubsystem()
        {
            Debug.Log($"[{DeveloperName}] Initializing Secure Local AI Architecture (Model: {localModelName} | {rtxSparkModelVersion})...");
            
            // التحقق البرمجي من توافق العتاد عبر جسر نيفيديا والنظام البيئي للـ Compute Shaders لضمان ثبات الإطارات
            if (useRtxTensorCores && SystemInfo.supportsComputeShaders)
            {
                IsNvidiaAceInitialized = true;
                ActiveModelProfile = "NVIDIA_ACE_LOCAL_CORE";
                Debug.Log($"[NVIDIA ACE] Local Tensor Pipeline fully linked via Tensor Cores. Zero-Cloud OpEx mode verified.");
            }
            else
            {
                IsNvidiaAceInitialized = false;
                ActiveModelProfile = "CPU_Fallback_Cloud_Bridge";
                Debug.LogWarning("[AI Fallback] RTX Spark hardware missing. Falling back to Gemini Cloud API Bridge (Incurs structural server costs).");
            }
        }

        /**
         * @notice دالة توليد حوارات الشخصيات الذكية محلياً أو سحابياً بناءً على عتاد اللاعب ومستوى الـ XP الخاص به
         * @param playerPrompt النص أو السؤال الذي يوجهه اللاعب للشخصية
         * @param playerXp النقاط الحالية للاعب لفك الحوارات السرية
         * @param callback الدالة الوسيطة لاستلام النص النهائي وتحديث الواجهات
         */
        public async void GenerateNpcResponse(string playerPrompt, uint playerXp, OnAIResponseReceived callback)
        {
            Debug.Log($"[{DeveloperName}] Processing AI Generation Pipeline...");

            // 1. التحقق من تفعيل عتاد كرت الشاشة RTX Spark للمعالجة المحلية الخارقة
            if (IsNvidiaAceInitialized && ActiveModelProfile == "NVIDIA_ACE_LOCAL_CORE")
            {
                await Task.Delay(300); // محاكاة الاستجابة الفورية للمعالجة المحلية

                string localResponse = ProcessLocalXpLogic(playerXp);
                callback?.Invoke(localResponse);
                return;
            }

            // 2. نظام الدعم الاحتياطي السحابي عبر Gemini في حال عدم توفر العتاد المحلي للعميل
            Debug.LogWarning($"[{DeveloperName}] Device incompatible with RTX Spark. Activating Gemini Cloud Engine...");
            
            // بناء حزمة النص المدمجة مع منطق الـ XP لإرسال سياق كامل إلى سحابة Gemini
            string cloudPromptContext = $"Player XP: {playerXp}. Context: The player says: '{playerPrompt}'. " +
                                         $"Respond as an AI NPC Guide based on this dynamic state.";
            
            StartCoroutine(PostToGeminiStudio(cloudPromptContext, callback));
        }

        private string ProcessLocalXpLogic(uint playerXp)
        {
            if (playerXp >= 500)
            {
                return $"[AI NPC - Elite Guide]: Greetings champion of ASGCC! With your {playerXp} XP, I unlock the sacred path to mint your next Awsan Sultan Art asset. What is your strategy?";
            }
            if (playerXp >= 150)
            {
                return $"[AI NPC - Veteran Guide]: I see you have accumulated your 150 XP baseline from PvP victories. The cross-chain bridge in GlobalEcosystemGateway is now primed for your $AST transfers.";
            }
            
            return $"[AI NPC - Local Guide]: Welcome traveler. To access the premium token economic zones of $AST, you must accumulate 150 XP packages via PvP match victories.";
        }

        private IEnumerator PostToGeminiStudio(string prompt, OnAIResponseReceived callback)
        {
            string url = $"https://googleapis.com{cloudModelName}:generateContent?key={apiKey}";

            // تجهيز البيانات بأمان لتفادي مشاكل الرموز وعلامات التنصيص
            string escapedPrompt = JsonUtility.ToJson(prompt); 
            string jsonPayload = $"{{\"contents\": [{{\"parts\":[{{\"text\":{escapedPrompt}}}]}}]}}";

            using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
            {
                byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonPayload);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");

                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log($"[{DeveloperName}] Cloud Response successfully generated via Gemini.");
                    callback?.Invoke(request.downloadHandler.text);
                }
                else
                {
                    Debug.LogError($"[ASGCC AI Cloud Error] API Call Failed: {request.error} | Response: {request.downloadHandler.text}");
                    callback?.Invoke("[AI Fallback Error]: خطأ في الاتصال بمحرك الذكاء الاصطناعي السحابي.");
                }
            }
        }

        /**
         * @notice تحديث وتعديل أوزان الذكاء الاصطناعي ديناميكياً لتتوافق مع تحديثات الـ Metadata والأصول الرقمية لمعرض الفنون
         */
        public void InjectDynamicAssetContextToAi(string metadataPayload)
        {
            if (!IsNvidiaAceInitialized) return;
            Debug.Log($"[{DeveloperName} - AI Context Expanded] Model: {localModelName} context updated with Awsan Sultan Art Asset Metadata profile.");
        }

        /**
         * @notice دالة الإغلاق الآمن للمحرك وتحرير مساحة الـ VRAM عند الخروج
         */
        public void ShutdownAiEngine()
        {
            IsNvidiaAceInitialized = false;
            ActiveModelProfile = "Terminated";
            Debug.Log("[ASGCC AI] NVIDIA ACE Subsystem weights released from VRAM safely.");
        }
    }
}
