using System;
using Android.OS;

namespace CIM
{
	[Serializable()]
	public class Messaggio 
	{
		private string _mittente;
		private string _testoMessaggio;

		public Messaggio(){	}

		public Messaggio(string mittente, string testo){
			_mittente = mittente; _testoMessaggio = testo;
		}

		public string Mittente {
			get {
				return _mittente;
			}
			set {
				_mittente = value;
			}
		}

		public string TestoMessaggio {
			get {
				return _testoMessaggio;
			}
			set {
				_testoMessaggio = value;
			}
		}
	}
}

