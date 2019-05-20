using System;
using ForestOfChaosLibrary.Extensions;

namespace ForestOfChaosLibrary.Utilities
{
	public class ActionOnDispose: IDisposable
	{
		private readonly Action action;

		public ActionOnDispose(Action action)
		{
			this.action = action;
		}

		public void Dispose()
		{
			action.Trigger();
		}
	}
}
