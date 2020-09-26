using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Aula04.Atestado.ContractDefinition;

namespace Aula04.Atestado
{
    public partial class AtestadoService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, AtestadoDeployment atestadoDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<AtestadoDeployment>().SendRequestAndWaitForReceiptAsync(atestadoDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, AtestadoDeployment atestadoDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<AtestadoDeployment>().SendRequestAsync(atestadoDeployment);
        }

        public static async Task<AtestadoService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, AtestadoDeployment atestadoDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, atestadoDeployment, cancellationTokenSource);
            return new AtestadoService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public AtestadoService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> DataQueryAsync(DataFunction dataFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DataFunction, string>(dataFunction, blockParameter);
        }

        
        public Task<string> DataQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DataFunction, string>(null, blockParameter);
        }

        public Task<string> PacienteQueryAsync(PacienteFunction pacienteFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PacienteFunction, string>(pacienteFunction, blockParameter);
        }

        
        public Task<string> PacienteQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PacienteFunction, string>(null, blockParameter);
        }

        public Task<string> UpdateRequestAsync(UpdateFunction updateFunction)
        {
             return ContractHandler.SendRequestAsync(updateFunction);
        }

        public Task<TransactionReceipt> UpdateRequestAndWaitForReceiptAsync(UpdateFunction updateFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateFunction, cancellationToken);
        }

        public Task<string> UpdateRequestAsync(string newPaciente, string newData)
        {
            var updateFunction = new UpdateFunction();
                updateFunction.NewPaciente = newPaciente;
                updateFunction.NewData = newData;
            
             return ContractHandler.SendRequestAsync(updateFunction);
        }

        public Task<TransactionReceipt> UpdateRequestAndWaitForReceiptAsync(string newPaciente, string newData, CancellationTokenSource cancellationToken = null)
        {
            var updateFunction = new UpdateFunction();
                updateFunction.NewPaciente = newPaciente;
                updateFunction.NewData = newData;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateFunction, cancellationToken);
        }
    }
}
