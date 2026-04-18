using System;
using System.IO;

namespace EditorDeTexto
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();

            Console.WriteLine("Seja bem-vindo ao Editor de Texto !!");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("O que você deseja fazer ?");
            Console.WriteLine("1 - Abrir arquivo de texto");
            Console.WriteLine("2 - Criar um novo arquivo");
            Console.WriteLine("3 - Apagar um arquivo");
            Console.WriteLine("0 - Sair");

            short opcao = short.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                case 3: Apagar(); break;
                default: Menu(); break;
            }

        }

        static void Abrir()
        {
            Console.Clear();

            Console.WriteLine("Qual é o caminho do arquivo ?");
            string caminho = Console.ReadLine();

            using (var arquivo = new StreamReader(caminho))
            {
                string texto = arquivo.ReadToEnd(); // Ler arquivo até o final.
                Console.WriteLine(texto);
            }
            Console.WriteLine("");

            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();

            Console.WriteLine("Digite seu texto abaixo...(ESC para sair)");
            Console.WriteLine("-------------------");
            string texto = "";
            do
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);// Se a tecla for diferente de ESC, continuar no laço.

            Salvar(texto);

            Menu();


        }

        static void Salvar(string texto)
        {
            Console.Clear();

            Console.WriteLine("QQual caminho para salvar o arquivo ? ");
            var caminho = Console.ReadLine();

            using (var arquivo = new StreamWriter(caminho))  // Abre ou cria um arquivo no caminho informado pelo usuário// O 'using' garante que o arquivo será fechado automaticamente
            {
                arquivo.Write(texto);
            }

            Console.WriteLine($"Arquivo {caminho} salvo com sucesso!!");
            Console.ReadLine();
            Menu();
        }

        static void Apagar()
        {
            Console.Clear();

            Console.WriteLine("Digite o caminho do arquivo que você deseja apagar !");
            var excluirArquivo = Console.ReadLine();

            if (File.Exists(excluirArquivo))
            {
                File.Delete(excluirArquivo);
                Console.WriteLine("Arquivo apagado com sucesso!");
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.");
            }

            Console.ReadLine();
            Menu();

        }

    }
}

