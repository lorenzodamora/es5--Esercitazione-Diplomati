using System;

namespace es5__23_24
{
	public static class DiplomatiSort
	{
		/**
		 * <summary>
		 * Ordina un array di Diplomati in ordine alfabetico dei nominativi usando l'algoritmo QuickSort.
		 * </summary>
		 * <param name="arr">L'array di Diplomati da ordinare.</param>
		 * <param name="low">L'indice iniziale dell'array o del sottoarray. se è -1 parte da 0</param>
		 * <param name="high">L'indice finale dell'array o del sottoarray. se è -1 finisce in arr.Length - 1</param>
		 */
		public static void Quick(Diplomato[] arr, int low = -1, int high = -1)
		{
			if(low == -1) low = 0;
			if(high == -1) high = arr.Length - 1;
			if(low < high)
			{
				int pivotIndex = Partition(arr, low, high);
				Quick(arr, low, pivotIndex - 1);
				Quick(arr, pivotIndex + 1, high);
			}
		}

		private static int Partition(Diplomato[] arr, int low, int high)
		{
			Diplomato pivot = arr[high];
			int i = low - 1;

			for(int j = low; j < high; j++)
			{
				if(arr[j].Nominativo.CompareTo(pivot.Nominativo) <= 0)
				{
					i++;
					Swap(arr, i, j);
				}
			}

			Swap(arr, i + 1, high);
			return i + 1;
		}

		private static void Swap(Diplomato[] arr, int i, int j)
		{
			/*
			string temp = arr[i];
			arr[i] = arr[j];
			arr[j] = temp;
			*/

			(arr[j], arr[i]) = (arr[i], arr[j]);
		}
	}

}
