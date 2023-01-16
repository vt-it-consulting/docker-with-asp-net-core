using Microsoft.AspNetCore.Mvc;

namespace CarvedRock.Api.Controllers
{
    public class Config
    {
        public string ConnectionString { get; internal set; }
        public string SimpleProperty { get; internal set; }
        public string NestedProperty { get; internal set; }
        public string AllString { get; internal set; }
    }
}