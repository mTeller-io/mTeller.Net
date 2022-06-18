using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// Available end point for product
    /// </summary>
    public class SubscriptionEndPoint
    {
        //The primary key
        [Key]
        public int EndPointId { get; set; }

        // The subscription profile Id
        public int SubscriptionId { get; set; }

        // Name of the endpoint
        public string Name { get; set; }

        // end point url
        public string EndPoint { get; set; }

        // Description of the end point
        public string Description { get; set; }

        // Json payload structure
        public string JsonPayLoad { get; set; }   ///{Name:CustomerName,AccountNo:CustomerPhone,Amount:CashInAmount,Id:CustomerId}

        //Json response structure
        public string JsonResponse { get; set; }  ///

        // Require headers in the form of keyvalue pair
        public string Headers { get; set; }

        //The subscription
        public virtual MoMoAPISubscription Subscription { get; set; }
    }
}