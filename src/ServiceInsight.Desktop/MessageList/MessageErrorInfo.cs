﻿using System;
using System.Windows.Media.Imaging;
using NServiceBus.Profiler.Desktop.ExtensionMethods;
using NServiceBus.Profiler.Desktop.Models;
using NServiceBus.Profiler.Desktop.Properties;

namespace NServiceBus.Profiler.Desktop.MessageList
{
    public class MessageErrorInfo : IComparable
    {
        private MessageStatus _status;
        private bool _statusSpecified;

        public MessageErrorInfo()
        {
            Image = GetImage();
        }

        public MessageErrorInfo(MessageStatus status)
        {
            Status = status;
            Image = GetImage();
            Description = status.GetDescription();
        }

        public BitmapImage Image { get; private set; }

        public MessageStatus Status
        {
            get { return _status; }
            private set
            {
                _status = value;
                _statusSpecified = true;
            }
        }

        public string Description { get; private set; }

        private BitmapImage GetImage()
        {
            if(!_statusSpecified)
                return Resources.BulletWhite.ToBitmapImage();
            
            switch (Status)
            {
                case MessageStatus.Failed:
                    return Resources.BulletYellow.ToBitmapImage();
                case MessageStatus.ArchivedFailure:
                    return Resources.BulletArchived.ToBitmapImage();
                case MessageStatus.RepeatedFailure:
                    return Resources.BulletRed.ToBitmapImage();
                case MessageStatus.Successful:
                    return Resources.BulletGreen.ToBitmapImage();
                case MessageStatus.ResolvedSuccessfully:
                    return Resources.BulletGreen.ToBitmapImage();
                case MessageStatus.RetryIssued:
                    return Resources.BulletWhite.ToBitmapImage();
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Status {0} is not implemented", Status));
            }
        }

        public int CompareTo(object obj)
        {
            var that = obj as MessageErrorInfo;
            if (that == null) return -1;

            if (_statusSpecified == false &&
                that._statusSpecified == false)
            {
                return 0;
            }

            return that.Status.CompareTo(Status);
        }

        public override string ToString()
        {
            if (!_statusSpecified)
                return "Not Specified";

            switch (Status)
            {
                case MessageStatus.Failed:
                    return "Failed";
                case MessageStatus.RepeatedFailure:
                    return "Faulted";
                case MessageStatus.Successful:
                    return "Success";
                case MessageStatus.RetryIssued:
                    return "Retried";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}