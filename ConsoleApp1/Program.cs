// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

Empresa empresa = new Empresa("999999999", "TRANSPORTES");

empresa.Garagems.Add(new Garagem(1,"Congonhas",new Stack<Veiculo>(),new List<Viagem>()));
empresa.Garagems.Add(new Garagem(2,"Guarulhos",new Stack<Veiculo>(),new List<Viagem>()));

empresa.adicionarVeiculo(new Veiculo("00000001", 1));
empresa.adicionarVeiculo(new Veiculo("00000002", 2));
empresa.adicionarVeiculo(new Veiculo("00000003", 3));
empresa.adicionarVeiculo(new Veiculo("00000004", 4));
empresa.adicionarVeiculo(new Veiculo("00000005", 5));
empresa.adicionarVeiculo(new Veiculo("00000006", 6));
empresa.adicionarVeiculo(new Veiculo("00000007", 7));
empresa.adicionarVeiculo(new Veiculo("00000008", 8));

int num = 100;
while (num > 0)
{
    int codigo = 0;
    int tombo = 0;
    Console.WriteLine("-------------------------------------------------------------");
    Console.WriteLine("                 0 - Finalizar");
    Console.WriteLine("                 1 - Cadastrar veículo");
    Console.WriteLine("                 2 - Cadastrar garagem");
    Console.WriteLine("                 3 - Iniciar jornada");
    Console.WriteLine("                 4 - Encerrar jornada");
    Console.WriteLine("                 5 - Liberar viagem de uma determinada origem para um determinado destino");
    Console.WriteLine("                 6 - Listar veículos em determinada garagem");
    Console.WriteLine("                 7 - Informar quantidade de viagens efetuadas de uma determinada origem para um determinado destino");
    Console.WriteLine("                 8 - Listar viagens efetuadas de uma determinada origem para um determinado destino");
    Console.WriteLine("                 9 - Informar quantidade de passageiros transportados de uma determinada origem para um determinado destino");
    Console.WriteLine("-------------------------------------------------------------");
    Console.Write("Digite uma opção desejada: ");
    num = Int32.Parse(Console.ReadLine());
    switch (num)
    {
        case 0:
            Console.WriteLine("SAINDO...");
            break;
        case 1:
            Console.Clear();
            if (empresa.Jornada)
            {
                Console.WriteLine("UM VEICULO SO PODE SER CADASTRADO NO FINAL DA JORNADA DIARIA");
            }
            else
            {
                Console.WriteLine("CADASTRO DE VAN");
                Console.WriteLine("DIGITE A PLACA DO VAN:");
                string placa = Console.ReadLine();
                Console.WriteLine("DIGITE O NUMERO DA VAN:");
                int numero = Int32.Parse(Console.ReadLine());
                Veiculo v = new Veiculo(placa, numero);
                empresa.adicionarVeiculo(v);
            }
            break;
        case 2:
            Console.Clear();
            
            if (empresa.Jornada)
            {
                Console.WriteLine("UMA GARAGEM SO PODE SER CADASTRADO NO FINAL DA JORNADA DIARIA");
            }
            else
            {
                Console.WriteLine("CADASTRO DE GARAGEM");
                Console.WriteLine("DIGITE O CODIGO DA GARAGEM:");
                int code = Int32.Parse(Console.ReadLine());
                Console.WriteLine("DIGITE O NOME DA GARAGEM:");
                string nome = Console.ReadLine();
                Garagem g = new Garagem(code, nome, new Stack<Veiculo>(), new List<Viagem>());
                empresa.Garagems.Add(g);
            }
            
            
            break;
        case 3:
            if (empresa.Jornada)
            {
                Console.WriteLine("UMA JORNADA JÁ ESTA ACONTECENDO");
            }
            else
            {
                int count_veiculos = empresa.Veiculos.Count;
                List<Garagem> garagems = empresa.Garagems;
                for ( int ve = 1; ve <= count_veiculos;)
                {
                    foreach (var gar  in empresa.Garagems.Select((garagem, index) => (garagem, index)))
                    {
                        if(empresa.Veiculos.Count > 0)
                            empresa.Garagems[gar.index].adicionarVeiculo(empresa.retirarVeiculo());
                    
                    }
                    count_veiculos = empresa.Veiculos.Count;
                }
                empresa.Jornada = true;
            }
            break;
        case 4:
            if (empresa.Jornada)
            {
                foreach (var gar in empresa.Garagems)
                {
                    gar.Viagems.Clear();
                    int veiculoGara = gar.Veiculos.Count();
                    for (int i = 0; i < veiculoGara;)
                    {
                        empresa.adicionarVeiculo(gar.retirarVeiculo());
                        veiculoGara = gar.Veiculos.Count();
                    }
                }
                empresa.Jornada = false;
            }
            else
            {
                Console.WriteLine("NENHUMA JORNADA ESTA ACONTECENDO");

            }
			
            break;
        case 5:
            if (empresa.Jornada)
            {
                Garagem garagemOrigem = new Garagem();
                Garagem garagemDestino = new Garagem();
                for (int aa = 0; aa < 1;)
                {
                    Console.WriteLine("DIGITE O CODIGO DA GARAGEM DE ORIGEM:");
                    int codeOrigem = Int32.Parse(Console.ReadLine());
                    garagemOrigem = empresa.pesquisar(new Garagem(codeOrigem, "", new Stack<Veiculo>(),new List<Viagem>()));
                    if(!garagemOrigem.Equals(null))
                    {
                        Console.WriteLine(garagemOrigem.Nome);
                        aa = 1;
                    
                    }
                }
                for (int aa = 0; aa < 1;)
                {
                    Console.WriteLine("DIGITE O CODIGO DA GARAGEM DE DESTINO:");
                    int codeDestino = Int32.Parse(Console.ReadLine());
                    garagemDestino = empresa.pesquisar(new Garagem(codeDestino, "", new Stack<Veiculo>(),new List<Viagem>()));
                    if (!garagemDestino.Equals(null))
                    {
                        Console.WriteLine(garagemDestino.Nome);
                        aa = 1;

                    }
                }
                Console.WriteLine("DIGITE A QUANTIDADE DE PASSAGEIROS:");
                int quantidadePassageiros = Int32.Parse(Console.ReadLine());
                garagemOrigem.viagem(garagemDestino, quantidadePassageiros);
                Console.WriteLine(garagemOrigem.Viagems[0].NomeDestino);
            }
            else
            {
                Console.WriteLine("NENHUMA JORNADA ESTA ACONTECENDO");

            }
            


            break;
        case 6:
            if (empresa.Jornada)
            {
                Garagem garagem = new Garagem();
                for (int aa = 0; aa < 1;)
                {
                    Console.WriteLine("DIGITE O CODIGO DA GARAGEM:");
                    int codes = Int32.Parse(Console.ReadLine());
                    garagem = empresa.pesquisar(new Garagem(codes, "", new Stack<Veiculo>(),new List<Viagem>()));
                    if(!garagem.Equals(null))
                    {
                        Console.WriteLine("Veiculos na garagem");
                        foreach (var veiculo in garagem.Veiculos)
                        {
                            Console.WriteLine("Veiculo da placa: " + veiculo.Placa);
                        }

                        aa = 1;
                    }
                }
            }
            else
            {
                Console.WriteLine("NENHUMA JORNADA ESTA ACONTECENDO");

            }
            
            break;
        case 7:
            if (empresa.Jornada)
            {
                Garagem garagem1 = new Garagem();
                Garagem garagem2 = new Garagem();

                for (int aa = 0; aa < 1;)
                {
                    Console.WriteLine("DIGITE O CODIGO DA GARAGEM DE ORIGEM:");
                    int codeOrigem = Int32.Parse(Console.ReadLine());
                    garagem1 = empresa.pesquisar(new Garagem(codeOrigem, "", new Stack<Veiculo>(),new List<Viagem>()));
                    if(!garagem1.Equals(null))
                    {
                        Console.WriteLine(garagem1.Nome);
                        aa = 1;
                    
                    }
                }
                for (int aa = 0; aa < 1;)
                {
                    Console.WriteLine("DIGITE O CODIGO DA GARAGEM DE DESTINO:");
                    int codeDestino = Int32.Parse(Console.ReadLine());
                    garagem2 = empresa.pesquisar(new Garagem(codeDestino, "", new Stack<Veiculo>(),new List<Viagem>()));
                    if (!garagem2.Equals(null))
                    {
                        Console.WriteLine(garagem2.Nome);
                        aa = 1;

                    }
                }

                int viaCount = 0;
                foreach (var viagem in garagem1.Viagems)
                {
                    if (viagem.CodeDestino == garagem2.Codigo)
                        viaCount++;
                }
                Console.WriteLine("Quantidade de Viagens: " + viaCount);
            }
            else
            {
                Console.WriteLine("NENHUMA JORNADA ESTA ACONTECENDO");

            }
            
            break;
        case 8:
            if (empresa.Jornada)
            {
                Garagem garagem11 = new Garagem();
                Garagem garagem22 = new Garagem();

                for (int aa = 0; aa < 1;)
                {
                    Console.WriteLine("DIGITE O CODIGO DA GARAGEM DE ORIGEM:");
                    int codeOrigem = Int32.Parse(Console.ReadLine());
                    garagem11 = empresa.pesquisar(new Garagem(codeOrigem, "", new Stack<Veiculo>(),new List<Viagem>()));
                    if(!garagem11.Equals(null))
                    {
                        Console.WriteLine(garagem11.Nome);
                        aa = 1;
                    
                    }
                }
                for (int aa = 0; aa < 1;)
                {
                    Console.WriteLine("DIGITE O CODIGO DA GARAGEM DE DESTINO:");
                    int codeDestino = Int32.Parse(Console.ReadLine());
                    garagem22 = empresa.pesquisar(new Garagem(codeDestino, "", new Stack<Veiculo>(),new List<Viagem>()));
                    if (!garagem22.Equals(null))
                    {
                        Console.WriteLine(garagem22.Nome);
                        aa = 1;

                    }
                }
                foreach (var viagem in garagem11.Viagems)
                {
                    if (viagem.CodeDestino == garagem22.Codigo)
                        Console.WriteLine("Origem: " + garagem11.Nome + " Destino: " + viagem.NomeDestino + " Placa do veiculo: " + viagem.Veiculo.Placa);
                }
            }
            else
            {
                Console.WriteLine("NENHUMA JORNADA ESTA ACONTECENDO");

            }
            
            break;
        case 9:
            if (empresa.Jornada)
            {
                Garagem garagem12 = new Garagem();
                Garagem garagem21 = new Garagem();

                for (int aa = 0; aa < 1;)
                {
                    Console.WriteLine("DIGITE O CODIGO DA GARAGEM DE ORIGEM:");
                    int codeOrigem = Int32.Parse(Console.ReadLine());
                    garagem12 = empresa.pesquisar(new Garagem(codeOrigem, "", new Stack<Veiculo>(),new List<Viagem>()));
                    if(!garagem12.Equals(null))
                    {
                        Console.WriteLine(garagem12.Nome);
                        aa = 1;
                    
                    }
                }
                for (int aa = 0; aa < 1;)
                {
                    Console.WriteLine("DIGITE O CODIGO DA GARAGEM DE DESTINO:");
                    int codeDestino = Int32.Parse(Console.ReadLine());
                    garagem21 = empresa.pesquisar(new Garagem(codeDestino, "", new Stack<Veiculo>(),new List<Viagem>()));
                    if (!garagem21.Equals(null))
                    {
                        Console.WriteLine(garagem21.Nome);
                        aa = 1;

                    }
                }

                int viaPass = 0;
                foreach (var viagem in garagem12.Viagems)
                {
                    if (viagem.CodeDestino == garagem21.Codigo)
                        viaPass += viagem.Passageiros;
                }
                Console.WriteLine("Quantidade de Passageiros: " + viaPass);
            }
            else
            {
                Console.WriteLine("NENHUMA JORNADA ESTA ACONTECENDO");

            }
            break;
    }
}    