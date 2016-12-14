using System;

namespace Fault_Logger
{
    class checkJobs //class to check how many waiting and unresolved jobs there are 
    {
        dataBaseConnection database = new dataBaseConnection();

        public Array checkPendingJobs()
        {
            int[] jobData = new int[2];

            string sqlWaitingJobs = "SELECT count(*) as waitingJobs FROM jobs WHERE status='Waiting'";

            var cmd = database.dataConnection(sqlWaitingJobs);
            var data = database.parameters();

            string sqlUnresolvedJobs = "SELECT count(*) as unresolvedJobs FROM jobs WHERE status='Unresolved'";

            var cmd2 = database.dataConnection(sqlUnresolvedJobs);
            var data2 = database.parameters();

            int waiting = 0;
            int unresolved = 0;

            try
            {
                waiting = Convert.ToInt32(data.Tables[0].Rows[0]["waitingJobs"]);
                unresolved = Convert.ToInt32(data2.Tables[0].Rows[0]["unresolvedJobs"]);
            }
            catch//suppress any errors
            {

            }
           
            jobData[0] = waiting;
            jobData[1] = unresolved;

            return jobData;
        }
    }
}
