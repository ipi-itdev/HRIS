using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WCORE.Controllers.APIController
{
    public class PAREmpInfoController : ApiController
    {
        private IPICORE_DTSEntities db = new IPICORE_DTSEntities();

        // GET api/ParExternals
        public IEnumerable<PAREmployeeInfo> GetParExternals()
        {
            return db.PAREmployeeInfoes.AsEnumerable();
        }

        // GET api/ParExternals/5/5
        public PAREmployeeInfo GetParExternals(int empid, int pkey)
        {
            PAREmployeeInfo PAREmployeeInfo;
            if (pkey > 0) { PAREmployeeInfo = db.PAREmployeeInfoes.SingleOrDefault(p => p.ID == pkey); } else { PAREmployeeInfo = db.PAREmployeeInfoes.SingleOrDefault(p => p.EmployeeRefNo == empid); }

            if (PAREmployeeInfo == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return PAREmployeeInfo;
        }

    }
}