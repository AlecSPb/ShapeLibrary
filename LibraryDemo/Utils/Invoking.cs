﻿using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace LibraryDemo.Utils
{
	public static class Invoking
	{
		public static void InvokeIfRequired(Action action)
		{
			InvokeIfRequired(action, DispatcherPriority.Background);
		}

		public static void InvokeIfRequired(Action action, DispatcherPriority dispatcherPriority)
		{
			if (IsMainThread)
				action();
			else
				Application.Current.Dispatcher.Invoke(action, dispatcherPriority, null);
		}

		public static void BeginInvokeIfRequired(Action action)
		{
			BeginInvokeIfRequired(action, DispatcherPriority.Background);
		}

		public static void BeginInvokeIfRequired(Action action, DispatcherPriority dispatcherPriority)
		{
			if (IsMainThread)
				action();
			else
				Application.Current.Dispatcher.BeginInvoke(action, dispatcherPriority, null);
		}

		public static bool IsMainThread => Application.Current == null || Thread.CurrentThread == Application.Current.Dispatcher.Thread;
	}
}