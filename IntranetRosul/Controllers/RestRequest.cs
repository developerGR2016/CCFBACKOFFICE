namespace IntranetRosul.Controllers
{
    internal class RestRequest
    {
        private object gET;
        private string uri;

        public RestRequest(string uri, object gET)
        {
            this.uri = uri;
            this.gET = gET;
        }

        public object RequestFormat { get; set; }
    }
}