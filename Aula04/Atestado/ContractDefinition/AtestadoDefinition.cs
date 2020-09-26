using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Aula04.Atestado.ContractDefinition
{


    public partial class AtestadoDeployment : AtestadoDeploymentBase
    {
        public AtestadoDeployment() : base(BYTECODE) { }
        public AtestadoDeployment(string byteCode) : base(byteCode) { }
    }

    public class AtestadoDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b506040516106373803806106378339818101604052604081101561003357600080fd5b810190808051604051939291908464010000000082111561005357600080fd5b90830190602082018581111561006857600080fd5b825164010000000081118282018810171561008257600080fd5b82525081516020918201929091019080838360005b838110156100af578181015183820152602001610097565b50505050905090810190601f1680156100dc5780820380516001836020036101000a031916815260200191505b50604052602001805160405193929190846401000000008211156100ff57600080fd5b90830190602082018581111561011457600080fd5b825164010000000081118282018810171561012e57600080fd5b82525081516020918201929091019080838360005b8381101561015b578181015183820152602001610143565b50505050905090810190601f1680156101885780820380516001836020036101000a031916815260200191505b50604052505082516101a2915060009060208501906101be565b5080516101b69060019060208401906101be565b505050610251565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f106101ff57805160ff191683800117855561022c565b8280016001018555821561022c579182015b8281111561022c578251825591602001919060010190610211565b5061023892915061023c565b5090565b5b80821115610238576000815560010161023d565b6103d7806102606000396000f3fe608060405234801561001057600080fd5b50600436106100415760003560e01c806373d4a13a14610046578063f1077be9146100c3578063f4c84d19146100cb575b600080fd5b61004e6101fa565b6040805160208082528351818301528351919283929083019185019080838360005b83811015610088578181015183820152602001610070565b50505050905090810190601f1680156100b55780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b61004e610287565b6101f8600480360360408110156100e157600080fd5b8101906020810181356401000000008111156100fc57600080fd5b82018360208201111561010e57600080fd5b8035906020019184600183028401116401000000008311171561013057600080fd5b91908080601f016020809104026020016040519081016040528093929190818152602001838380828437600092019190915250929594936020810193503591505064010000000081111561018357600080fd5b82018360208201111561019557600080fd5b803590602001918460018302840111640100000000831117156101b757600080fd5b91908080601f0160208091040260200160405190810160405280939291908181526020018383808284376000920191909152509295506102e2945050505050565b005b60018054604080516020600284861615610100026000190190941693909304601f8101849004840282018401909252818152929183018282801561027f5780601f106102545761010080835404028352916020019161027f565b820191906000526020600020905b81548152906001019060200180831161026257829003601f168201915b505050505081565b6000805460408051602060026001851615610100026000190190941693909304601f8101849004840282018401909252818152929183018282801561027f5780601f106102545761010080835404028352916020019161027f565b81516102f590600090602085019061030e565b50805161030990600190602084019061030e565b505050565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f1061034f57805160ff191683800117855561037c565b8280016001018555821561037c579182015b8281111561037c578251825591602001919060010190610361565b5061038892915061038c565b5090565b5b80821115610388576000815560010161038d56fea2646970667358221220087006938d16c26093fd2660a3c82ce7b0982e6d1213baeb11b004d791eb6e7664736f6c63430007000033";
        public AtestadoDeploymentBase() : base(BYTECODE) { }
        public AtestadoDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("string", "pacienteItem", 1)]
        public virtual string PacienteItem { get; set; }
        [Parameter("string", "dataItem", 2)]
        public virtual string DataItem { get; set; }
    }

    public partial class DataFunction : DataFunctionBase { }

    [Function("data", "string")]
    public class DataFunctionBase : FunctionMessage
    {

    }

    public partial class PacienteFunction : PacienteFunctionBase { }

    [Function("paciente", "string")]
    public class PacienteFunctionBase : FunctionMessage
    {

    }

    public partial class UpdateFunction : UpdateFunctionBase { }

    [Function("update")]
    public class UpdateFunctionBase : FunctionMessage
    {
        [Parameter("string", "newPaciente", 1)]
        public virtual string NewPaciente { get; set; }
        [Parameter("string", "newData", 2)]
        public virtual string NewData { get; set; }
    }

    public partial class DataOutputDTO : DataOutputDTOBase { }

    [FunctionOutput]
    public class DataOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class PacienteOutputDTO : PacienteOutputDTOBase { }

    [FunctionOutput]
    public class PacienteOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }


}