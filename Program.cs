using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorderFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Onde estão os arquivos: ");
            string camimhoOrigem = Console.ReadLine();
            Console.WriteLine("Para onde vão os arquivos: ");
            string camimhoDestino = Console.ReadLine();
            //string camimhoOrigem = @"C:\Users\lbalestra\Desktop\Gravação";

            string[] arquivos = Directory.GetFiles(camimhoOrigem, "*.wav", SearchOption.AllDirectories);
            foreach (string arquivo in arquivos)
            {
                FileInfo infoArquivo = new FileInfo(arquivo);

                string nomeArq = infoArquivo.Name;
                int anoArq = infoArquivo.LastWriteTime.Year;
                int mesArq = infoArquivo.LastWriteTime.Month;
                int diaArq = infoArquivo.LastWriteTime.Day;
                string sourceFile;
                string destFile;

                string newFolder = camimhoDestino + "\\" + anoArq.ToString() + "\\" + mesArq.ToString() + "\\" + diaArq.ToString();

                if (!Directory.Exists(newFolder))
                {
                    Directory.CreateDirectory(newFolder);
                    Console.WriteLine("Pasta " + newFolder + " criada.");
                }

                sourceFile = System.IO.Path.Combine(camimhoOrigem, nomeArq);
                destFile = System.IO.Path.Combine(newFolder, nomeArq);

                if (File.Exists(destFile))
                    File.Delete(destFile);

                File.Copy(sourceFile, destFile);

                Console.WriteLine("Gravação: " + nomeArq + " copiada para " + destFile);
            }
            Console.WriteLine("FIM!");
            Console.ReadKey();
        }
    }
}
