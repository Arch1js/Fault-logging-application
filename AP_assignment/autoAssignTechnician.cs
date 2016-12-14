using System;
using System.Data.OleDb;

namespace Fault_Logger
{
    class autoAssignTechnician
    {
        dataBaseConnection database = new dataBaseConnection();
        string[] results = new string[4];

        public Array autoAssign(string specialization, int faultZone)
        {
            string sqlTechZone ="SELECT technicianID, technician_Name, current_Location FROM technicians WHERE specialization= @specialization AND status= @status";//select all technicians with required status and specialization
            var cmd = database.dataConnection(sqlTechZone);

            cmd.Parameters.Add("@specialization", OleDbType.VarChar).Value = specialization;//add query parameters
            cmd.Parameters.Add("@status", OleDbType.VarChar).Value = "available";

            var data = database.parameters();

            string sqlJobsCompleted = "SELECT techID, count(*) as jobCount FROM finishedJobs WHERE finishedDateTime BETWEEN @from AND @to GROUP BY techID";//count number of jobs done by which technician in last day

            var cmd2 = database.dataConnection(sqlJobsCompleted);

            DateTime date = DateTime.Now;
            var currentDay = date.Date;//current date and time

            var dateFrom = currentDay.ToString();
            var dateTo = currentDay.AddDays(1).ToString();//add day to last date

            cmd2.Parameters.Add("@from", OleDbType.Date).Value = "#" + dateFrom + "#";
            cmd2.Parameters.Add("@to", OleDbType.Date).Value = "#" + dateTo + "#";

            var jobData = database.parameters();

            int closestTechZone = 0;
            int smallestDistance = -1;
            string techID = "";
            string techName = "";
            int currentTechJobCount = 0;
            int realJobCount = 0;

            int count = data.Tables[0].Rows.Count;//get returned data count

            if (count == 0)
            {
                string[] error = new string[1];
                error[0] = "Error";
                return error;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    int zone = Convert.ToInt32(data.Tables[0].Rows[i]["current_Location"]); //tech zone
                    int technicianId = Convert.ToInt32(data.Tables[0].Rows[i]["technicianID"]);
                    int sub = Math.Abs(faultZone - zone); //substract to see distance

                    try
                    {
                        for (int e = 0; e < jobData.Tables[0].Rows.Count; e++)
                        {
                            int currentTechId = Convert.ToInt32(jobData.Tables[0].Rows[e]["techID"]);

                            if (technicianId == currentTechId)//if technician has done a job today
                            {                                
                                currentTechJobCount = Convert.ToInt32(jobData.Tables[0].Rows[e]["jobCount"]); //set the job count current technician has done                              
                            }
                        }
                    }
                    catch (Exception)
                    {
                        string[] error = new string[1];
                        error[0] = "Error";
                        return error;
                    }
                   
                    if(realJobCount == currentTechJobCount)
                    {
                        
                        if (closestTechZone == 0) //if there is no tech found yet
                        {
                            closestTechZone = zone;

                            smallestDistance = sub;

                            techID = data.Tables[0].Rows[i]["technicianID"].ToString();
                            techName = data.Tables[0].Rows[i]["technician_Name"].ToString();
                            realJobCount = currentTechJobCount;
                        }
                        else if (sub < smallestDistance)//if distance is smaller then previous
                        {
                            closestTechZone = zone;
                            smallestDistance = sub;

                            techID = data.Tables[0].Rows[i]["technicianID"].ToString();
                            techName = data.Tables[0].Rows[i]["technician_Name"].ToString();
                            realJobCount = currentTechJobCount;
                        }
 
                    }
                    else if (currentTechJobCount < realJobCount)//if current technician job count is less the previous potentioal technicians
                    {
                        realJobCount = currentTechJobCount;
                        techID = data.Tables[0].Rows[i]["technicianID"].ToString();
                        techName = data.Tables[0].Rows[i]["technician_Name"].ToString();
                    }
                    currentTechJobCount = 0;
                }

            }
            results[0] = techID;//add technicians details to array
            results[1] = techName;
            results[2] = closestTechZone.ToString();
            results[3] = realJobCount.ToString();

            return results;

        }
    }
}
