using System;
using System.ComponentModel;

namespace AAStudio.Diploma.Args
{
	public class TypedEventArgs<T> : AsyncCompletedEventArgs
	{
		public TypedEventArgs(T data) : base(null, false, null)
		{
			Data = data;
		}

		public TypedEventArgs(T data, Exception exception, bool isCanceled) : base(exception, isCanceled, null)
		{
			Data = data;
		}

		public T Data { get; private set; }
	}
}
