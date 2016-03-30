using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.Services.Security;

namespace iq.mnl.beertap.ApiServices.Security
{

    public class beertapApiUser : ApiUser<UserAuthData>
    {
        public beertapApiUser(string name, Option<UserAuthData> authData)
            : base(authData)
        {
            Name = name;
        }

        public string Name { get; private set; }

    }

    public class beertapUserFactory : ApiUserFactory<beertapApiUser, UserAuthData>
    {
        public beertapUserFactory() :
            base(new HttpRequestDataStore<UserAuthData>())
        {
        }

        protected override beertapApiUser CreateUser(Option<UserAuthData> auth)
        {
            return new beertapApiUser("beertap user", auth);
        }
    }

}
