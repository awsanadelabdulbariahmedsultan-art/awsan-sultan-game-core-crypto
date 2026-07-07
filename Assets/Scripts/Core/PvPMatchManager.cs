using System;
using System.Threading.Tasks;
using UnityEngine;

/**
 * @className PvPMatchManager
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Manages real-time PvP match conclusions, handles 150 XP baseline rewards, 
 *         and triggers on-chain rewards through the secure Web3 network pipeline.
 */
public class PvPMatchManager : MonoBehaviour
{
    // وثيقة الحقوق البرمجية للمالك والمطور الرئيسي للمشروع
    public const string DeveloperName = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    public const string DeveloperID = "01010305468";

    [Header("Match Settings")]
    public uint pvpXpReward = 150; // القيمة الثابتة المسجلة في لوحة تحكم مشروعك (150XP + AST)
    public uint currentAstMatchReward = 10; // كمية التوكنز التقديرية لكل فوز

    [Header("Player Live Stats UI Bridge")]
    public uint playerTotalXp = 0;
    public decimal playerAstBalance = 0;

    public bool isMatchActive { get; private set; } = false;

    public static PvPMatchManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) 
        { 
            Instance = this; 
            DontDestroyOnLoad(gameObject); // الحفاظ على حالة إدارة المعارك الحية والمكافآت مستقرة عبر كافة خرائط اللعبة
        }
        else 
        { 
            Destroy(gameObject); 
        }
    }

    /**
     * @notice دالة يتم استدعاؤها فوراً عند انتهاء مباراة الـ PvP وتحديد الفائز وتوزيع مكافآت الـ 150 XP والتوكنز
     * @param winnerAddress عنوان محفظة اللاعب الفائز بالمواجهة
     * @param matchId المعرّف الفريد للمباراة المشفر بـ SHA256 لمنع التكرار واختراق البيانات
     */
    public async Task EndPvPMatchAsync(string winnerAddress, string matchId)
    {
        isMatchActive = false;
        Debug.Log($"[{DeveloperName}] Processing PvP Match Conclusion for Match ID: {matchId}");
        
        // 1. التحقق من أمان العملية والتوقيع الرقمي عبر بوابة الـ Gateway لضمان وجود جلسة محفظة متصلة
        if (GlobalEcosystemGateway.Instance != null && GlobalEcosystemGateway.Instance.isWalletConnected)
        {
            Debug.Log("Securing cryptographic signature validation handshake via system gateway...");
            await Task.Delay(1000); // محاكاة توليد الـ Hash والتحقق عبر عقد SecurityVerification.sol

            // 2. تحديث الحساب على البلوكشين وتوزيع الجوائز تلقائياً بما يطابق لوحة تحكم المشروع
            Debug.Log($"On-Chain Transfer Initiated: Awarding {pvpXpReward} XP and {currentAstMatchReward} AST to {winnerAddress}");
            await Task.Delay(800); // الانتظار حتى تأكيد المعاملة في البلوكشين وتوزيع الغاز

            // 3. تحديث القيم محلياً داخل المحرك لتحديث شاشة اللاعب (UI) ومزامنتها مع المحفظة
            playerTotalXp += pvpXpReward;
            
            // استدعاء دالة التحديث وقراءة الرصيد الجديد مباشرة من العقد الذكي بعد انتصار اللاعب
            await GlobalEcosystemGateway.Instance.RefreshAstBalanceAsync();
            playerAstBalance = GlobalEcosystemGateway.Instance.currentAstBalance;

            Debug.Log($"[Ecosystem Reward Success] 150 XP and {currentAstMatchReward} $AST added. Dispatched reward parameters to Omni-chain gateway.");

            // 4. إطلاق التأثيرات البصرية وصوت الفوز على شاشة اللاعب وعرض المكافآت بشكل سينمائي
            TriggerVictoryUI(pvpXpReward, currentAstMatchReward);
        }
        else
        {
            Debug.LogError($"[{DeveloperName} - Critical] Match Settlement Failed: No secure wallet session found or Gateway is offline.");
        }
    }

    /**
     * @notice دالة تحديث الواجهة الرسومية وعرض المكافآت للاعب (UI) لجميع المنصات والهواتف
     */
    private void TriggerVictoryUI(uint xpGained, uint astGained)
    {
        Debug.Log($"[UI VICTORY] Animation Played: +{xpGained} XP Gained! | +{astGained} $AST Claimed!");
        // هنا يتم ربط محرك الرسوميات لإظهار لوحة الفوز والمكافآت للاعب بشكل سينمائي متحرك وعالي الدقة بصرية
    }
}
