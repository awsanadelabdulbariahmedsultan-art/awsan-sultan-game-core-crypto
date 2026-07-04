// SPDX-License-Identifier: MIT
pragma solidity ^0.8.20;

/**
 * @dev Interface for interacting with the native $AST Token contract.
 */
interface IASTToken {
    function transfer(address recipient, uint256 amount) external returns (bool);
}

/**
 * @title PvP Match Rewards Engine
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Manages 150 XP and AST Token distribution for verified Crypto-Game Engine PvP victories.
 *         Completely integrated with the SecurityVerification.sol validation sub-nodes.
 */
contract PvPRewards {
    
    // بيانات المالك والمطور الرئيسي للمشروع لحفظ الحقوق برمجياً داخل البلوكشين
    string public constant DEVELOPER = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    string public constant DEVELOPER_ID = "01010305468";

    address public owner;
    address public astTokenAddress;
    address public securityVerifier; // عنوان عقد التدقيق الأمني التشفيري لصد الاختراقات

    // هيكل بيانات اللاعب للاحتفاظ بنقاط الـ XP ورصيد عملة AST من كودك السابق
    struct PlayerProfile {
        uint256 totalXP;
        uint256 astBalance;
        uint256 matchesWon;
    }

    // قيم المكافآت الثابتة بناءً على لوحة تحكم اللعبة الخاصة بك (150 XP و 10 توكنز)
    uint256 public constant PVP_XP_REWARD = 150;
    uint256 public astRewardAmount = 10 * 10**18; // 10 AST Tokens base reward mapping

    mapping(address => PlayerProfile) public players;
    
    // أحداث يتم إطلاقها لتسمعها اللعبة (في Unity/Unreal) فور فوز اللاعب
    event PvPMatchVictory(address indexed winner, uint256 xpGained, uint256 astGained, string matchId, uint256 timestamp);
    event RewardDistributionUpdated(uint256 newAstReward);
    event SecurityVerifierBound(address indexed verifier);

    modifier onlyOwner() {
        require(msg.sender == owner, "Error: Only ENG AWSAN SULTAN can trigger this function");
        _;
    }

    modifier onlyVerifiedNodes() {
        require(msg.sender == securityVerifier || msg.sender == owner, "ASGCC Security: Caller is not the verified security node");
        _;
    }

    constructor(address _astToken, address _verifier) {
        owner = msg.sender;
        astTokenAddress = _astToken;
        securityVerifier = _verifier;
    }

    /**
     * @notice دالة تطلقها اللعبة عبر عقد الحارس الأمني عند انتهاء مباراة الـ PvP لتسجيل الفوز وتوزيع الجوائز
     * @param _winner عنوان محفظة اللاعب الفائز بالمباراة
     * @param _matchId المعرف الفريد للمباراة الممرر من PvPMatchManager.cs
     */
    function rewardPvPWinner(address _winner, string calldata _matchId) external onlyVerifiedNodes returns (bool) {
        require(_winner != address(0), "Invalid player address");

        // 1. إضافة المكافآت لملف اللاعب البرمجي على السلسلة من منطقك السابق
        players[_winner].totalXP += PVP_XP_REWARD;
        players[_winner].astBalance += astRewardAmount;
        players[_winner].matchesWon += 1;

        // 2. التنفيذ المادي الفعلي لتحويل عملات الـ AST من احتياطي العقد إلى محفظة اللاعب الفائز
        IASTToken astToken = IASTToken(astTokenAddress);
        require(astToken.transfer(_winner, astRewardAmount), "ASGCC Rewards: AST distribution failed");

        // 3. إطلاق الحدث لتحديث واجهة اللعبة تلقائياً (تحديث الـ UI للاعب في كود السي شارب)
        emit PvPMatchVictory(_winner, PVP_XP_REWARD, astRewardAmount, _matchId, block.timestamp);
        return true;
    }

    /**
     * @notice دالة لتحديث عقد الحارس الأمني الوسيط في حال حدوث ترقية لشبكة الاتصالات
     */
    public void updateSecurityVerifier(address _newVerifier) external onlyOwner {
        require(_newVerifier != address(0), "Invalid verifier address");
        securityVerifier = _newVerifier;
        emit SecurityVerifierBound(_newVerifier);
    }

    /**
     * @notice دالة لتعديل كمية مكافأة عملة AST عند الحاجة لموازنة اقتصاد اللعبة (Tokenomics)
     */
    function updateAstRewardAmount(uint256 _newAmount) external onlyOwner {
        astRewardAmount = _newAmount;
        emit RewardDistributionUpdated(_newAmount);
    }

    /**
     * @notice دالة لاستعراض بيانات رصيد اللاعب ونقاطه الحالية من واجهة اللعبة أو المستكشف
     */
    function getPlayerStats(address _player) external view returns (uint256 xp, uint256 ast, uint256 wins) {
        PlayerProfile memory profile = players[_player];
        return (profile.totalXP, profile.astBalance, profile.matchesWon);
    }
}
