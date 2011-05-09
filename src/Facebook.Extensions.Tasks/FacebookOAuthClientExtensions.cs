
namespace Facebook
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;
    using Facebook;

    public static class FacebookOAuthClientExtensions
    {
        public static Task<object> GetApplicationAccessTokenTaskAsync(this FacebookOAuthClient facebookOAuthClient, IDictionary<string, object> paramaters)
        {
            var tcs = FacebookClientTaskExtensions.CreateSource<object>(null);

            EventHandler<FacebookApiEventArgs> handler = null;
            handler = (sender, e) => FacebookClientTaskExtensions.TransferCompletionToTask<object>(tcs, e, () => e.GetResultData(), () => facebookOAuthClient.GetApplicationAccessTokenCompleted -= handler);

            facebookOAuthClient.GetApplicationAccessTokenCompleted += handler;

            try
            {
                facebookOAuthClient.GetApplicationAccessTokenAsync(paramaters, tcs);
            }
            catch
            {
                facebookOAuthClient.GetApplicationAccessTokenCompleted -= handler;
                tcs.TrySetCanceled();
                throw;
            }

            return tcs.Task;
        }

        public static Task<object> GetApplicationAccessTokenTaskAsync(this FacebookOAuthClient facebookOAuthClient)
        {
            return GetApplicationAccessTokenTaskAsync(facebookOAuthClient, null);
        }
    }
}
