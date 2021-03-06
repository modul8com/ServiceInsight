﻿using Caliburn.PresentationFramework;

namespace NServiceBus.Profiler.Desktop.MessageList
{
    public interface ITableViewModel<T>
    {
        IObservableCollection<T> Rows { get; } 
        T FocusedRow { get; set; }
    }
}