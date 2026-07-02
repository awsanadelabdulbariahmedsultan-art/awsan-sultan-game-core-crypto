// SPDX-License-Identifier: MIT
pragma solidity ^0.8.20;

/**
 * @title PvP Match Rewards Engine
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Manages 150 XP and AST Token distribution for Crypto-Game Engine PvP victories.
 */
contract PvPRewards {
    
    // بيانات المالك والمطور الرئيسي للمشروع لحفظ الحقوق برمجياً داخل البلوكشين
    string public constant DEVELOPER = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    string public constant DEVELOPER_ID = "01010305468";

    address public owner;
    
    // هيكل بيانات اللاعب للاحتفاظ بنقاط الـ XP ورصيد عملة AST
    struct PlayerProfile {
        uint256 totalXP;
        uint256 astBalance;
        uint256 matchesWon;
    }

    mapping(address => PlayerProfile) public players;
    
    // قيم المكافآت الثابتة بناءً على لوحة تحكم اللعبة الخاصة بك
    uint256 public constant PVP_XP_REWARD = 150;
    uint256 public astRewardAmount; // كمية عملة AST الممنوحة مع الـ XP

    // أحداث يتم إطلاقها لتسمعها اللعبة (في Unity/Unreal) فور فوز اللاعب
    event PvPMatchVictory(address indexed winner, uint256 xpGained, uint256 astGained, uint256 timestamp);
    event RewardDistributionUpdated(uint256 newAstReward);

    modifier onlyOwner() {
        require(msg.sender == owner, "Error: Only ENG AWSAN SULTAN can trigger this function");
        _;
    }

    constructor(uint256 _initialAstReward) {
        owner = msg.sender;
        astRewardAmount = _initialAstReward;
    }

    /**
     * @notice دالة تطلقها اللعبة عند انتهاء مباراة الـ PvP لتسجيل الفوز وتوزيع الجوائز
     * @param _winner عنوان محفظة اللاعب الفائز بالمباراة
     */
    function rewardPvPWinner(address _winner) external onlyOwner {
        require(_winner != address(0), "Invalid player address");

        // إضافة المكافآت لملف اللاعب البرمجي
        players[_winner].totalXP += PVP_XP_REWARD;
        players[_winner].astBalance += astRewardAmount;
        players[_winner].matchesWon += 1;

        // إطلاق الحدث لتحديث واجهة اللعبة تلقائياً (تحديث الـ UI للاعب)
        emit PvPMatchVictory(_winner, PVP_XP_REWARD, astRewardAmount, block.timestamp);
    }

    /**
     * @notice دالة لتعديل كمية مكافأة عملة AST عند الحاجة لموازنة اقتصاد اللعبة (Tokenomics)
     */
    function updateAstRewardAmount(uint256 _newAmount) external onlyOwner {
        astRewardAmount = _newAmount;
        emit RewardDistributionUpdated(_newAmount);
    }

    /**
     * @notice دالة لاستعراض بيانات رصيد اللاعب ونقاطه الحالية
     */
    function getPlayerStats(address _player) external view returns (uint256 xp, uint256 ast, uint256 wins) {
        PlayerProfile memory profile = players[_player];
        return (profile.totalXP, profile.astBalance, profile.matchesWon);
    }
}
