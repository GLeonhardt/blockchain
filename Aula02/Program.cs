using System;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace Aula02
{
    class Program
    {
        public static string projectRoot = "C:\\Projetos\\Pos\\Blockchain\\Aula02\\";
        static void Main(string[] args)
        {
            var nomeChaves = new List<string>() {
                "Betts", "Chase", "Cook", "Cummings", "Eaton", "England", "Fountain", "Franklin",
                "Higgins", "Huynh", "Irwin", "Lugo", "Nixon", "Rennie", "Rodrigues", "Ross"
            };

            foreach (var nomeChave in nomeChaves)
            {
                var chave = System.IO.File.ReadAllText($"{projectRoot}Chaves\\{nomeChave}_private_key.pem");
                Console.WriteLine(chave);
                RSACryptoServiceProvider csp = new RSACryptoServiceProvider();

                using (TextReader privateKeyTextReader = new StringReader(chave))
                {
                    AsymmetricCipherKeyPair readKeyPair = (AsymmetricCipherKeyPair)new PemReader(privateKeyTextReader).ReadObject();

                    RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)readKeyPair.Private);
                    csp.ImportParameters(rsaParams);
                }
                
                var mensagens = Directory.GetFiles($"{projectRoot}Mensagens");
                foreach (var mensagem in mensagens)
                {
                    try
                    {
                        var result = csp.Decrypt(Convert.FromBase64String(File.ReadAllText(mensagem)), false);

                        var diretorioDescriptografadas = $"{projectRoot}\\Descriptografada";
                        if (!Directory.Exists(diretorioDescriptografadas))
                            Directory.CreateDirectory(diretorioDescriptografadas);

                        var mensagemDescriptografada = Encoding.UTF8.GetString(result, 0, result.Length);
                        Console.WriteLine(mensagemDescriptografada);

                        var projectTree = mensagem.Split("\\");
                        using (StreamWriter sw = new StreamWriter($"{diretorioDescriptografadas}\\{projectTree[projectTree.Length - 1]}"))
                        {
                            sw.WriteLine(mensagemDescriptografada);
                        }

                    }
                    catch (Exception)
                    {}
                }
            }
        }
    }
}
