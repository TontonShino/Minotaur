namespace ClientService.Models
{
    public class Device
    {
        public string Id {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public string appUserId {get;set;}
        public TokenValidation tokenValidation { get; set; } = new TokenValidation();
        
    }
}