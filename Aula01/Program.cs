using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Aula01
{
    class Program
    {
        public static string projectRoot = "C:\\Projetos\\Pos\\Blockchain\\Aula01\\";
        static void Main(string[] args)
        {

            var pessoas = new string[] { "Chase", "Rennie", "Franklin", "Huynh", "England", "Lugo",
            "Rodrigues", "Betts", "Cummings", "Irwin", "Nixon", "Higgins", "Cook", "Ross", "Eaton", "Fountain"};
            var hashes = new string[pessoas.Length];

            for (var i = 0; i < pessoas.Length; i++)
            {
                string destinatario;
                if (i == pessoas.Length - 1)
                    destinatario = pessoas[0];
                else
                    destinatario = pessoas[i + 1];

                var mensagem = $"Origem: {pessoas[i]}\nDestino: {destinatario}\nMensagem: Ola {destinatario}. Meu nome é {pessoas[i]}.\n";

                var hash = sha256(mensagem);
                hashes[i] = hash;
                var hashAnterior = i == 0 ? "Vazio" : hashes[i - 1];

                var diretorioBlocos = $"{projectRoot}\\blocos";
                if (!Directory.Exists(diretorioBlocos))
                    Directory.CreateDirectory(diretorioBlocos);

                using (StreamWriter sw = new StreamWriter($"{diretorioBlocos}\\bloco_{i}.txt"))
                {
                    sw.WriteLine($"{mensagem}Hash: {hash}\nHash Anterior: {hashAnterior}");
                }
            }

            try
            {
                ValidarBlocos();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        private static void ValidarBlocos()
        {
            var blocos = Directory.GetFiles($"{projectRoot}blocos");
            foreach (var bloco in blocos)
            {
                var conteudoBloco = File.ReadAllText(bloco);
                var dados = conteudoBloco.Split("Hash:");
                var hashGeradaConteudoArquivo = sha256(dados[0]);
                var hashesSalvasArquivo = dados[1].Split("\n");
                if (!hashGeradaConteudoArquivo.Equals(hashesSalvasArquivo[0].Trim()))
                    throw new Exception($"A hash salva no arquivo é diferente da hash gerada a partir do seu conteudo. Arquivo: {bloco}");
            }
            Console.WriteLine("Os blocos são válidos");
        }
    }
}
