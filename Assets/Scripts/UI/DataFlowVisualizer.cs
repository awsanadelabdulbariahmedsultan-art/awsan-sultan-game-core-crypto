using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

namespace AwsanSultan.GameCore.UI
{
    public class DataFlowVisualizer : MonoBehaviour
    {
        [Header("Performance UI Elements")]
        [SerializeField] private TextMeshProUGUI activeNodesText;
        [SerializeField] private TextMeshProUGUI throughputText;
        [SerializeField] private TextMeshProUGUI latencyText;
        [SerializeField] private Image networkStatusIndicator;

        [Header("Visualization Settings")]
        [SerializeField] private Color stableColor = Color.green;
        [SerializeField] private Color stressColor = Color.orange;
        [SerializeField] private Color warningColor = Color.red;

        private int currentActiveNodes = 0;
        private float simulationSpeed = 1.0f;

        private void Start()
        {
            ResetVisualizer();
        }

        public void ResetVisualizer()
        {
            if (activeNodesText != null) activeNodesText.text = "Active Nodes: 0 / 5000";
            if (throughputText != null) throughputText.text = "Throughput: 0 tx/s";
            if (latencyText != null) latencyText.text = "Latency: 0 ms";
            if (networkStatusIndicator != null) networkStatusIndicator.color = stableColor;
        }

        // دالة يتم استدعاؤها من سكربت المحاكاة وفحص الضغط لتحديث الشاشة حياً
        public void UpdateMetrics(int activeNodes, float txRate, float latencyMs)
        {
            currentActiveNodes = activeNodes;

            if (activeNodesText != null) 
                activeNodesText.text = $"Active Nodes: {activeNodes} / 5000";
            
            if (throughputText != null) 
                throughputText.text = $"Throughput: {txRate:F1} tx/s";
            
            if (latencyText != null) 
                latencyText.text = $"Latency: {latencyMs:F0} ms";

            // تحديث مؤشر الحالة بناءً على معدل الضغط والاستجابة
            if (networkStatusIndicator != null)
            {
                if (latencyMs > 200f || activeNodes > 4000)
                    networkStatusIndicator.color = warningColor;
                else if (activeNodes > 2000)
                    networkStatusIndicator.color = stressColor;
                else
                    networkStatusIndicator.color = stableColor;
            }
        }
    }
}
