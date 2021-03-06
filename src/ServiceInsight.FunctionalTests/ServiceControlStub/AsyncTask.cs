﻿using System.Threading.Tasks;

namespace NServiceBus.Profiler.FunctionalTests.ServiceControlStub
{
    public static class AsyncTask
    {
        public static readonly Task DefaultCompleted = FromResult(default(AsyncVoid));

        public static Task<TResult> FromResult<TResult>(TResult result)
        {
            var tcs = new TaskCompletionSource<TResult>();
            tcs.SetResult(result);
            return tcs.Task;
        }

        private struct AsyncVoid
        {
        }
    }
}