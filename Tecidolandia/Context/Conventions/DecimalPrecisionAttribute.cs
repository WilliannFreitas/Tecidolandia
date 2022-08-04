using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tecidolandia.Context
{
	public class DecimalPrecisionAttribute : Attribute
	{
		private byte _precision;
		private byte _scale;
		public byte Precision
		{

			get { return _precision; }
			set { _precision = value; }
		}
		public byte Scale
		{
			get { return _scale; }
			set { _scale = value; }
		}
		public DecimalPrecisionAttribute(byte precision, byte scale)
		{
			this.Precision = precision;
			this.Scale = scale;
		}
	}
}