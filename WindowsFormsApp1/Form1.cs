using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

struct structJump
{
    public String nome;
    public int end;
}

namespace Computador
{
    public partial class Form1 : Form
    {

        ULA ula = new ULA();
        String[] mem = new String[255];
        String nomeJump = null;
        List<TextBox> listaReg = new List<TextBox>();
        List<structJump> listaJumps = new List<structJump>();
        List<Label> labelReg = new List<Label>();
        List<Label> listaFlags = new List<Label>();

        int[] infosInstrucao = new int[255];
        int[] op = new int[255];
        int enderecoAtual = 0;
        int enderecoAnterior = 0;
        int nInst = -1;      

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

           
            listaReg.Add(reg0);
            listaReg.Add(reg1);
            listaReg.Add(reg2);
            listaReg.Add(reg3);
            listaReg.Add(reg4);
            listaReg.Add(reg5);
            listaReg.Add(reg6);
            listaReg.Add(reg7);
            listaReg.Add(reg8);
            listaReg.Add(reg9);
            listaReg.Add(reg10);
            listaReg.Add(reg11);

            labelReg.Add(reg0Label);
            labelReg.Add(reg1Label);
            labelReg.Add(reg2Label);
            labelReg.Add(reg3Label);
            labelReg.Add(reg4Label);
            labelReg.Add(reg5Label);
            labelReg.Add(reg6Label);
            labelReg.Add(reg7Label);
            labelReg.Add(reg8Label);
            labelReg.Add(reg9Label);
            labelReg.Add(reg10Label);
            labelReg.Add(reg11Label);

            listaFlags.Add(flagZeroNum);
            listaFlags.Add(flagSignNum);
            listaFlags.Add(flagOverflowNum);
            listaFlags.Add(flagCarryNum);

            try
            {
                for (int i = 0; i < mem.Length; i++)
                {
                    mem[i] += "00000000-";
                    memoria.Text += mem[i];
                }
            }catch(Exception)
            {
                Console.WriteLine("erro");
            }
        }

        private void test_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void memoria_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void reg2_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void testando_Click(object sender, EventArgs e)
        {
            

        }

        private void montar_MouseEnter(object sender, EventArgs e)
        {
            montar.BackColor = Color.White;
        }

        private void montar_MouseLeave(object sender, EventArgs e)
        {
            montar.BackColor= Color.White;
        }

        private void montar_Click(object sender, EventArgs e)
        {
            nInst = -1;
            Instrucoes.salvarMem(ref mem, memoria.Text);
                do
                {
                    nInst++;

                    op[nInst] = Instrucoes.instrucoes(inst.Text, ref infosInstrucao, ref nInst, ref nomeJump, ref listaJumps);
                    if (op[nInst] != -1)
                    {
                        if (op[nInst] < 8 || op[nInst] > 12 && op[nInst] != 17)
                            if(op[nInst] == 16)
                                mem[nInst] = op[nInst].ToString("X2").PadRight(5, '0') + Convert.ToInt32(infosInstrucao[nInst]).ToString("X2").PadLeft(3, '0');
                            else
                                mem[nInst] = op[nInst].ToString("X2") + Convert.ToInt32(infosInstrucao[nInst]).ToString("X2");  
                        else
                            mem[nInst] = op[nInst].ToString("X2");
                        mem[nInst] = mem[nInst].PadRight(8, '0') + "-";
                    }
                } while (op[nInst] != -1);
      
            memoria.Text = "";
            for (int i = 0; i <= mem.Length - 1; i++)
                memoria.Text += mem[i];

        }

        private void proxinst_Click(object sender, EventArgs e)
        {
            String reg1 = null;
            try
            {
                //Flags
                if (memoria.Text.Split('-')[enderecoAtual].Substring(0, 2).Equals("00"))
                {
                    msgDebug.Text = "Não há instrução para ser executada.";
                    msgDebug.ForeColor = System.Drawing.Color.White;
                    return;
                }

                //Cor instrucao
                memoria.Select(enderecoAnterior * 9, 8);
                memoria.SelectionColor = System.Drawing.Color.Orange;
                memoria.Select(enderecoAtual * 9, 8);
                memoria.SelectionColor = Color.OrangeRed;


                Instrucoes.pegarInst(ref op, ref infosInstrucao, ref mem, memoria.Text, enderecoAtual);

                for (int i = 0; i < labelReg.Count; i++)
                {
                    if (i == infosInstrucao[enderecoAtual])
                        labelReg[i].ForeColor = System.Drawing.Color.Chartreuse;
                    else
                        labelReg[i].ForeColor = System.Drawing.Color.Cornsilk;
                }

                if (op[enderecoAtual] == 16)
                {
                    ULA.SalvarCarregarDados(op[enderecoAtual], ref infoRegImediato, infosInstrucao[enderecoAtual].ToString());
                    msgDebug.ForeColor = System.Drawing.Color.Chartreuse; // verde
                    msgDebug.Text = "Endereço atual: " + enderecoAtual.ToString() + ", Operação: " + op[enderecoAtual].ToString();
                    enderecoAnterior = enderecoAtual++;
                    infoRegInstrucoes.Text = enderecoAtual.ToString();
                    return;
                }

                reg1 = listaReg[infosInstrucao[enderecoAtual]].Text;
                if (op[enderecoAtual] == 13 || op[enderecoAtual] == 14 || op[enderecoAtual] == 17)
                {
                    while (progressBar1.Value < 100)
                    {
                        System.Threading.Thread.Sleep(350);
                        progressBar1.Value += 10;
                    }
                    
                    ULA.executarTransferencia(op[enderecoAtual], ref memoria, infosInstrucao[enderecoAtual], ref listaReg, ref infoRegImediato, infoRegACHex.Text);
                    enderecoAnterior = enderecoAtual++;
                    infoRegInstrucoes.Text = enderecoAtual.ToString();
                    if (op[enderecoAtual] == 13)
                        msgDebug.Text = "Dado inserido no registrador.";
                    else
                        msgDebug.Text = "Dado inserido na memoria.";
                    return;
                }

                
                if (op[enderecoAtual] == 15)
                {
                    enderecoAnterior = enderecoAtual++;
                    infoRegInstrucoes.Text = enderecoAtual.ToString();
                    return;
                }
                else if (op[enderecoAtual] > 7 && op[enderecoAtual] < 14)
                {
                    enderecoAnterior = enderecoAtual;
                    msgDebug.ForeColor = System.Drawing.Color.Chartreuse; // verde
                    msgDebug.Text = "Endereço atual: " + enderecoAtual.ToString() + ", Operação: " + op[enderecoAtual].ToString();
                    ULA.executarPulos(op[enderecoAtual].ToString("X"), Convert.ToInt32(reg1), Convert.ToInt32(infoRegACHex.Text, 16), ref enderecoAtual, ref listaJumps, ref nomeJump, listaFlags);
                    
                }
                else
                {
                    listaReg[infosInstrucao[enderecoAtual]].Text = listaReg[infosInstrucao[enderecoAtual]].Text.PadLeft(8, '0').ToUpper();
                    int resultado = Convert.ToInt32(ULA.executarOperacao(op[enderecoAtual].ToString("X"), reg1, Convert.ToInt32(infoRegACHex.Text, 16), listaFlags), 10);
                    infoRegACBin.Text = Convert.ToString(resultado, 2).PadLeft(8, '0');
                    infoRegACHex.Text = Convert.ToString(resultado, 16).ToUpper();
                    infoRegACDec.Text = resultado.ToString();
                    msgDebug.ForeColor = System.Drawing.Color.Chartreuse; // verde
                    msgDebug.Text = "Endereço atual: " + enderecoAtual.ToString() + ", Operação: " + op[enderecoAtual].ToString();
                    enderecoAnterior = enderecoAtual++;
                }
                infoRegInstrucoes.Text = enderecoAtual.ToString();
            }
            catch (Exception)
            {
                msgDebug.ForeColor = System.Drawing.Color.Red;
                msgDebug.Text = "[ERRO] Valores invalidos.";
            }
        }
       


        private void resetar_Click(object sender, EventArgs e)
        {
            infoRegACBin.Text = "00000000";
            infoRegACHex.Text = "0";
            infoRegACDec.Text = "0";
            infoRegInstrucoes.Text = "0";
            memoria.Text = "";
            infoRegImediato.Text = "0";


            for (int i = 0; i < mem.Length; i++)
            {
                mem[i] = "00000000-";
                memoria.Text += mem[i];
            }
            for (int i = 0;i < 12;i++)
                listaReg[i].Text = "00000000";
            enderecoAtual = 0;
            msgDebug.Text = "o computador foi resetado.";
            msgDebug.ForeColor = System.Drawing.Color.Chartreuse;
            for (int i = 0; i < labelReg.Count; i++)
                labelReg[i].ForeColor = System.Drawing.Color.Cornsilk;
            listaJumps.Clear();
        }

        private void limpaMemoria_Click(object sender, EventArgs e)
        {
            memoria.Text = "";
            for (int i = 0; i < mem.Length; i++)
            {
                mem[i] = "00000000-";
                memoria.Text += mem[i];
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void infoRegDec_Enter(object sender, EventArgs e)
        {

        }

        private void equipeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WindowsFormsApp1.FormEquipe novoEquipe = new WindowsFormsApp1.FormEquipe();
            novoEquipe.ShowDialog();
        }

        private void equipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsFormsApp1.sobre novoSobre = new WindowsFormsApp1.sobre();
            novoSobre.ShowDialog();
        }
    }

}
