* Smart Contract criado no site `http://remix.ethereum.org/`

* Para trabalhar com smart contracts utlizando o .Net Core foram importados os seguintes pacotes:
	- Nethereum.Autogen.ContractApi
	- Nethereum.Web3

	Foi criado e compilado uma cópia do arquivo .sol do smart contract localmente e realizado a build no projeto .Net Core. Essa build faz com que o pacote `Nethereum.Autogen.ContractApi` reconheça o smart contract e crie automaticamente as API c# para interagir com o smart contract.

	Criei dentro do arquivo `Program.cs` uma conexão e deploy de um dado no smart contract sendo executado no `remix.ethereum.org` porém todas as chamadas retornavam `
403 Forbidden`
