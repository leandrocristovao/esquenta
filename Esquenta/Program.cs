using System;
using System.Windows.Forms;

namespace Esquenta
{
    internal static class Program
    {
        public static bool isAdmin = false;
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length > 0 && args[0].Equals("reset"))
            {
                SavePassword("esquenta");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Main());
        }
        public static void SaveImpressora(string impressora, string rodape, int tamanho)
        {
            Properties.Settings.Default.Impressora = impressora;
            Properties.Settings.Default.ImpressoraMensagem = rodape;
            Properties.Settings.Default.ImpressoraLinha = tamanho;
            Properties.Settings.Default.Save();
        }
        public static void SavePassword(string newPWD)
        {
            Properties.Settings.Default.PWD = Base64Encode(newPWD);
            Properties.Settings.Default.Save();
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static bool CheckPassword(string check)
        {
            check = Program.Base64Encode(check);
            var currentPWD = Properties.Settings.Default.PWD;
            if (check.Equals(currentPWD))
            {
                return true;
            }
            return false;
        }
    }
}