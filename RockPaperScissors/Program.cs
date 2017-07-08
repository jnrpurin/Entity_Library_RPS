using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            rps_tournament_winer();
        }

        public static void rps_tournament_winer()
        {
            try
            {
                List<Jogada_Jogador> listaCampeonato = new List<Jogada_Jogador>();
                string terminou = "", nome = "", jogada = "";
                int i = 0;

                Console.WriteLine("****Bem vindo ao algoritmo PEDRA - PAPEL - TESOURA****");
                Console.WriteLine("Informe a lista de jogadores e sua respectiva jogada. Sendo Pedra = 'R' Papel = 'P' e Tesoura = 'S'.");
                Console.WriteLine("");                

                while (terminou.ToUpper() != "X")
                {
                    i++;
                    Console.WriteLine(" Informe o " + i + "º jogador: ");
                    nome = Console.ReadLine();
                    Console.WriteLine(" Informe a jogada do(a) " + nome + ": ");
                    jogada = Console.ReadLine();
                    listaCampeonato.Add(new Jogada_Jogador() { NomeJogador = nome, Jogada = jogada });
                    Console.WriteLine("--> 'Enter' continua, 'X' finaliza inclusão de jogadores.");
                    terminou = Console.ReadLine();
                }

                int ultimo = listaCampeonato.Count();
                if (!(ultimo % 2 == 0))
                {
                    Erro.NoSuchStrategiError("Torneio só pode ser iniciado com formação de pares completa.");
                }

                List<Jogada_Jogador> listaGanhadores = new List<Jogada_Jogador>();
                Jogada_Jogador ganhador = null; ;
                
                for (int j = 0; j < ultimo; j = (j + 2))
                {
                    List<Jogada_Jogador> jogo_j = new List<Jogada_Jogador>();

                    if (j == (ultimo - 1))
                    {
                        jogo_j.Add(listaCampeonato[0]);
                        jogo_j.Add(listaCampeonato[1]);
                        ganhador = rps_game_winner(jogo_j);
                        jogo_j.Clear();
                        jogo_j.Add(listaCampeonato[2]);
                        jogo_j.Add(ganhador);

                        ganhador = rps_game_winner(jogo_j);
                        listaGanhadores.Clear();
                        listaGanhadores.Add(ganhador);
                    }
                    else
                    {
                        jogo_j.Add(listaCampeonato[j]);
                        jogo_j.Add(listaCampeonato[j + 1]);
                        ganhador = rps_game_winner(jogo_j);
                        listaGanhadores.Add(ganhador);
                    }

                    if ((j == (ultimo - 2)) & (listaGanhadores.Count > 1))// testa se continua haverá mais jogos
                    {
                        ultimo = listaGanhadores.Count();
                        j = 0;

                        //Recria a lista somente com os ganhadores
                        listaCampeonato.Clear();
                        listaCampeonato.AddRange(listaGanhadores);
                    }
                }
                //Loop termina, listaGanhadores mantém somente com o campeão.
                Console.WriteLine("O grande campeão é: " + listaGanhadores[0].NomeJogador + ". Parabéns!!!");
                Console.ReadLine();
                Environment.Exit(0);
            }
            catch
            {
                Erro.NoSuchStrategiError();
            }
        }

        public static Jogada_Jogador rps_game_winner(List<Jogada_Jogador> jogadas_jogadores)
        {
            Jogada_Jogador vencedor;

            if (jogadas_jogadores.Count != 2)
                throw new Exception("Número de jogadores incorreto!");

            foreach (var item in jogadas_jogadores)
            {
                if (item.Jogada.ToUpper() != "P")
                    if (item.Jogada.ToUpper() != "R")
                        if (item.Jogada.ToUpper() != "S")
                            Erro.NoSuchStrategiError();                            
            }


            if (jogadas_jogadores[0].Jogada.ToUpper() == "P" && jogadas_jogadores[1].Jogada.ToUpper() == "R")
                vencedor = jogadas_jogadores[0];
            else if (jogadas_jogadores[0].Jogada.ToUpper() == "P" && jogadas_jogadores[1].Jogada.ToUpper() == "S")
                vencedor = jogadas_jogadores[1];
            else if (jogadas_jogadores[0].Jogada.ToUpper() == "R" && jogadas_jogadores[1].Jogada.ToUpper() == "P")
                vencedor = jogadas_jogadores[1];
            else if (jogadas_jogadores[0].Jogada.ToUpper() == "R" && jogadas_jogadores[1].Jogada.ToUpper() == "S")
                vencedor = jogadas_jogadores[0];
            else if (jogadas_jogadores[0].Jogada.ToUpper() == "S" && jogadas_jogadores[1].Jogada.ToUpper() == "P")
                vencedor = jogadas_jogadores[0];
            else if (jogadas_jogadores[0].Jogada.ToUpper() == "S" && jogadas_jogadores[1].Jogada.ToUpper() == "R")
                vencedor = jogadas_jogadores[1];
            else
                vencedor = jogadas_jogadores[0];

            return vencedor;
        }

        public class Jogada_Jogador
        {
            public int Id;
            public string NomeJogador;
            public string Jogada;

            public Jogada_Jogador(int id, string nomeJogador, string jogada)
            {
                Id = id;
                NomeJogador = nomeJogador;
                Jogada = jogada;
            }

            public Jogada_Jogador() { }
        }


        public class Erro
        {
            public static void NoSuchStrategiError()
            {                
                ExibirMensagem("Entrada de jogada incorreta! Reinicie os cadastros.");
            }

            public static void NoSuchStrategiError(string msg)
            {
                ExibirMensagem(msg);
            }

            private static void ExibirMensagem(string msg)
            {
                Console.Clear();
                Console.WriteLine(msg);
                Console.ReadLine();
                Console.Clear();
                rps_tournament_winer();
            }
        }
    }
}
