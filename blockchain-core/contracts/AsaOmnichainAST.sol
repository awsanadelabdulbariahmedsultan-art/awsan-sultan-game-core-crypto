// SPDX-License-Identifier: MIT
pragma solidity ^0.8.20;

/**
 * @title Asa Omnichain AST Token (OFT Standard)
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Allows $AST to exist globally across multiple networks (Polygon, Celo, BNB, ETH) using LayerZero endpoints.
 */
contract AsaOmnichainAST {
    
    string public constant DEVELOPER = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    string public constant DEVELOPER_ID = "01010305468";

    string public name = "Awsan Sultan Omnichain Token";
    string public symbol = "AST";
    uint8 public decimals = 18;
    uint256 public totalSupply;

    address public owner;
    address public layerZeroEndpoint; // عنوان نقطة عبور الشبكات لـ LayerZero

    mapping(address => uint256) public balanceOf;
    
    event CrossChainTransfer(uint16 indexed targetChainId, address indexed to, uint256 amount);
    event Transfer(address indexed from, address indexed to, uint256 value);

    constructor(address _lzEndpoint, uint256 _initialSupply) {
        owner = msg.sender;
        layerZeroEndpoint = _lzEndpoint;
        totalSupply = _initialSupply * 10 ** uint256(decimals);
        balanceOf[msg.sender] = totalSupply;
    }

    /**
     * @notice دالة جبارة لإرسال التوكن من شبكة لشبكة أخرى بأمر واحد ودفع الغاز من الشبكة الحالية فقط
     * @param _targetChainId معرف الشبكة المستهدفة (مثلاً Polygon = 109)
     * @param _to محفظة المستلم على الشبكة الأخرى
     * @param _amount كمية عملة AST المراد نقلها
     */
    function sendCrossChain(uint16 _targetChainId, address _to, uint256 _amount) external payable {
        require(balanceOf[msg.sender] >= _amount, "Insufficient balance");
        
        // حرق العملة محلياً في الشبكة الحالية
        balanceOf[msg.sender] -= _amount;
        totalSupply -= _amount;
        emit Transfer(msg.sender, address(0), _amount);

        // إرسال أمر برميجي مشفر عبر الجسر اللامركزي ليقوم بصك (Mint) نفس الكمية للاعب في الشبكة الأخرى فوراً
        // (Placeholder for LayerZero core messaging pipeline .send() invocation)
        
        emit CrossChainTransfer(_targetChainId, _to, _amount);
    }
}
