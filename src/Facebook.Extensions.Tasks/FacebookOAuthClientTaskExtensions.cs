
namespace Facebook
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;
    using Facebook;

    /// <summary>
    /// Task Parallel Library extension methods for <see cref="FacebookOAuthClient"/>.
    /// </summary>
    public static class FacebookOAuthClientTaskExtensions
    {
        /// <summary>
        /// Gets the application access token asynchronously.
        /// </summary>
        /// <param name="facebookOAuthClient">The Facebook OAuth Client.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The task of the result.</returns>
        public static Task<object> GetApplicationAccessTokenTaskAsync(this FacebookOAuthClient facebookOAuthClient, IDictionary<string, object> parameters)
        {
            var tcs = FacebookClientTaskExtensions.CreateSource<object>(null);

            EventHandler<FacebookApiEventArgs> handler = null;
            handler = (sender, e) => FacebookClientTaskExtensions.TransferCompletionToTask<object>(tcs, e, () => e.GetResultData(), () => facebookOAuthClient.GetApplicationAccessTokenCompleted -= handler);

            facebookOAuthClient.GetApplicationAccessTokenCompleted += handler;

            try
            {
                facebookOAuthClient.GetApplicationAccessTokenAsync(parameters, tcs);
            }
            catch
            {
                facebookOAuthClient.GetApplicationAccessTokenCompleted -= handler;
                tcs.TrySetCanceled();
                throw;
            }

            return tcs.Task;
        }

        /// <summary>
        /// Gets the application access token asynchronously.
        /// </summary>
        /// <param name="facebookOAuthClient">The Facebook OAuth Client.</param>
        /// <returns>The task of the result.</returns>
        public static Task<object> GetApplicationAccessTokenTaskAsync(this FacebookOAuthClient facebookOAuthClient)
        {
            return GetApplicationAccessTokenTaskAsync(facebookOAuthClient, null);
        }

        /// <summary>
        /// Exchange code for access token asynchronously.
        /// </summary>
        /// <param name="facebookOAuthClient">The Facebook OAuth Client.</param>
        /// <param name="code">The code.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The task of the result.</returns>
        public static Task<object> ExchangeCodeForAccessTokenTaskAsync(this FacebookOAuthClient facebookOAuthClient, string code, IDictionary<string, object> parameters)
        {
            var tcs = FacebookClientTaskExtensions.CreateSource<object>(null);

            EventHandler<FacebookApiEventArgs> handler = null;
            handler = (sender, e) => FacebookClientTaskExtensions.TransferCompletionToTask<object>(tcs, e, () => e.GetResultData(), () => facebookOAuthClient.ExchangeCodeForAccessTokenCompleted -= handler);

            facebookOAuthClient.GetApplicationAccessTokenCompleted += handler;

            try
            {
                facebookOAuthClient.ExchangeCodeForAccessTokenAsync(code, parameters, tcs);
            }
            catch
            {
                facebookOAuthClient.ExchangeCodeForAccessTokenCompleted -= handler;
                tcs.TrySetCanceled();
                throw;
            }

            return tcs.Task;
        }

        /// <summary>
        /// Exchange code for access token asynchronously.
        /// </summary>
        /// <param name="facebookOAuthClient">The Facebook OAuth Client.</param>
        /// <param name="code">The code.</param>
        /// <returns>The task of the result.</returns>
        public static Task<object> ExchangeCodeForAccessTokenTaskAsync(this FacebookOAuthClient facebookOAuthClient, string code)
        {
            return ExchangeCodeForAccessTokenTaskAsync(facebookOAuthClient, code, null);
        }
    }
}
