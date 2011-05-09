
namespace Facebook
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;
    using Facebook;

    public static class FacebookTaskExtensions
    {
        /// <summary>
        /// Makes an asynchronous DELETE request to the Facebook server.
        /// </summary>
        /// <param name="facebookClient">The facebook client.</param>
        /// <param name="path">The resource path.</param>
        /// <returns>The task of the result.</returns>
        public static Task<object> DeleteTaskAsync(this FacebookClient facebookClient, string path)
        {
            return DeleteTaskAsync(facebookClient, path, null);
        }

        /// <summary>
        /// Makes an asynchronous DELETE request to the Facebook server.
        /// </summary>
        /// <param name="facebookClient">The facebook client.</param>
        /// <param name="path">The resource path.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The task of the result.</returns>
        public static Task<object> DeleteTaskAsync(this FacebookClient facebookClient, string path, IDictionary<string, object> parameters)
        {
            Contract.Requires(!(string.IsNullOrEmpty(path) && parameters == null));

            var tcs = CreateSource<object>(null);

            EventHandler<FacebookApiEventArgs> handler = null;
            handler = (sender, e) => TransferCompletionToTask<object>(tcs, e, () => e.GetResultData(), () => facebookClient.DeleteCompleted -= handler);

            facebookClient.DeleteCompleted += handler;

            try
            {
                facebookClient.DeleteAsync(path, parameters, tcs);
            }
            catch
            {
                facebookClient.DeleteCompleted -= handler;
                tcs.TrySetCanceled();
                throw;
            }

            return tcs.Task;
        }

        /// <summary>
        /// Makes an asynchronous GET request to the Facebook server.
        /// </summary>
        /// <param name="facebookClient">The facebook client.</param>
        /// <param name="path">The resource path.</param>
        /// <returns>The task of the result.</returns>
        public static Task<object> GetTaskAsync(this FacebookClient facebookClient, string path)
        {
            Contract.Requires(!string.IsNullOrEmpty(path));

            return GetTaskAsync(facebookClient, path, null);
        }

        /// <summary>
        /// Makes an asynchronous GET request to the Facebook server.
        /// </summary>
        /// <param name="facebookClient">The facebook client.</param>
        /// <param name="path">The resource path.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The task of the result.</returns>
        public static Task<object> GetTaskAsync(this FacebookClient facebookClient, string path, IDictionary<string, object> parameters)
        {
            Contract.Requires(!(string.IsNullOrEmpty(path) && parameters == null));

            var tcs = CreateSource<object>(null);

            EventHandler<FacebookApiEventArgs> handler = null;
            handler = (sender, e) => TransferCompletionToTask<object>(tcs, e, () => e.GetResultData(), () => facebookClient.GetCompleted -= handler);

            facebookClient.GetCompleted += handler;

            try
            {
                facebookClient.GetAsync(path, parameters, tcs);
            }
            catch
            {
                facebookClient.GetCompleted -= handler;
                tcs.TrySetCanceled();
                throw;
            }

            return tcs.Task;
        }

        /// <summary>
        /// Makes an asynchronous GET request to the Facebook server.
        /// </summary>
        /// <param name="facebookClient">The facebook client.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The task of the result.</returns>
        public static Task<object> GetTaskAsync(this FacebookClient facebookClient, IDictionary<string, object> parameters)
        {
            Contract.Requires(parameters != null);

            return GetTaskAsync(facebookClient, null, parameters);
        }

        /// <summary>
        /// Makes an asynchronous POST request to the Facebook server.
        /// </summary>
        /// <param name="facebookClient">The facebook client.</param>
        /// <param name="path">The resource path.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The task of the result.</returns>
        public static Task<object> PostTaskAsync(this FacebookClient facebookClient, string path, IDictionary<string, object> parameters)
        {
            Contract.Requires(!(string.IsNullOrEmpty(path) && parameters == null));

            var tcs = CreateSource<object>(null);

            EventHandler<FacebookApiEventArgs> handler = null;
            handler = (sender, e) => TransferCompletionToTask<object>(tcs, e, () => e.GetResultData(), () => facebookClient.PostCompleted -= handler);

            facebookClient.PostCompleted += handler;

            try
            {
                facebookClient.PostAsync(path, parameters, tcs);
            }
            catch
            {
                facebookClient.PostCompleted -= handler;
                tcs.TrySetCanceled();
                throw;
            }

            return tcs.Task;
        }

        /// <summary>
        /// Makes an asynchronous POST request to the Facebook server.
        /// </summary>
        /// <param name="facebookClient">The facebook client.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The task of the result.</returns>
        public static Task<object> PostTaskAsync(this FacebookClient facebookClient, IDictionary<string, object> parameters)
        {
            Contract.Requires(parameters != null);

            return PostTaskAsync(facebookClient, null, parameters);
        }

        /// <summary>
        /// Makes an asynchronous POST request to the Facebook server.
        /// </summary>
        /// <param name="facebookClient">The facebook client.</param>
        /// <param name="path">The resource path.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The task of the result.</returns>
        public static Task<object> PostTaskAsync(this FacebookClient facebookClient, string path, object parameters)
        {
            Contract.Requires(!(string.IsNullOrEmpty(path) && parameters == null));

            return PostTaskAsync(facebookClient, path, ToDictionary(parameters));
        }

        /// <summary>
        /// Makes an asynchronous POST request to the Facebook server.
        /// </summary>
        /// <param name="facebookClient">The facebook client.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The task of the result.</returns>
        public static Task<object> PostTaskAsync(this FacebookClient facebookClient, object parameters)
        {
            Contract.Requires(parameters != null);

            return PostTaskAsync(facebookClient, null, parameters);
        }

        /// <summary>
        /// Executes a FQL query asynchronously.
        /// </summary>
        /// <param name="facebookClient">The facebook client.</param>
        /// <param name="fql">The FQL query.</param>
        /// <returns>The task of the result.</returns>
        public static Task<object> QueryTaskAsync(this FacebookClient facebookClient, string fql)
        {
            Contract.Requires(!string.IsNullOrEmpty(fql));

            var tcs = CreateSource<object>(null);

            EventHandler<FacebookApiEventArgs> handler = null;
            handler = (sender, e) => TransferCompletionToTask<object>(tcs, e, () => e.GetResultData(), () => facebookClient.GetCompleted -= handler);

            facebookClient.GetCompleted += handler;

            try
            {
                facebookClient.QueryAsync(fql, tcs);
            }
            catch
            {
                facebookClient.GetCompleted -= handler;
                tcs.TrySetCanceled();
                throw;
            }

            return tcs.Task;
        }

        /// <summary>
        /// Executes a FQL multiquery asynchronously.
        /// </summary>
        /// <param name="facebookClient">The facebook client.</param>
        /// <param name="fql">The FQL query.</param>
        /// <returns>The task of the result.</returns>
        public static Task<object> QueryTaskAsync(this FacebookClient facebookClient, params string[] fql)
        {
            Contract.Requires(!string.IsNullOrEmpty(fql));

            var tcs = CreateSource<object>(null);

            EventHandler<FacebookApiEventArgs> handler = null;
            handler = (sender, e) => TransferCompletionToTask<object>(tcs, e, () => e.GetResultData(), () => facebookClient.GetCompleted -= handler);

            facebookClient.GetCompleted += handler;

            try
            {
                facebookClient.QueryAsync(fql, tcs);
            }
            catch
            {
                facebookClient.GetCompleted -= handler;
                tcs.TrySetCanceled();
                throw;
            }

            return tcs.Task;
        }

        private static TaskCompletionSource<T> CreateSource<T>(object state)
        {
            return new TaskCompletionSource<T>(state);
        }

        private static void TransferCompletionToTask<T>(TaskCompletionSource<T> tcs, AsyncCompletedEventArgs e, Func<T> getResult, Action unregisterHandler)
        {
            if (e.UserState == tcs)
            {
                if (e.Cancelled) tcs.TrySetCanceled();
                else if (e.Error != null) tcs.TrySetException(e.Error);
                else tcs.TrySetResult(getResult());
                if (unregisterHandler != null) unregisterHandler();
            }
        }

        /// <summary>
        /// Convert the object to dictionary.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// Returns the dictionary equivalent of the specified object.
        /// </returns>
        private static IDictionary<string, object> ToDictionary(object parameters)
        {
            Contract.Requires(parameters != null);
            Contract.Ensures(Contract.Result<IDictionary<string, object>>() != null);

            if (parameters is JsonObject)
            {
                return (JsonObject)parameters;
            }

            var json = JsonSerializer.Current.SerializeObject(parameters);
            return (IDictionary<string, object>)JsonSerializer.Current.DeserializeObject(json);
        }
    }
}
