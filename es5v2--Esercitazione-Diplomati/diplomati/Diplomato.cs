//using System;

namespace es5__23_24
{
	public class Diplomato
	{
		private string _nominativo = "nessun nominativo";
		private float _voto = 0f;
		//private bool _old = true; //se false da 60 a 100, se true da 36 a 60.

		private const int _minVoto = 36;
		private const int _maxVoto = 60;
		private const int _minConcorsi = 42;

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
		protected float _SetVoto
		{
			set { _voto = value; }
		}

		//
		public Diplomato(string nominativo = "nessun nominativo", float voto = 0f)
		{
			if(!SetDiplomato(nominativo, voto))
			{
				_nominativo = "inserimento non valido, [throw]";
				_voto = 0f;
			}
		}

		public Diplomato(string nominativo, string voto_stringa)
		{
			if(!SetDiplomato(nominativo, voto_stringa))
			{
				_nominativo = "inserimento non valido, [throw]";
				_voto = 0f;
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

	public class Nuovo : Diplomato
	{
		private const short _minVoto = 60;
		private const short _maxVoto = 100;
		private const short _minConcorsi = 70;

		public Nuovo(string nominativo = "nessun nominativo", float voto = 0f)
		{
			if(!SetNominativo(nominativo) & SetVoto(voto))
			{
				Nominativo = "inserimento non valido, [throw]";
				_SetVoto = 0f;
			}

		}

		public Nuovo(string nominativo, string voto_stringa)
		{
			if(!SetNominativo(nominativo) & SetVoto(voto_stringa))
			{
				Nominativo = "inserimento non valido, [throw]";
				_SetVoto = 0f;
			}
		}

		new public bool SetVoto(float voto)
		{
			//(_old ? 36 : 60) (_old ? 60 : 100)
			if(voto < _minVoto) return false; // non si è diplomato
			if(voto > _maxVoto) return false; // è oltre i valori consentiti
			_SetVoto = voto;
			return true;
		}

		new public bool SetVoto(string voto_stringa)
		{
			if(float.TryParse(voto_stringa, out float voto) || voto < _minVoto || voto > _maxVoto)
			{
				_SetVoto = voto;
				return true;
			}
			else
				return false;
		}

		//
		new public bool GetAbileAiConcorsi()
		{
			return Voto >= _minConcorsi;
		}

	}

	public class Class0
	{
		private int voto;
		protected virtual int MinVoto { get { return 10; } }
		public int Voto
		{
			get { return voto; }
			set { SetVoto(value); }
		}
		public Class0(int voto) { SetVoto(voto); }
		public void SetVoto(int voto) { if(voto >= MinVoto) this.voto = voto; }
	}
	public class Class1 : Class0
	{
		protected override int MinVoto { get { return 20; } }
		public Class1(int voto) : base(voto) { }
	}
}
