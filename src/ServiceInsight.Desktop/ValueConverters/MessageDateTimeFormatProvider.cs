﻿using System;
using System.Globalization;
using System.Threading;
using System.Windows.Data;

namespace NServiceBus.Profiler.Desktop.ValueConverters
{
    public class MessageDateTimeFormatProvider
    {
        static MessageDateTimeFormatProvider()
        {
            MessageDateFormat = GetCultureDateTimeFormat();
        }

        private static string GetCultureDateTimeFormat()
        {
            var culture = Thread.CurrentThread.CurrentCulture;

            return string.Format("{0} hh:mm:ss.ffff tt", culture.DateTimeFormat.ShortDatePattern);
        }

        public static string MessageDateFormat { get; private set; }
    }
}