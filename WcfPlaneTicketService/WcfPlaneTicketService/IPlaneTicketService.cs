﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfPlaneTicketService
{
    [ServiceContract]
    public interface IPlaneTicketService
    {
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/{userId}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        User getUser(string userId); // userId = Email

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/flights/{userId}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]        
        List<Route> getUserFlightsInfo(string userId); // without time and price 

        [OperationContract]  
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/flights/{userId}/details",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]       
        List<Route> getFullUserFlightsInfo(string userId); // with time and price      

        [OperationContract]  //?? что из клиента получаю? parameters - from + where + date + time + price ??
        [WebInvoke(Method = "POST", UriTemplate = "/addFlight/{userId}/{parameters}")]
        void addFlight(string userId, string parameters);

        [OperationContract]  //?? что из клиента получаю? parameters - from + where + date + time + price ??
        [WebInvoke(Method = "POST", UriTemplate = "/updateFlight/{userId}/{userFlightId}/{parameters}")]
        void updateFlight(string userId, string userFlightId, string parameters);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/deleteFlight/{userId}/{userFlightId}")]
        void deleteFlight(string userId, string userFlightId);

        void setToken(string methodName, string tokenValue);
        // methods which gets payment token
    }

    public class Token
    {
        public string methodName { get; set; }
        public string tokenValue { get; set; }
    }

    [DataContract]
    public class Route
    {
        [DataMember]
        public string routeId { get; set; }
        [DataMember]
        public string routeFrom { get; set; }
        [DataMember]
        public string routeWhere { get; set; }
        [DataMember]
        public string routeDate { get; set; }
        [DataMember]
        public string routeTime { get; set; }
        [DataMember]
        public string routePrice { get; set; }
    }

    [DataContract]
    public class UserFlight
    {
        [DataMember]
        public string userFlightRouteId { get; set; }
        [DataMember]
        public string userFlightUserId { get; set; }
    }

    [DataContract]
    public class User
    {
        [DataMember]
        public string userId { get; set; }   // Email = Id
        //[DataMember]
        //public string userEmail { get; set; }
        [DataMember]
        public string userFirstName { get; set; }
        [DataMember]
        public string userSecondName { get; set; }
    }
}