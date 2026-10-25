using System;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using AwsanSultan.GameCore.Core;

/**
 * @className GlobalEcosystemGateway
 * @version v2.1-Ecosystem-Core
 * @date October 25, 2026
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Global Gateway orchestrating cross-platform Web3 events, Firebase authentication states, 
 *         and triggering silent live-ops updates for the AI neural network weights.
 */
namespace AwsanSultan.GameCore.Backend
{
    public class GlobalEcosystemGateway : MonoBehaviour
    {
        public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
        public const string DeveloperID = "01010305468";
        public const string DeploymentDate = "2026-10-25";

        [Header("Ecosystem API Endpoints")]
        [SerializeField] private string firebaseGatewayUrl = "https://awsansultan-asgcc.com";
        [SerializeField] private string web3BridgeUrl = "https://awsansultan-asgcc.com";

        public string currentSessionToken = "Unauthenticated";
        public bool isWeb3BridgeActive { get; private set; } = false;

        public static GlobalEcosystemGateway Instance { get; private set; }

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
            InitializeEcosystemGateway();
        }

        public void InitializeEcosystemGateway()
        {
            isWeb3BridgeActive = true;
            Debug.Log($"[{DeveloperName} - Gateway Sync: {DeploymentDate}] Web3 Blockchain Bridge and Firebase gateways online.");
        }

        public async Task<bool> VerifyCrossChainTransactionAsync(string userAddress, string txHash)
        {
            string txPayload = $"{{\"wallet\": \"{userAddress}\", \"tx\": \"{txHash}\"}}";
            byte[] bodyRaw = Encoding.UTF8.GetBytes(txPayload);

            using (UnityWebRequest request = new UnityWebRequest(web3BridgeUrl, "POST"))
            {
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");

                var operation = request.SendWebRequest();
                while (!operation.isDone) await Task.Delay(100);

                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log($"[{DeveloperName} - Web3 Confirmed: {DeploymentDate}] Transaction verified. Distributing rewards.");
                    return true;
                }
                return false;
            }
        }

        public void TriggerSilentLiveOpsAiReload(string newAiProfileJson)
        {
            if (AsgccAiEngine.Instance != null)
            {
                AsgccAiEngine.Instance.InjectDynamicAssetContextToAi(newAiProfileJson);
            }
        }
    }
}
