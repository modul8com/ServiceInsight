﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Caliburn.PresentationFramework.ApplicationModel;
using NServiceBus.Profiler.Desktop.Core;
using NServiceBus.Profiler.Desktop.Core.MessageDecoders;
using NServiceBus.Profiler.Desktop.Models;

namespace NServiceBus.Profiler.Desktop.MessageProperties
{
    public class GatewayHeaderViewModel : HeaderInfoViewModelBase, IGatewayHeaderViewModel
    {
        public GatewayHeaderViewModel(
            IEventAggregator eventAggregator, 
            IContentDecoder<IList<HeaderInfo>> decoder, 
            IQueueManagerAsync queueManager) 
            : base(eventAggregator, decoder, queueManager)
        {
            DisplayName = "Gateway";
        }

        [Description("From address")]
        public string From { get; private set; }

        [Description("To address")]
        public string To { get; private set; }

        [Description("Destination sites")]
        public string DestinationSites { get; private set; }

        [Description("Originating site")]
        public string OriginatingSite { get; private set; }

        [Description("Route to address")]
        public string RouteTo { get; private set; }

        protected override void MapHeaderKeys()
        {
            ConditionsMap.Add(h => h.Key.EndsWith(".From", StringComparison.OrdinalIgnoreCase), h => From = h.Value);
            ConditionsMap.Add(h => h.Key.EndsWith(".To", StringComparison.OrdinalIgnoreCase), h => To = h.Value);
            ConditionsMap.Add(h => h.Key.EndsWith(".DestinationSites", StringComparison.OrdinalIgnoreCase), h => DestinationSites = h.Value);
            ConditionsMap.Add(h => h.Key.EndsWith(".OriginatingSite", StringComparison.OrdinalIgnoreCase), h => OriginatingSite = h.Value);
            ConditionsMap.Add(h => h.Key.EndsWith(".Header.RouteTo", StringComparison.OrdinalIgnoreCase), h => RouteTo = h.Value);
        }

        protected override void ClearHeaderValues()
        {
            From = null;
            To = null;
            DestinationSites = null;
            OriginatingSite = null;
            RouteTo = null;
        }
    }
}