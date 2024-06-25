namespace WebApiProyecto
{
using System.Text.Json.Serialization;

public class Address
    {
        [JsonPropertyName("city")]
        public string city { get; set; }

        [JsonPropertyName("street_name")]
        public string street_name { get; set; }

        [JsonPropertyName("street_address")]
        public string street_address { get; set; }

        [JsonPropertyName("zip_code")]
        public string zip_code { get; set; }

        [JsonPropertyName("state")]
        public string state { get; set; }

        [JsonPropertyName("country")]
        public string country { get; set; }

        [JsonPropertyName("coordinates")]
        public Coordinates coordinates { get; set; }
    }

    public class Coordinates
    {
        [JsonPropertyName("lat")]
        public double lat { get; set; }

        [JsonPropertyName("lng")]
        public double lng { get; set; }
    }

    public class CreditCard
    {
        [JsonPropertyName("cc_number")]
        public string cc_number { get; set; }
    }

    public class Employment
    {
        [JsonPropertyName("title")]
        public string title { get; set; }

        [JsonPropertyName("key_skill")]
        public string key_skill { get; set; }
    }

    public class UsuarioAleatorio
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("uid")]
        public string uid { get; set; }

        [JsonPropertyName("password")]
        public string password { get; set; }

        [JsonPropertyName("first_name")]
        public string first_name { get; set; }

        [JsonPropertyName("last_name")]
        public string last_name { get; set; }

        [JsonPropertyName("username")]
        public string username { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("avatar")]
        public string avatar { get; set; }

        [JsonPropertyName("gender")]
        public string gender { get; set; }

        [JsonPropertyName("phone_number")]
        public string phone_number { get; set; }

        [JsonPropertyName("social_insurance_number")]
        public string social_insurance_number { get; set; }

        [JsonPropertyName("date_of_birth")]
        public string date_of_birth { get; set; }

        [JsonPropertyName("employment")]
        public Employment employment { get; set; }

        [JsonPropertyName("address")]
        public Address address { get; set; }

        [JsonPropertyName("credit_card")]
        public CreditCard credit_card { get; set; }

        [JsonPropertyName("subscription")]
        public Subscription subscription { get; set; }
    }

    public class Subscription
    {
        [JsonPropertyName("plan")]
        public string plan { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; }

        [JsonPropertyName("payment_method")]
        public string payment_method { get; set; }

        [JsonPropertyName("term")]
        public string term { get; set; }
    }    
}
