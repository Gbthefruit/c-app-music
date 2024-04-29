// Screen Sound

string mensagemBoasVindas = "Boas vindas ao Screen Sound\n";

Dictionary<string, List<int>> bandas = new Dictionary<string, List<int>>();
bandas.Add("Morada", new List<int> {3, 10, 6});
bandas.Add("Elevation Worship", new List<int>{1, 5, 9});

void ExibirLogo()
{
    Console.WriteLine(@"
    
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");
    Console.WriteLine(mensagemBoasVindas);
}


void SubTitulos(string titulo)
{
    int tamanhoTitulo = titulo.Length;
    string tracinho = string.Empty.PadLeft(tamanhoTitulo, '-');
    Console.WriteLine(tracinho);
    Console.WriteLine(titulo);
    Console.WriteLine(tracinho, '\n');
}

void ExibirOpcoesDoMenu()
    
{   
    ExibirLogo();
    Console.WriteLine("Digite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBandas();
            break;
        case 2: MostrarBandas();
            break;
        case 3: AvaliarBandas();
            break;
        case 4: ExibirMediaDaBanda();
            break;
        case -1: Console.WriteLine("Sistema Finalizado.");
            break;
        default: Console.WriteLine("Opção invalida");
            break;
    }      
}

void RegistrarBandas()
{
    Console.Clear();
    SubTitulos("Registro de Bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"\nA banda {nomeDaBanda} foi Registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarBandas()
{
    Console.Clear();
    SubTitulos("Lista de Bandas");
    foreach (string banda in bandas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.Write("\nDigite uma tecla para voltar ao menu principal: ");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void AvaliarBandas()
{
    // digite qual banda deseja avaliar
    // verificar se a banda existe no dicionario
    // se não existir, retorna ao menu principal
    Console.Clear();
    SubTitulos("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine();
    if (bandas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Digite a nota você deseja dar para {nomeDaBanda}: ");
        int nota = int.Parse(Console.ReadLine());
        bandas[nomeDaBanda].Add(nota);
        Console.WriteLine("\nA sua avaliação foi registrada com sucesso!");
        Thread.Sleep(3000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }  
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
        Console.Write("\nDigite uma tecla para voltar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}


void ExibirMediaDaBanda()
{
    Console.Clear();
    SubTitulos("Avaliação Média das Bandas");
    Console.Write("\nQual Banda você deseja ver a média?: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandas.ContainsKey(nomeDaBanda))
    {
        double nota = 0;
        foreach (int valor in bandas[nomeDaBanda])
        {
            nota += valor;
        }
        var media = nota / bandas[nomeDaBanda].Count;
        Console.WriteLine($"A Banda {nomeDaBanda} contém uma média {media:f1} de notas.");
        Thread.Sleep(2000);
        Console.Write("\nDigite uma tecla para voltar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    } else
    {
        Console.WriteLine($"\nA Banda {nomeDaBanda} não foi encontrada no Sistema.");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

ExibirOpcoesDoMenu();
