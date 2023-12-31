﻿using System;

namespace es5__23_24
{
	internal class Starter
	{
		/*
		 * Realizzare un programma in c# in grado di gestire un elenco di diplomati.
		 * I diplomati si dividono in vecchi diplomati e nuovi diplomati,
		 * rispettivamente con voto da 36 a 60 per i vecchi e da 60 a 100 per i nuovi.
		 * I vecchi diplomati sono abili ai concorsi con voto maggiore o uguale a 42,
		 * mentre i nuovi con voto maggiore o uguale a 70.
		 * 
		 * Le funzionalità richieste sono:
		 * - inserimento dei diplomati
		 * - stampa di tutti i diplomati
		 * - stampa dei diplomati abili ai concorsi.
		 */
		static void Main()
		{
			Console.WriteLine("Schermo intero? (f11)");
			Console.ReadKey();
			Console.Clear();
			Console.WriteLine("ho già riempito randomicamente con 40 nuovi diplomati e il loro voto da 60 a 100\n");

			// Liste di cognomi e nomi e materie
			string[] cognomi =
			{
				"Rossi", "Bianchi", "Verdi", "Ferrari", "Esposito", "Ricci", "Romano", "Gallo",
				"Greco", "Conti", "Mancini", "Marino", "Santoro", "Ferrara", "Ferri", "Barbieri",
				"Silvestri", "Russo", "Colombo", "De Luca", "Serra", "Gatti", "Riva", "Caruso",
				"Moretti", "Testa", "Villa", "Marchetti", "Benedetti"
			};

			string[] nomi =
			{
				"Mario", "Luigi", "Anna", "Maria", "Giovanni", "Giuseppe", "Sofia", "Elena",
				"Antonio", "Francesca", "Marco", "Alessia", "Luca", "Lorenzo", "Simona", "Roberto",
				"Paola", "Emanuele", "Valentina", "Federico", "Fabio", "Laura", "Vittorio",
				"Riccardo", "Alessandro", "Elisa", "Stefano", "Giulia", "Sara"
			};

			Diplomati diplomati = new Diplomati(20);
			Random rnd = new Random();

			for(int i = 0; i < 40; i++)
			{
				diplomati.AggiungiDiplomato(new Diplomato(cognomi[rnd.Next(cognomi.Length)] + " " + nomi[rnd.Next(nomi.Length)], rnd.Next(60, 100+1)));
			}

			diplomati.OrdinaPerNominativi();

			Console.WriteLine("\nDi seguito l'elenco ordinato dei diplomati (solo nominativi)\n");
			Console.WriteLine(string.Join("\n", diplomati.GetNominativi()));

			Console.WriteLine("\nDi seguito l'elenco ordinato dei diplomati abili ai concorsi (solo nominativi)\n");
			Console.WriteLine(string.Join("\n", diplomati.GetAbiliAiConcorsi()));

			Console.WriteLine("\n\nFINE\n");
			Console.ReadKey(true);
		}
	}
}
