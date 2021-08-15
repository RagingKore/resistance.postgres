// ReSharper disable CheckNamespace

namespace System.Threading
{
    using Tasks;

    /// <summary>
    /// Replaces the need to place ConfigureAwait(false) everywhere, making all await continuations execute on the thread pool.
    /// </summary>
    /// <remarks>
    /// Warning: do not use this directly in async methods, use it in sync wrappers of async methods
    /// (see https://github.com/npgsql/npgsql/issues/1593 and http://stackoverflow.com/a/28307965/640325)
    /// </remarks>
    static class SynchronizationContextScope
    {
        internal static Disposable DisabledSyncContext() {
            var context = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(null);

            return new(context);
        }

        internal readonly struct Disposable : IDisposable, IAsyncDisposable
        {
            internal Disposable(SynchronizationContext? context) => Context = context;

            SynchronizationContext? Context { get; }

            public void Dispose() => SynchronizationContext.SetSynchronizationContext(Context);

            public ValueTask DisposeAsync() {
                Dispose();

                return ValueTask.CompletedTask;
            }
        }
    }
}