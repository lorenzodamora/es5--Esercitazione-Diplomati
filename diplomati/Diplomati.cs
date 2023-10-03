using System;

namespace es5__23_24
{
	public class Diplomati
	{
		private Diplomato[] elencoDiplomati;
		private short diplomatiCounter;

		public Diplomati(int tot = 20)
		{
			elencoDiplomati = new Diplomato[tot];
			diplomatiCounter = 0;
		}

		public Diplomato this[int index]
		{
			get
			{
				if(index >= 0 && index < diplomatiCounter)
					return elencoDiplomati[index];
				throw new IndexOutOfRangeException("L'indice specificato non è valido.");
			}
			set
			{
				if(index >= 0 && index < diplomatiCounter)
					elencoDiplomati[index] = value;
				else
					throw new IndexOutOfRangeException("L'indice specificato non è valido.");
			}
		}

		public Diplomato[] GetElenco() { return elencoDiplomati; }

		private static int GetLength(int tot)
		{
			if(tot < 20) return 20;
			return tot/20 * 20 + 20;
		}

		private static void Resize(ref Diplomato[] array, int newSize)
		{
			if(array.Length != newSize)
			{
				Diplomato[] array2 = new Diplomato[newSize];
				if(array.Length < newSize) //se newsize è più grande, copia fino ad array.length e il resto rimane default
					for(int i = 0; i < array.Length; i++)
						array2[i] = array[i];
				else //se newsize è più piccolo copia fino a newsize
					for(int i = 0; i < newSize; i++)
						array2[i] = array[i];
				array = array2;
			}
		}

		public void AggiungiDiplomato(Diplomato diplomato)
		{
			if(diplomatiCounter < elencoDiplomati.Length)
			{
				elencoDiplomati[diplomatiCounter] = diplomato;
				diplomatiCounter++;
			}
			else
			{
				//throw new InvalidOperationException("L'elenco dei voti è pieno.");
				//resize
				Resize(ref elencoDiplomati, GetLength(diplomatiCounter));
				AggiungiDiplomato(diplomato);
			}
		}

		public string[] GetNominativi()
		{
			string[] result = new string[diplomatiCounter];
			for(int i = 0; i < diplomatiCounter; i++)
				result[i] = elencoDiplomati[i].Nominativo;

			return result;
		}

		public string[] GetAbiliAiConcorsi()
		{
			int c = 0;
			for(int i = 0; i < diplomatiCounter; i++)
				if(elencoDiplomati[i].GetAbileAiConcorsi())
					c++;

			string[] result = new string[c];
			c = 0;

			for(int i = 0; i < diplomatiCounter; i++)
				if(elencoDiplomati[i].GetAbileAiConcorsi())
					result[c++] = elencoDiplomati[i].Nominativo;

			return result;
		}

		/// <summary>
		/// ordine alfabetico
		/// </summary>
		public void OrdinaPerNominativi()
		{
			DiplomatiSort.Quick(elencoDiplomati, 0, diplomatiCounter - 1);
		}

	}
}
