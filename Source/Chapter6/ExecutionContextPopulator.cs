using System;
using System.Web;
using Bifrost.Execution;

namespace Web
{
    public class ExecutionContextPopulator : ICanPopulateExecutionContextDetails
    {
        public void Populate(IExecutionContext executionContext, dynamic details)
        {
            Guid cartId;
            var cartIdAsString = HttpContext.Current.Session["CartId"] as string;
            if (cartIdAsString != null)
            {
                cartId = Guid.Parse(cartIdAsString);
            } else 
            {
                cartId = Guid.NewGuid();
                HttpContext.Current.Session["CartId"] = cartId.ToString();
            }

            details.CartId = cartId;
        }
    }
}