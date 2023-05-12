/*
 * Created by SharpDevelop.
 * User: amonv
 * Date: 08.02.2022
 * Time: 22:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Text;

namespace SouboryTXT
{
	class Program
	{
		public static string[] morseovka = {
			".-","-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---" , "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--","-..-","-.--","--.."
		};
		public static string abeceda = "abcdefghijklmnopqrstuvwxyz";
		public static string fileText = "zprava.txt";
		public static string fileMorse = "sifra.txt";
		
		public static void Main(string[] args)
		{
	
			Start();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		public static void Start() {
			
			do {
				Console.Clear();
				Console.WriteLine("MORSEOVKA\n");
				Console.WriteLine("Konzolový mód - 1");
				Console.WriteLine("Souborový mód - 2");
				Console.WriteLine("Exit - 3");
				Console.Write("\nVyberte akci (1/2/3): ");
				switch(Console.ReadLine()) {
					case "1":
						KonzolovyMod();
						break;
					case "2":
						SouborovyMod();
						break;
					case "3":
						return;
				}
			} while(true);
		}
		
		public static void KonzolovyMod() {
			do {
				Console.Clear();
				Console.WriteLine("MORSEOVKA");
				Console.WriteLine(" Konzolový mód\n");
				Console.WriteLine(" Text na morseovku - 1");
				Console.WriteLine(" Morseovka na text - 2");
				Console.WriteLine(" Zpět - 3");
				Console.Write("\nVyberte akci (1/2/3): ");
				switch(Console.ReadLine()) {
					case "1":
						do {
							Console.Clear();
							Console.WriteLine("MORSEOVKA");
							Console.WriteLine(" Konzolový mód");
							Console.WriteLine("  Text -> Morse\n");
							Console.Write("  Zadejte text: ");
							string output = TextToMorse(Console.ReadLine());
							Console.WriteLine("  Output: " + output);
							Console.Write("\n  Znovu? ('y' pro opětovný překlad): ");
						} while(Console.ReadLine() == "y");
						break;
					case "2":
						do {
							Console.Clear();
							Console.WriteLine("MORSEOVKA");
							Console.WriteLine(" Konzolový mód");
							Console.WriteLine("  Morse -> Text\n");
							Console.Write("  Zadejte znaky (oddelene znakem '/'): ");
							string output = MorseToText(Console.ReadLine());
							Console.WriteLine("  Output: " + output);
							Console.Write("\n  Znovu? ('y' pro opětovný překlad): ");
						} while(Console.ReadLine() == "y");
						break;
					case "3":
						return;
				}
			} while(true);
		}
		
		public static void SouborovyMod() {
			string output = "";
			string morse = "";
			string text = "";
			do {
				Console.Clear();
				Console.WriteLine("MORSEOVKA");
				Console.WriteLine(" Souborový mód\n");
				Console.WriteLine(" Nacist ze souboru s textem - 1");
				Console.WriteLine(" Nacist ze souboru s morseovkou - 2");
				Console.WriteLine(" Zapsat do souboru s textem - 3");
				Console.WriteLine(" Zapsat do souboru s morseovkou - 4");
				Console.WriteLine(" Nacist ze souboru zprava.txt a ulozit do souboru sifra.txt - 5");
				Console.WriteLine(" Nacist ze souboru sifra.txt a ulozit do souboru zprava.txt - 6");
				Console.WriteLine(" Zpět - 7");
				Console.Write("\nVyberte akci (1/2/3/4/5/6/7): ");
				switch(Console.ReadLine()) {
					case "1":
						Console.Clear();
						Console.WriteLine("MORSEOVKA");
						Console.WriteLine(" Souborový mód");
						Console.WriteLine("  Načtený text\n");
						output = NacistText(fileText);
						Console.WriteLine("  Output: " + output);
						Console.WriteLine("  Překlad: " + TextToMorse(output));
						Console.Write("\nPro návrat zmáčkněte libovolné tlačítko");
						Console.ReadKey(true);
						break;
					case "2":
						Console.Clear();
						Console.WriteLine("MORSEOVKA");
						Console.WriteLine(" Souborový mód");
						Console.WriteLine("  Načtená morseovka\n");
						output = NacistText(fileMorse);
						Console.WriteLine("  Output: " + output);
						Console.WriteLine("  Překlad: " + MorseToText(output));
						Console.Write("\nPro návrat zmáčkněte libovolné tlačítko");
						Console.ReadKey(true);
						break;
					case "3":
						Console.Clear();
						Console.WriteLine("MORSEOVKA");
						Console.WriteLine(" Souborový mód");
						Console.WriteLine("  Zapsání textu do souboru\n");
						Console.Write("  Input: ");
						if(ZapsatText(fileText, Console.ReadLine())) {
							Console.WriteLine("  Zápis byl úspěšný");
						} else {
							Console.WriteLine("  Zápis se nezdařil");
						}
						Console.Write("\nPro návrat zmáčkněte libovolné tlačítko");
						Console.ReadKey(true);
						break;
					case "4":
						Console.Clear();
						Console.WriteLine("MORSEOVKA");
						Console.WriteLine(" Souborový mód");
						Console.WriteLine("  Zapsání morseovky do souboru\n");
						Console.Write("  Input: ");
						if(ZapsatText(fileMorse, Console.ReadLine())) {
							Console.WriteLine("  Zápis byl úspěšný");
						} else {
							Console.WriteLine("  Zápis se nezdařil");
						}
						Console.Write("\nPro návrat zmáčkněte libovolné tlačítko");
						Console.ReadKey(true);
						break;
					case "5":
						Console.Clear();
						Console.WriteLine("MORSEOVKA");
						Console.WriteLine(" Souborový mód");
						Console.WriteLine("  Načtený text\n");
						
						//nacte soubor
						output = NacistText(fileText);
						Console.WriteLine("  Nacteno ze souboru: " + output);
						
						//prevede nacteny text ze souboru na morseovku
						morse = TextToMorse(output);						
						Console.WriteLine("  Překlad: " + morse);
						
						//zapise morseuv kod do souboru
						Console.WriteLine("  Zapsání morseova kodu do souboru\n");
						Console.Write("  Input: ");
						if(ZapsatText(fileMorse, morse)) {
							Console.WriteLine("  Zápis byl úspěšný");
						} else {
							Console.WriteLine("  Zápis se nezdařil");
						}
						Console.Write("\nPro návrat zmáčkněte libovolné tlačítko");
						Console.ReadKey(true);
						break;
					case "6":
						Console.Clear();
						Console.WriteLine("MORSEOVKA");
						Console.WriteLine(" Souborový mód");
						Console.WriteLine("  Načtená morseovka\n");
						
						//nacte soubor
						output = NacistText(fileMorse);
						Console.WriteLine("  Nacteno ze souboru: " + output);
						
						//prevede nacteny morseuv kod na text
						text = MorseToText(output);
						Console.WriteLine("  Překlad: " + text);
						
						//zapise text do souboru						
						Console.WriteLine("  Zapsání textu do souboru\n");
						Console.Write("  Input: ");
						if(ZapsatText(fileText, text)) {
							Console.WriteLine("  Zápis byl úspěšný");
						} else {
							Console.WriteLine("  Zápis se nezdařil");
						}
						Console.Write("\nPro návrat zmáčkněte libovolné tlačítko");
						Console.ReadKey(true);
						break;						
					case "7":
						return;
				}
			} while(true);
		}
		
		public static bool ZapsatText(string file, string text) {
			
			if(File.Exists(file)) {
	            using (StreamWriter sw = new StreamWriter(file, false, Encoding.UTF8))
	            {
	            	sw.WriteLine(text);
	            	return true;
	            }
			}
			
			return false;
		}
		
		public static string NacistText(string file) {
			
			string output = "";
			if(File.Exists(file)) {
	            using (StreamReader sr = new StreamReader(file, Encoding.UTF8))
	            {
	            	output = sr.ReadLine();
	            }
			}
			
			return output;
		}
		
		public static string TextToMorse(string inputText) {

			string output = "";
			/* int index = 0; */
			inputText = inputText.ToLower();
			foreach(char znak in inputText) {
				if(abeceda.Contains(znak.ToString())) {
					output += morseovka[abeceda.IndexOf(znak)] + "/";
				/*index = abeceda.IndexOf(znak);
				if(index != -1) {
					output += morseovka[index] + "/";*/
				} else {
					output += "?/";
				}
			}
			output = output.Remove(output.Length - 1);
			
			return output;
		}
		
		public static string MorseToText(string inputText) {
			
			string output = "";
			bool znakNalezen;
			/*int index;*/
			string [] inputArray = inputText.Split('/');
			foreach(string inputPismeno in inputArray) {
				znakNalezen = false;
				/* index = 0; */
				foreach(string morsePismeno in morseovka) {
					if(inputPismeno == morsePismeno) {
						znakNalezen = true;
						break;
					}
					/* index++; */
				}
								
				if(znakNalezen) {
					output += abeceda[Array.IndexOf(morseovka, inputPismeno)];
					/*output += abeceda[index];*/
				} else {
					output += "?";
				}
			}
			
			return output;
		}
		
	}
}