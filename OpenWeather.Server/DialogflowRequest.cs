// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using OpenWeather.Server;
//
//    var dialogflowRequest = DialogflowRequest.FromJson(jsonString);

namespace OpenWeather.Server.Request
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DialogflowRequest
    {
        [JsonProperty("responseId")]
        public string ResponseId { get; set; }

        [JsonProperty("session")]
        public string Session { get; set; }

        [JsonProperty("queryResult")]
        public QueryResult QueryResult { get; set; }

        [JsonProperty("originalDetectIntentRequest")]
        public OriginalDetectIntentRequest OriginalDetectIntentRequest { get; set; }
    }

    public partial class OriginalDetectIntentRequest
    {
    }

    public partial class QueryResult
    {
        [JsonProperty("queryText")]
        public string QueryText { get; set; }

        [JsonProperty("parameters")]
        public Parameters Parameters { get; set; }

        [JsonProperty("allRequiredParamsPresent")]
        public bool AllRequiredParamsPresent { get; set; }

        [JsonProperty("fulfillmentText")]
        public string FulfillmentText { get; set; }

        [JsonProperty("fulfillmentMessages")]
        public FulfillmentMessage[] FulfillmentMessages { get; set; }

        [JsonProperty("outputContexts")]
        public OutputContext[] OutputContexts { get; set; }

        [JsonProperty("intent")]
        public Intent Intent { get; set; }

        [JsonProperty("intentDetectionConfidence")]
        public long IntentDetectionConfidence { get; set; }

        [JsonProperty("diagnosticInfo")]
        public OriginalDetectIntentRequest DiagnosticInfo { get; set; }

        [JsonProperty("languageCode")]
        public string LanguageCode { get; set; }
    }

    public partial class FulfillmentMessage
    {
        [JsonProperty("text")]
        public Text Text { get; set; }
    }

    public partial class Text
    {
        [JsonProperty("text")]
        public string[] TextText { get; set; }
    }

    public partial class Intent
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }

    public partial class OutputContext
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lifespanCount")]
        public long LifespanCount { get; set; }

        [JsonProperty("parameters")]
        public Parameters Parameters { get; set; }
    }

    public partial class Parameters
    {
        [JsonProperty("param")]
        public string Param { get; set; }
    }

    public partial class DialogflowRequest
    {
        public static DialogflowRequest FromJson(string json) => JsonConvert.DeserializeObject<DialogflowRequest>(json, OpenWeather.Server.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this DialogflowRequest self) => JsonConvert.SerializeObject(self, OpenWeather.Server.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
