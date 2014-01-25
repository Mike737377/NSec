using System;
using System.Web;

namespace NSec
{
    public class NSecModule : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>

        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
        }

        #endregion IHttpModule Members

        public void OnBeginRequest(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}