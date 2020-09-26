using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using Aula04.Atestado;
using Aula04.Atestado.ContractDefinition;

namespace Aula04
{
    public class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            try
            {
                var url = "http://remix.ethereum.org/#optimize=false&evmVersion=null&version=soljson-v0.6.12+commit.27d51765.js";
                var privateKey = "0x116abfc463299a1b7ff7504a9f6d6c8006f59508";
                var account = new Account(privateKey);
                var web3 = new Web3(account, url);

                Console.WriteLine("Deploying...");
                var deployment = new AtestadoDeployment();
                deployment.PacienteItem = "Guilherme";
                deployment.DataItem = DateTime.Now.ToString();

                var receipt = await AtestadoService.DeployContractAndWaitForReceiptAsync(web3, deployment);
                var service = new AtestadoService(web3, receipt.ContractAddress);
                Console.WriteLine($"Contract Deployment Tx Status: {receipt.Status.Value}");
                Console.WriteLine($"Contract Address: {service.ContractHandler.ContractAddress}");


            }
            catch (Exception e)
            {
                var a = e;
            }
        }
    }
}
