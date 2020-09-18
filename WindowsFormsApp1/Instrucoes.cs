using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computador
{
    class Instrucoes
    {
        public static int instrucoes(String codigo, ref int[] reg, ref int nInst, ref String infos, ref List<structJump> jump)
        {

            String[] instrucao = new string[255];
            String operacao = null;

            if (codigo.Split(' ').ToString() != null) //fazer outra classe para quando nao tiver operacao ex> test:
            {
                codigo = codigo.Replace("\n", "");
                instrucao[nInst] = codigo.Split(';')[nInst];
                if (instrucao[nInst].IndexOf(':') != -1)
                {
                    structJump novoJump;
                    novoJump.nome = instrucao[nInst].Split(':')[0];
                    novoJump.end = nInst;
                    jump.Add(novoJump);
                    instrucao[nInst] = instrucao[nInst].Split(':')[1];
                }
                operacao = instrucao[nInst].Split(' ')[0];

                try
                {
                    if (!operacao.Equals("svac", StringComparison.CurrentCultureIgnoreCase) && !operacao.Equals("not", StringComparison.CurrentCultureIgnoreCase) && !operacao.Equals("nop", StringComparison.CurrentCultureIgnoreCase))
                    {
                        infos = instrucao[nInst].Split(' ')[1].Replace(";", "");

                        if (!(operacao.Equals("nop", StringComparison.CurrentCultureIgnoreCase) || operacao.Equals("psi", StringComparison.CurrentCultureIgnoreCase) || operacao.Equals("!psi", StringComparison.CurrentCultureIgnoreCase) || operacao.Equals("psm+", StringComparison.CurrentCultureIgnoreCase) || operacao.Equals("psm-", StringComparison.CurrentCultureIgnoreCase) || operacao.Equals("pi", StringComparison.CurrentCultureIgnoreCase)))
                        {
                            if (Convert.ToInt32(infos) > 255) return -1;
                            reg[nInst] = Convert.ToInt32(infos);
                        }
                            
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Ocorreu um erro na inserção da instrução na memoria.");
                    return -1;
                }

                if (operacao.Equals("add", StringComparison.CurrentCultureIgnoreCase))
                    return 1;
                else if (operacao.Equals("sub", StringComparison.CurrentCultureIgnoreCase))
                    return 2;
                else if (operacao.Equals("mult", StringComparison.CurrentCultureIgnoreCase))
                    return 3;
                else if (operacao.Equals("div", StringComparison.CurrentCultureIgnoreCase))
                    return 4;
                else if (operacao.Equals("and", StringComparison.CurrentCultureIgnoreCase))
                    return 5;
                else if (operacao.Equals("or", StringComparison.CurrentCultureIgnoreCase))
                    return 6;
                else if (operacao.Equals("not", StringComparison.CurrentCultureIgnoreCase))
                    return 7;
                else if (operacao.Equals("psi", StringComparison.CurrentCultureIgnoreCase))
                    return 8;
                else if (operacao.Equals("!psi", StringComparison.CurrentCultureIgnoreCase))
                    return 9;
                else if (operacao.Equals("psm+", StringComparison.CurrentCultureIgnoreCase))
                    return 10;
                else if (operacao.Equals("psm-", StringComparison.CurrentCultureIgnoreCase))
                    return 11;
                else if (operacao.Equals("pi", StringComparison.CurrentCultureIgnoreCase))
                    return 12;
                else if (operacao.Equals("mr", StringComparison.CurrentCultureIgnoreCase))
                    return 13;
                else if (operacao.Equals("rm", StringComparison.CurrentCultureIgnoreCase))
                    return 14;
                else if (operacao.Equals("nop", StringComparison.CurrentCultureIgnoreCase))
                    return 15;
                else if (operacao.Equals("loadi", StringComparison.CurrentCultureIgnoreCase))
                    return 16;
                else if (operacao.Equals("svac", StringComparison.CurrentCultureIgnoreCase))
                    return 17;
            }
            return -1;
        }

        public static void salvarMem(ref String[] memoria, String textoMemoria)
        {
            try
            {
                for (int i = 0; i < memoria.Length; i++)
                    memoria[i] = textoMemoria.Split('-')[i] + "-";
            }
            catch(Exception)
            {
                Console.WriteLine("Ocorreu um erro no salvamento da memoria.");
            }
        }

        public static int pegarInst(ref int[] op, ref int[] reg, ref String[] memoria, String textoMemoria, int nInst)
        {

            for (int i = 0; i < memoria.Length; i++)
                memoria[i] = textoMemoria.Split('-')[i] + "-";
            if (memoria[0].Equals("00000000-"))
                return 0;

            String separar;
            separar = memoria[nInst].Split('-')[0];
            List<int> list = new List<int>();
            int posInicial = 0;

            list.Add(Convert.ToInt32( int.Parse(separar.Substring( posInicial, 2 ), System.Globalization.NumberStyles.HexNumber) ) );

            if (list[0] == 16)
            {
                posInicial += 4;
                list.Add(Convert.ToInt32(int.Parse(separar.Substring(posInicial, 4), System.Globalization.NumberStyles.HexNumber)));
            }
            else
            {
                posInicial += 2;
                list.Add(Convert.ToInt32(int.Parse(separar.Substring(posInicial, 2), System.Globalization.NumberStyles.HexNumber)));
            }

            op[nInst] = list[0];
            reg[nInst] = list[1];

            return 1;
        }

    }
}
