pragma solidity ^0.6.12;

contract Atestado {
    string private paciente;
    string private data;

    constructor(string memory pacienteItem, string memory dataItem) public {
        paciente = pacienteItem;
        data = dataItem;
    }

    function update(string memory newPaciente, string memory newData) public {
        paciente = newPaciente;
        data = newData;
    }
}