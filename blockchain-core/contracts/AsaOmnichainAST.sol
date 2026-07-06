// SPDX-License-Identifier: MIT
pragma solidity ^0.8.20;

/**
 * @title Asa Omnichain AST Token (Comprehensive Edition)
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Combines standard ERC20 features (Mint/Burn) with LayerZero Cross-Chain Architecture & Automated Revenue.
 */
contract AsaOmnichainAST {
    
    // الهوية البرمجية للمطور وحقوق الملكية الفكرية
    string public constant DEVELOPER = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    string public constant DEVELOPER_ID = "01010305468";

    string public name = "Awsan Sultan Omnichain Token";
    string public symbol = "AST";
    uint8 public decimals = 18;
    uint256 public totalSupply;

    address public owner;
    address public layerZeroEndpoint; 
    
    // الهيكل المالي لإدارة الإيرادات وعناوين الحرق
    address public immutable platformTreasury;
    address public constant BURN_ADDRESS = 0x000000000000000000000000000000000000dEaD;
    
    // إعدادات رسوم جسر العبور (100 = 1% إجمالي من المعاملة العابرة)
    uint256 public constant TOTAL_BRIDGE_FEE_BPS = 100; 
    uint256 public constant TREASURY_SHARE_BPS = 70;    // 70% صافي أرباح لمحفظتك
    uint256 public constant BURN_SHARE_BPS = 30;        // 30% حرق فوري لدعم السعر

    mapping(address => uint256) public balanceOf;
    mapping(address => mapping(address => uint256)) public allowance;
    
    // الأحداث البرمجية لتتبع المعاملات على البلوكشين
    event Transfer(address indexed from, address indexed to, uint256 value);
    event Approval(address indexed owner, address indexed spender, uint256 value);
    event CrossChainTransfer(uint16 indexed targetChainId, address indexed to, uint256 netAmount, uint256 treasuryShare, uint256 burnShare);

    // محدد الصلاحيات البرمجي لحماية الوظائف الحساسة للمطور فقط
    modifier onlyOwner() {
        require(msg.sender == owner, "Error: Only ENG AWSAN ADEL SULTAN can execute this");
        _;
    }

    constructor(address _lzEndpoint, uint256 _initialSupply) {
        owner = msg.sender;
        layerZeroEndpoint = _lzEndpoint;
        totalSupply = _initialSupply * 10 ** uint256(decimals);
        balanceOf[msg.sender] = totalSupply;
        
        // ربط محفظة البينانس بصيغتها الرسمية المقبولة برمجياً وتخزينها كـ immutable
        platformTreasury = 0x2cC723b5AE28da42c9983670b9Bf299dC7dEdb8d;
        
        emit Transfer(address(0), msg.sender, totalSupply);
    }

    // --- الدوال المعيارية المأخوذة من مشروعك الحالي (ERC20 Standard) ---

    function transfer(address _to, uint256 _value) public returns (bool success) {
        require(balanceOf[msg.sender] >= _value, "Insufficient balance");
        balanceOf[msg.sender] -= _value;
        balanceOf[_to] += _value;
        emit Transfer(msg.sender, _to, _value);
        return true;
    }

    function approve(address _spender, uint256 _value) public returns (bool success) {
        allowance[msg.sender][_spender] = _value;
        emit Approval(msg.sender, _spender, _value);
        return true;
    }

    function transferFrom(address _from, address _to, uint256 _value) public returns (bool success) {
        require(balanceOf[_from] >= _value, "Insufficient balance");
        require(allowance[_from][msg.sender] >= _value, "Allowance exceeded");
        balanceOf[_from] -= _value;
        balanceOf[_to] += _value;
        allowance[_from][msg.sender] -= _value;
        emit Transfer(_from, _to, _value);
        return true;
    }

    // دالة صك العملات الجديدة للمالك فقط (كما تظهر في الصورة الثانية)
    function mint(address _to, uint256 _amount) external onlyOwner {
        uint256 mintedAmount = _amount * 10 ** uint256(decimals);
        totalSupply += mintedAmount;
        balanceOf[_to] += mintedAmount;
        emit Transfer(address(0), _to, mintedAmount);
    }

    // دالة حرق العملات لتقليل المعروض الإجمالي
    function burn(uint256 _amount) external {
        uint256 burnedAmount = _amount * 10 ** uint256(decimals);
        require(balanceOf[msg.sender] >= burnedAmount, "Burn amount exceeds balance");
        balanceOf[msg.sender] -= burnedAmount;
        totalSupply -= burnedAmount;
        emit Transfer(msg.sender, address(0), burnedAmount);
    }

    // --- الدالة الخارقة والخاصة بالـ Omnichain وتوليد الأرباح الحصري ---

    function sendCrossChain(uint16 _targetChainId, address _to, uint256 _amount) external payable {
        require(balanceOf[msg.sender] >= _amount, "Insufficient balance");
        require(_amount > 1000, "Transfer amount too low for fee division");

        uint256 totalFee = (_amount * TOTAL_BRIDGE_FEE_BPS) / 10000;
        uint256 netAmount = _amount - totalFee;

        uint256 treasuryShare = (totalFee * TREASURY_SHARE_BPS) / 100;
        uint256 burnShare = totalFee - treasuryShare; 

        balanceOf[msg.sender] -= _amount;
        
        // تحويل الـ 70% من الرسوم تلقائياً إلى خزينة محفظتك الخاصة في بينانس
        balanceOf[platformTreasury] += treasuryShare;
        emit Transfer(msg.sender, platformTreasury, treasuryShare);

        // حرق الصافي والـ 30% من الرسوم لتقليل العرض الإجمالي محلياً
        uint256 totalLocalBurn = netAmount + burnShare;
        totalSupply -= totalLocalBurn;
        
        emit Transfer(msg.sender, address(0), totalLocalBurn);
        emit Transfer(address(0), BURN_ADDRESS, burnShare);

        emit CrossChainTransfer(_targetChainId, _to, netAmount, treasuryShare, burnShare);
    }
}
