
using ServiceLayer.Interface;

namespace ServiceLayer.Services
{
    public class CommonService : ConnectionManager, ICommonService
    {
        public CommonService(string dbConnection) : base(dbConnection)
        {

        }





    }
}
