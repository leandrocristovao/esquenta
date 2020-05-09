﻿using Esquenta.Entities;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquenta.Forms
{
    class Utils
    {
        public static void Imprimir(Venda venda, string observacoes)
        {


            using (var printDocument = new PrintDocument())
            {
                printDocument.PrintPage += printDocument_PrintPage;
                printDocument.PrinterSettings.PrinterName = Properties.Settings.Default.Impressora;
                printDocument.Print();
            }

            void printDocument_PrintPage(object sender, PrintPageEventArgs e)
            {

                var printDocument = sender as PrintDocument;
                if (printDocument != null)
                {
                    //CABECALHO
                    //Image i = Image.FromFile(@"Resources/jpg.jpg");
                    //e.Graphics.DrawImage(i, e.PageBounds);

                    var font = new Font(FontFamily.GenericMonospace, 11);
                    var brush = new SolidBrush(Color.Black);
                    e.Graphics.DrawString(
                            "ESQUENTA BEBIDAS II\n\n",
                            font,
                            brush,
                            new RectangleF(0, 0, printDocument.DefaultPageSettings.PrintableArea.Width, printDocument.DefaultPageSettings.PrintableArea.Height));

                    //Cliente
                    String endereco = venda.Comanda.Endereco;
                    //verifico se a primeira linha comeca com o caracter #. Se sim, considero como endereco
                    observacoes = observacoes.Trim();
                    var linhas = observacoes.Split('\n');
                    if (linhas[0].Length > 0 && linhas[0][0] == '#')
                    {
                        endereco = linhas[0].Substring(1).Trim();
                        //Removo das observacoes a linha de endereco
                        observacoes = string.Join("\n", linhas.Skip(1));
                    }

                    var toPrint = $"CLIENTE: {venda.Comanda.Nome}\n" +
                        $"ENDEREÇO: {endereco}\n\n" +
                        "ITENS\n";

                    var quantidadeMaxima = venda.ItemVenda.Max(x => x.Quantidade).ToString().Length;
                    var valorMaximo = string.Format("{0:N}", venda.ItemVenda.Max(x => x.Valor)).Length;
                    var valorTotalMaximo = string.Format("{0:N}", venda.ItemVenda.Max(x => x.ValorTotal)).Length;

                    int count = 0;
                    venda.ItemVenda.ToList().ForEach(item =>
                    {
                        count++;

                        string valorFormatado = string.Format("{0:N}", item.Valor).PadLeft(valorMaximo, ' ');
                        string quantidadeFormatada = item.Quantidade.ToString().PadLeft(quantidadeMaxima, ' ');
                        string valorTotalFormatado = string.Format("{0:N}", item.ValorTotal).PadLeft(valorTotalMaximo, ' ');

                        string msg = $"{$"{count:D2}"} @ {valorFormatado} {quantidadeFormatada} {valorTotalFormatado}";
                        int size = 35 - msg.Length;

                        string produto = item.Produto.Nome.Substring(0, Math.Min(size, item.Produto.Nome.Length));
                        produto = produto.PadRight(size, ' ');
                        msg = $"{$"{count:D2}"} {produto} {valorFormatado} {quantidadeFormatada} {valorTotalFormatado}";
                        toPrint += $"{msg}\n";
                    });
                    toPrint += $"TOTAL: {string.Format("{0:N}", venda.ValorTotal)}\n";

                    if (!string.IsNullOrEmpty(observacoes))
                        toPrint += $"\nOBSERVACOES: {observacoes}";

                    toPrint += $"\n\n";
                    font = new Font(FontFamily.GenericMonospace, 6);
                    e.Graphics.DrawString(
                            toPrint,
                            font,
                            brush,
                            new RectangleF(0, 20, printDocument.DefaultPageSettings.PrintableArea.Width, printDocument.DefaultPageSettings.PrintableArea.Height));


                }

            }
        }
    }
}