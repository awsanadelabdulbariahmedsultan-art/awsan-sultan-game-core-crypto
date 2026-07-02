// SPDX-License-Identifier: MIT
pragma solidity ^0.8.20;

/**
 * @title AST Token - Core Gaming Currency
 * @dev Intellectual Property of ENG AWSAN ADEL ABDULBARI AHMED SULTAN
 * @notice Standard ERC-20 Token representing the utility currency $AST for the Game Engine.
 */
contract ASTToken {
    
    string public constant DEVELOPER = "ENG AWSAN ADEL ABDULBARI AHMED SULTAN";
    string public constant DEVELOPER_ID = "01010305468";

    string public name = "Awsan Sultan Token";
    string public symbol = "AST";
    uint8 public decimals = 18;
    uint256 public totalSupply;

    address public owner;

    mapping(address => uint256) public balanceOf;
    mapping(address => mapping(address => uint256)) public allowance;

    event Transfer(address indexed from, address indexed to, uint256 value);
    event Approval(address indexed owner, address indexed spender, uint256 value);
    event Mint(address indexed to, uint256 amount);
    event Burn(address indexed from, uint256 amount);

    modifier onlyOwner() {
        require(msg.sender == owner, "Error: Only ENG AWSAN SULTAN can trigger this function");
        _;
    }

    constructor(uint256 _initialSupply) {
        owner = msg.sender;
        // إنشاء الكمية الابتدائية وإرسالها لمحفظة المالك لادارة التوزيع والاستثمار
        _mint(msg.sender, _initialSupply * 10 ** uint256(decimals));
    }

    function transfer(address _to, uint256 _value) public returns (bool success) {
        require(_to != address(0), "Invalid address");
        require(balanceOf[msg.sender] >= _value, "Insufficient balance");
        
        balanceOf[msg.sender] -= _value;
        balanceOf[_to] += _value;
        emit Transfer(msg.sender, _to, _value);
        return true;
    }

    function approve(address _spender, uint256 _value) public returns (bool success) {
        require(_spender != address(0), "Invalid address");
        allowance[msg.sender][_spender] = _value;
        emit Approval(msg.sender, _spender, _value);
        return true;
    }

    function transferFrom(address _from, address _to, uint256 _value) public returns (bool success) {
        require(_to != address(0), "Invalid address");
        require(balanceOf[_from] >= _value, "Insufficient balance");
        require(allowance[_from][msg.sender] >= _value, "Insufficient allowance");

        balanceOf[_from] -= _value;
        balanceOf[_to] += _value;
        allowance[_from][msg.sender] -= _value;
        
        emit Transfer(_from, _to, _value);
        return true;
    }

    /**
     * @notice دالة لإنشاء توكنز جديدة عند الحاجة لضخ سيولة لبطولات أو مستثمرين جدد
     */
    function mint(address _to, uint256 _amount) external onlyOwner {
        _mint(_to, _amount);
    }

    /**
     * @notice دالة حرق العملات لتقليل المعروض ورفع القيمة الاقتصادية للتوكن (Deflationary Mechanism)
     */
    function burn(uint256 _amount) external {
        require(balanceOf[msg.sender] >= _amount, "Insufficient balance to burn");
        balanceOf[msg.sender] -= _amount;
        totalSupply -= _amount;
        emit Burn(msg.sender, _amount);
        emit Transfer(msg.sender, address(0), _amount);
    }

    function _mint(address _to, uint256 _amount) internal {
        totalSupply += _amount;
        balanceOf[_to] += _amount;
        emit Mint(_to, _amount);
        emit Transfer(address(0), _to, _amount);
    }
}
