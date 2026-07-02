// SPDX-License-Identifier: MIT
pragma solidity ^0.8.20;

/**
 * @title Security and Signature Verification Engine
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Validates cryptographic signatures to prevent match manipulation in PvP games.
 */
contract SecurityVerification {

    string public constant DEVELOPER = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    string public constant DEVELOPER_ID = "01010305468";

    address public owner;
    mapping(bytes32 => bool) public usedSignatures; // لمنع هجمات إعادة إرسال المعاملات (Replay Attacks)

    event SecurityAlert(string message, address indexed offender);

    modifier onlyOwner() {
        require(msg.sender == owner, "Unauthorized access");
        _;
    }

    constructor() {
        owner = msg.sender;
    }

    /**
     * @notice دالة للتحقق من أن التوقيع القادم من خادم اللعبة أو اللاعب سليم ولم يتم التلاعب به
     * @param _player عنوان محفظة اللاعب
     * @param _xpAmount كمية الـ XP المستحقة (مثال: 150)
     * @param _matchId معرف المباراة الفريد لمنع التكرار
     * @param _signature التوقيع المشفر المتولد من اللعبة
     */
    function verifyMatchResult(
        address _player,
        uint256 _xpAmount,
        bytes32 _matchId,
        bytes memory _signature
    ) external view returns (bool) {
        require(!usedSignatures[keccak256(abi.encodePacked(_signature))], "Signature already used!");

        // إعادة تكوين الهش المشفر للمباراة محلياً داخل العقد
        bytes32 messageHash = keccak256(abi.encodePacked(_player, _xpAmount, _matchId));
        bytes32 ethSignedMessageHash = keccak256(abi.encodePacked("\x19Ethereum Signed Message:\n32", messageHash));

        // استخراج عنوان المحفظة التي وقّعت هذا الأمر ومقارنتها بمالك اللعبة
        return recoverSigner(ethSignedMessageHash, _signature) == owner;
    }

    /**
     * @notice دالة داخلية تفك تشفير التوقيع لاستخراج المحفظة الموقّعة
     */
    function recoverSigner(bytes32 _ethSignedMessageHash, bytes memory _sig) internal pure returns (address) {
        (bytes32 r, bytes32 s, uint8 v) = splitSignature(_sig);
        return ecrecover(_ethSignedMessageHash, v, r, s);
    }

    /**
     * @notice تقطيع التوقيع إلى قيم R, S, V الرياضية المستخدمة في التشفير
     */
    function splitSignature(bytes memory sig) internal pure returns (bytes32 r, bytes32 s, uint8 v) {
        require(sig.length == 65, "Invalid signature length");

        assembly {
            r := mload(add(sig, 32))
            s := mload(add(sig, 64))
            v := byte(0, mload(add(sig, 96)))
        }
    }
}
