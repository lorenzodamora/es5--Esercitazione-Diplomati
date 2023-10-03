//using System;

namespace es5__23_24
{
	public class Diplomato
	{
		private string _nominativo = "nessun nominativo";
		private float _voto = 0f;
		private bool _old = false; //se false da 60 a 100, se true da 36 a 60.

		private int _minVoto = 60; //36
		private int _maxVoto = 100; //60
		private int _minConcorsi = 70; //42

		/**
		 * <summary>
		 * Ottiene o imposta il nominativo (nome e cognome).
		 * </summary>
		 */
		public string Nominativo
		{
			get { return _nominativo; }
			set { SetNominativo(value); }
		}

		public float Voto
		{
			get { return _voto; }
			set { SetVoto(value); }
		}

		public bool Old
		{
			get { return _old; }
		}

		//
		public Diplomato(string nominativo = "nessun nominativo", float voto = 0f, bool vecchia_notazione = false)
		{
			if(!SetDiplomato(nominativo, voto))
			{
				_nominativo = "inserimento non valido, [throw]";
				_voto = 0f;
			}
			else
			{
				_old = vecchia_notazione;
				if(_old)
				{
					_minVoto = 36;
					_maxVoto = 60;
					_minConcorsi = 42;
				}
			}
		}

		public Diplomato(string nominativo, string voto_stringa, bool vecchia_notazione = false)
		{
			if(!SetDiplomato(nominativo, voto_stringa))
			{
				_nominativo = "inserimento non valido, [throw]";
				_voto = 0f;
			}
			else
			{
				_old = vecchia_notazione;
				if(_old)
				{
					_minVoto = 36;
					_maxVoto = 60;
					_minConcorsi = 42;
				}
			}
		}

		//
		public bool SetNominativo(string nominativo)
		{
			if(string.IsNullOrEmpty(nominativo)) return false;
			_nominativo = nominativo;
			return true;
		}

		public bool SetVoto(float voto)
		{
			//(_old ? 36 : 60) (_old ? 60 : 100)
			if(voto < _minVoto) return false; // non si è diplomato
			if(voto > _maxVoto) return false; // è oltre i valori consentiti
			_voto = voto;
			return true;
		}

		public bool SetVoto(string voto_stringa)
		{
			if(float.TryParse(voto_stringa, out float voto) || voto < _minVoto || voto > _maxVoto)
			{
				_voto = voto;
				return true;
			}
			else
				return false;
		}

		public bool SetDiplomato(string nominativo, float voto)
		{
			return SetNominativo(nominativo) & SetVoto(voto);
		}

		public bool SetDiplomato(string nominativo, string voto_stringa)
		{
			return SetNominativo(nominativo) & SetVoto(voto_stringa);
		}

		//
		public bool GetAbileAiConcorsi()
		{
			return _voto >= _minConcorsi;
		}
	}
}
