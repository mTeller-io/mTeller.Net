using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// The class for momo subscription profile
    /// </summary>
    public class MoMoAPISubscription
    {
        [Key]
        public int SubscriptionId { get; set; }

        //Primary subscription key assigned by API provider
        public Guid PrimarySubscriptionKey { get; set; }

        //Secondary subscription key assigned by API provider
        public Guid SecondarySubscriptionKey { get; set; }

        //Type of product for subscription .e.g collection, disbursement etc
        public string ProductType { get; set; }

        //The name identifier of the API provider
        public string NetworkName { get; set; }

        //API user identification. This must be created
        public Guid APIUser { get; set; }

        //API User key for identification. This must be created
        public Guid APIKey { get; set; }

        //API usage target environment e.g sandbox or production.
        public string TargetEnvironment { get; set; }

        // Host or base url of the API
        public string BaseUrl { get; set; }

        // List of available endpoints
        public ICollection<SubscriptionEndPoint> EndPoints { get; set; }
    }
}